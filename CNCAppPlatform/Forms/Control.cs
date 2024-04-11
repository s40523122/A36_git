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
using RosSharp;
using System.Threading;
using Renci.SshNet;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Renci.SshNet.Common;

namespace CNCAppPlatform
{
    public partial class Control : Form
    {
        static string host = "r-ubuntu";
        static string username = "r";
        static string password = "R";
        //int port = 22; // SSH port (usually 22)

        SshClient client = new SshClient(host, username, password);
        StreamWriter writer;
        StreamReader reader;
        ShellStream shellStream;

        public Control()
        {
            InitializeComponent();

            Load += Control_Load;
            
        }

        private void ShellStream_Closed(object sender, EventArgs e)
        {
            //MessageBox.Show("SSH connection established."); // 顯示訊息框
            shellStream = client.CreateShellStream("xterm", 80, 24, 800, 600, 1024);
            shellStream.Closed += ShellStream_Closed;

            writer = new StreamWriter(shellStream, System.Text.Encoding.ASCII);
            reader = new StreamReader(shellStream, System.Text.Encoding.ASCII);
            ddd();
        }

        private async void Control_Load(object sender, EventArgs e)
        {

            await Task.Run(() => client.Connect());

            //MessageBox.Show("SSH connection established."); // 顯示訊息框
            shellStream = client.CreateShellStream("xterm", 80, 24, 800, 600, 1024);
            shellStream.Closed += ShellStream_Closed;
            writer = new StreamWriter(shellStream, System.Text.Encoding.ASCII);
            reader = new StreamReader(shellStream, System.Text.Encoding.ASCII);
            ddd();
        }

        bool isClick = false;

        private void button1_Click(object sender, EventArgs e)
        {
            //AddDataToChart(series);
            if (!isClick) RosSubTest();
            else Console_CancelKeyPress();
            isClick = !isClick;
        }


        private void RosSubTest()
        {
            // 設置 ROS 主機的 IP 地址和端口
            string rosBridgeServerIP = "192.168.32.130";
            int rosBridgeServerPort = 11311;


            ROS.ROS_IP = rosBridgeServerIP;
            ROS.ROS_MASTER_URI = $"http://{rosBridgeServerIP}:{rosBridgeServerPort}";
            ROS.ROS_HOSTNAME = "192.168.32.164";
            //ROS.TopicTimeout = 50000;
            //ROS.XmlRpcTimeout = 50000;

            ROS.Init("bbb");
            NodeHandle nh = new NodeHandle();


            Subscriber<Messages.tf2_msgs.TFMessage> sub = nh.Subscribe<Messages.tf2_msgs.TFMessage>("/tf", 10, subCallback);
            //Console.CancelKeyPress += Console_CancelKeyPress;
        }

        private static void Console_CancelKeyPress()
        {
            ROS.Shutdown();
            ROS.WaitForShutdown();
        }

        private void subCallback(Messages.tf2_msgs.TFMessage argument)
        {
            if (argument.transforms[0].child_frame_id == "tag_0")
            {
                Invoke(new MethodInvoker(delegate
                {
                    //tag0.Clear();
                    tag0.Text = $"X: {argument.transforms[0].transform.translation.x} \n" +
                                $"Y: {argument.transforms[0].transform.translation.y} \n" +
                                $"Z: {argument.transforms[0].transform.translation.z} \n" +
                                $"qw: {argument.transforms[0].transform.rotation.w} \n" +
                                $"qx: {argument.transforms[0].transform.rotation.x} \n" +
                                $"qy: {argument.transforms[0].transform.rotation.y} \n" +
                                $"qz: {argument.transforms[0].transform.rotation.z}";
                }));
            }
            else if (argument.transforms[0].child_frame_id == "tag_1")
            {
                Invoke(new MethodInvoker(delegate
                {
                    //tag1.Clear();
                    tag1.Text = $"X: {argument.transforms[0].transform.translation.x} \n" +
                                $"Y: {argument.transforms[0].transform.translation.y} \n" +
                                $"Z: {argument.transforms[0].transform.translation.z} \n" +
                                $"qw: {argument.transforms[0].transform.rotation.w} \n" +
                                $"qx: {argument.transforms[0].transform.rotation.x} \n" +
                                $"qy: {argument.transforms[0].transform.rotation.y} \n" +
                                $"qz: {argument.transforms[0].transform.rotation.z}";
                }));


                //tag1.Clear();

            }
            else if (argument.transforms[0].child_frame_id == "tag_2")
            {
                Invoke(new MethodInvoker(delegate
                {
                    //tag2.Clear();
                    tag2.Text = $"X: {argument.transforms[0].transform.translation.x} \n" +
                                $"Y: {argument.transforms[0].transform.translation.y} \n" +
                                $"Z: {argument.transforms[0].transform.translation.z} \n" +
                                $"qw: {argument.transforms[0].transform.rotation.w} \n" +
                                $"qx: {argument.transforms[0].transform.rotation.x} \n" +
                                $"qy: {argument.transforms[0].transform.rotation.y} \n" +
                                $"qz: {argument.transforms[0].transform.rotation.z}";
                }));
            }
            //Console.WriteLine(argument.transforms[0].transform.translation);


        }

        private async void button2_Click(object sender, EventArgs e)
        {
            
            if (!client.IsConnected)
            {
                MessageBox.Show("Failed to establish SSH connection."); // 顯示訊息框
                return;
            }

            string command = "roscore";

            await Task.Run(() => // 使用非同步操作執行命令
            {
                writer.WriteLine(command);
                writer.Flush();
            });


        }

        private async void ddd()
        {
            // 開始監視命令輸出
            await Task.Run(async () =>
            {
                string line;
                string RtfLine = @"{\rtf1
                                           {\colortbl;\red255\green255\blue255;\red255\green0\blue0;}";

                //while ((line = reader.ReadLine()) != null) if (line == command) break;  // 略過 ssh 連接訊息

                while ((line = reader.ReadLine()) != null)
                {
                    //Console.WriteLine(line);  // 在 Console 中顯示輸出

                    if (Regex.IsMatch(line, @"\x1b\]0;")) continue;     // 略過終端機提示符
                    if (Regex.IsMatch(line, @"\x1b\]2;")) line = "";
                    if (Regex.IsMatch(line, @"\x1b\[1m")) line = line.Substring(4);     // 略過淺色白字轉換
                    if (Regex.IsMatch(line, @"\x1b\[31m")) line = line.Replace(@"[31m", @"\cf2").Substring(1);      // 字串轉換紅色字
                    if (Regex.IsMatch(line, @"\x1b\[0m")) line = line.Replace(@"[0m", @" \cf1 ");       // 字串轉換白色字

                    RtfLine += line + @" \par ";        // 加上換行符號

                    Invoke(new MethodInvoker(delegate
                    {
                        richTextBox1.Rtf = RtfLine;
                        richTextBox1.SelectionStart = richTextBox1.TextLength;
                        richTextBox1.ScrollToCaret();
                    }));
                    await Task.Delay(100);      // 等待 100 ms
                };
            });
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await Task.Run(() => // 使用非同步操作執行命令
            {
                shellStream.Close();
                //writer.WriteLine("roscore");
                //writer.Flush();
            });
            //(button3.Tag as StreamWriter).Close();
            //MessageBox.Show("SSH connection closed."); // 顯示訊息框
            Console.WriteLine("SSH connection closed."); // 顯示訊息框
        }

        //private void button4_Click(object sender, EventArgs e)
        //{

        //}

        private void button4_Click(object sender, EventArgs e)
        {
            // 要執行的命令
            string command = "cmd.exe";

            // 建立 ProcessStartInfo 物件設定要執行的命令
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = command,
                Arguments = "/C ssh",
                UseShellExecute = false, // 不使用預設的 Shell 啟動進程

                //CreateNoWindow = true // 不顯示窗口
            };

            // 啟動進程
            Process cmdProcess = Process.Start(psi);
            //isCmdWindowVisible = true;
        }


    }
}
