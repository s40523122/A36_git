using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;

namespace RosSharp_HMI
{
    public partial class SshTest : Form
    {
        private SshClient sshClient;
        private ShellStream shellStream;

        public SshTest()
        {
            InitializeComponent();

            Load += Form1_Load;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 初始化 SSH 連線
            sshClient = new SshClient("r-ubuntu", "r", "R");
            sshClient.Connect();
            shellStream = sshClient.CreateShellStream("xterm", 80, 24, 800, 600, 1024);

            // 訂閱 RichTextBox 的 KeyDown 事件
            richTextBox1.KeyDown += RichTextBox1_KeyDown;

            // 啟動背景執行緒來讀取 SSH 回應
            var responseThread = new System.Threading.Thread(ReadResponse);
            responseThread.IsBackground = true;
            responseThread.Start();
        }

        private void RichTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string command = richTextBox1.Text + "\n";
                byte[] buffer = Encoding.UTF8.GetBytes(command);
                shellStream.Write("\n");
                richTextBox1.Clear();
                e.Handled = true; // 阻止 RichTextBox 插入新行
            }
            else if (e.KeyCode == Keys.Tab)
            {
                shellStream.Write("\t");
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Back)
            {
                if (richTextBox1.Text.Length > 0)
                {
                    // 傳送 Backspace 給 SSH
                    shellStream.Write("\b");

                    // 刪除 RichTextBox 中最後一個字符
                    richTextBox1.Text = richTextBox1.Text.Substring(0, richTextBox1.Text.Length - 1);
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                }
                e.Handled = true; // 阻止 RichTextBox 自行處理 Backspace
            }
            else
            {
                // 把其他字元傳送給 SSH
                char keyChar = char.ToLower((char)e.KeyValue);
                shellStream.Write(keyChar.ToString());

                System.Threading.Thread.Sleep(100);
                string response = shellStream.Read();
                Invoke(new MethodInvoker(delegate
                {
                    rtfmsg += ReadToRtf(response);
                    richTextBox1.Rtf = rtfmsg;
                    richTextBox1.SelectionStart = richTextBox1.TextLength;
                    richTextBox1.ScrollToCaret(); // 滾動到最新行
                }));
            }
        }

        private string LineToRtf(string line)
        {
            if (Regex.IsMatch(line, @"\x1b\]0;")) return "";     // 略過終端機提示符
            if (Regex.IsMatch(line, @"\x1b\]2;")) line = "";
            if (Regex.IsMatch(line, @"\x1b\[1m")) line = line.Substring(4);     // 略過淺色白字轉換
            if (Regex.IsMatch(line, @"\x1b\[31m")) line = line.Replace(@"[31m", @"\cf2").Substring(1);      // 字串轉換紅色字
            if (Regex.IsMatch(line, @"\x1b\[0m")) line = line.Replace(@"[0m", @" \cf1 ");       // 字串轉換白色字
            if (Regex.IsMatch(line, @"\[K")) line = "";      // 略過刪除符號

            return line + @" \par ";        // 加上換行符號
        }

        private string ReadToRtf(string read)
        {
            if (Regex.IsMatch(read, @"\x1b\]0;")) return "";     // 略過終端機提示符
            if (Regex.IsMatch(read, @"\x1b\]2;")) read = "";
            if (Regex.IsMatch(read, @"\x1b\[1m")) read = read.Substring(4);     // 略過淺色白字轉換
            if (Regex.IsMatch(read, @"\x1b\[31m")) read = read.Replace(@"[31m", @"\cf2").Substring(1);      // 字串轉換紅色字
            if (Regex.IsMatch(read, @"\x1b\[0m")) read = read.Replace(@"[0m", @" \cf1 ");       // 字串轉換白色字
            if (Regex.IsMatch(read, @"\[K")) read = "";      // 略過刪除符號

            return read;
        }

        string rtfmsg = "";
        private void ReadResponse()
        {
            Invoke(new MethodInvoker(delegate
            {
                rtfmsg = @"{\rtf1
                                          {\colortbl;\red255\green255\blue255;\red255\green0\blue0;}";
            }));

            while (sshClient.IsConnected)
            {
                string response_line = shellStream.ReadLine();
                if (response_line == "") continue;
                Invoke(new MethodInvoker(delegate
                {
                    rtfmsg += LineToRtf(response_line);
                    richTextBox1.Rtf = rtfmsg;
                    richTextBox1.ScrollToCaret(); // 滾動到最新行
                }));
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            shellStream.Close();
            sshClient.Disconnect();
            base.OnFormClosing(e);
        }
    }
}
