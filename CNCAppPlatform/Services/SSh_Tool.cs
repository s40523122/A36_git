using LiveCharts;
using LiveCharts.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Renci.SshNet;
using System.IO;
using System.Text.RegularExpressions;

namespace RosSharp_HMI.Services
{
    class SSh_Tool
    {
        ShellStream shellStream;
        StreamWriter writer;
        StreamReader reader;

        public string Command { set; get; }
        public string Executed_key { set; get; } = "This key in log indicates that the command was successfully executed";
        public string Interrupt_key { set; get; } = "This key in log indicates that the command was successfully interrupted";

        // ssh 連線設定
        public string Host { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public int Port { set; get; } = 22; // SSH port (usually 22)

        /// <summary>
        /// SSH 命令執行狀態是否中止
        /// </summary>
        public bool Interrupt { get; private set; } = true;

        /// <summary>
        /// 傳送中止命令
        /// </summary>
        public async void Send_interrupt()
        {
            await Task.Run(() => // 使用非同步操作執行命令
            {
                writer.WriteLine("\x03");
                writer.Flush();     // 發送
            });
        }

        private string StringToRtf(string line)
        {
            if (Regex.IsMatch(line, @"\x1b\]0;")) return "";     // 略過終端機提示符
            if (Regex.IsMatch(line, @"\x1b\]2;")) line = "";
            if (Regex.IsMatch(line, @"\x1b\[1m")) line = line.Substring(4);     // 略過淺色白字轉換
            if (Regex.IsMatch(line, @"\x1b\[31m")) line = line.Replace(@"[31m", @"\cf2").Substring(1);      // 字串轉換紅色字
            if (Regex.IsMatch(line, @"\x1b\[0m")) line = line.Replace(@"[0m", @" \cf1 ");       // 字串轉換白色字

            return line + @" \par ";        // 加上換行符號
        }

        /// <summary>
        /// 執行命令
        /// </summary>
        /// <param name="log_window">顯示 log 的 RichTextBox</param>
        /// <returns></returns>
        public async Task Execute(RichTextBox log_window)
        {
            using (var client = new SshClient(Host, Port, Username, Password))
            {
                try
                {
                    client.Connect();       // 連接 SSH
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (client.IsConnected)
                {
                    //MessageBox.Show("SSH connection established."); // 顯示訊息框
                    shellStream = client.CreateShellStream("xterm", 80, 24, 800, 600, 1024);

                    writer = new StreamWriter(shellStream, System.Text.Encoding.ASCII);
                    reader = new StreamReader(shellStream, System.Text.Encoding.ASCII);

                    await Task.Run(() => // 使用非同步操作執行命令
                    {
                        writer.WriteLine(Command);
                        writer.Flush();     // 發送
                    });

                    // 開始監視命令輸出
                    await Task.Run(async () =>
                    {
                        string line;
                        string RtfLine = @"{\rtf1
                                           {\colortbl;\red255\green255\blue255;\red255\green0\blue0;}";
                        //while ((line = reader.ReadLine()) != null) if (line == command) break;  // 略過 ssh 連接訊息
                        while ((line = reader.ReadLine()) != null)
                        {
                            RtfLine += StringToRtf( line );

                            bool close = false;
                            log_window.Invoke(new MethodInvoker(delegate
                            {
                                // 出現 Executed_key 代表程序啟動成功
                                if (Regex.IsMatch(line, Executed_key))
                                {
                                    //osender.Text = disconn_txt;
                                    //log_window.Tag = "exit";
                                    Interrupt = false;
                                }

                                // 出現 Interrupt_key 代表程序已中斷
                                else if (Regex.IsMatch(line, Interrupt_key))
                                {
                                    //osender.Text = conn_txt;
                                    //log_window.Tag = "";
                                    Interrupt = true;
                                    close = true;
                                }

                                log_window.Rtf = RtfLine;

                                // Set auto scroll
                                log_window.SelectionStart = log_window.TextLength;
                                log_window.ScrollToCaret();
                            }));

                            if (close) return;     // 關閉 shellStream

                            await Task.Delay(100);      // 等待 100 ms，製造 log 有逐行寫入的假象
                        };
                    });
                }
                else
                {
                    MessageBox.Show("Failed to establish SSH connection."); // 顯示訊息框
                }
            }
        }
    }
}
