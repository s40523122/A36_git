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
//using System.Windows.Shapes;
using Messages.roscpp_tutorials;
using Messages.topic_tools;
using RosSharp_HMI.Services;


namespace RosSharp_HMI
{
    public partial class Control : Form
    {
        NodeHandle _nh;

        // 連線/中斷連線顯示設定
        string exec_txt = "roscore";
        string inter_txt = "disroscore";

        string layout_path = Path.Combine(Form1.debug_path, "config/layout.ini");

        public Control()
        {
            InitializeComponent();

            local_ip.Text = INiReader.ReadINIFile(layout_path, "Control", local_ip.Name);
            server_ip.Text = INiReader.ReadINIFile(layout_path, "Control", server_ip.Name);
            server_username.Text = INiReader.ReadINIFile(layout_path, "Control", server_username.Name);
            server_pwd.Text = INiReader.ReadINIFile(layout_path, "Control", server_pwd.Name);

            local_ip.TextChanged += setting_TextChanged;
            server_ip.TextChanged += setting_TextChanged;
            server_username.TextChanged += setting_TextChanged;
            server_pwd.TextChanged += setting_TextChanged;
        }

        private void setting_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = (sender as TextBox);
            
            INiReader.WriteINIFile(layout_path, "Control", textbox.Name, textbox.Text);
        }

        SSh_Tool core_ssh = new SSh_Tool();
        private async void ssh_conn_Click(object sender, EventArgs e)
        {
            if (!core_ssh.Interrupt)
            {
                core_ssh.Send_interrupt();
                return;
            }

            core_ssh = new SSh_Tool()
            {
                Host = server_ip.Text,
                Username = server_username.Text,
                Password = server_pwd.Text,
                Command = "roscore",
                Executed_key = "/rosout",
                Interrupt_key = "done"
            };

            richTextBox1.TextChanged += RichTextBox1_TextChanged;
            await core_ssh.Execute(richTextBox1);

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            // 設定 ssh 命令執行/中止時的文字顯示
            button2.Text = core_ssh.Interrupt ? exec_txt : inter_txt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AddDataToChart(series);
            RosSubTest();
        }


        private void RosSubTest()
        {
            //Subscriber<Messages.tf2_msgs.TFMessage> sub = _nh.Subscribe<Messages.tf2_msgs.TFMessage>("/tf", 10, tfsubCallback);
            Subscriber<Messages.std_msgs.String> sub = _nh.Subscribe<Messages.std_msgs.String>("/receive_from_client", 10, subCallback);
            //Console.CancelKeyPress += Console_CancelKeyPress;
        }

        private void ShowTagTF(RichTextBox chatbox, Messages.tf2_msgs.TFMessage argument)
        {
            Invoke(new MethodInvoker(delegate
            {
                chatbox.Text = $"X: {argument.transforms[0].transform.translation.x} \n" +
                            $"Y: {argument.transforms[0].transform.translation.y} \n" +
                            $"Z: {argument.transforms[0].transform.translation.z} \n" +
                            $"qw: {argument.transforms[0].transform.rotation.w} \n" +
                            $"qx: {argument.transforms[0].transform.rotation.x} \n" +
                            $"qy: {argument.transforms[0].transform.rotation.y} \n" +
                            $"qz: {argument.transforms[0].transform.rotation.z}";
            }));
        }

        private void subCallback(Messages.std_msgs.String msg)
        {
            Invoke(new MethodInvoker(delegate
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = dataGridView1.Rows.Count;
                row.Cells[1].Value = msg.data;
                dataGridView1.Rows.Add(row);
            }));
        }

        private void tfsubCallback(Messages.tf2_msgs.TFMessage argument)
        {  
            //switch (argument.transforms[0].child_frame_id)
            //{
            //    case "Calibration":
            //        ShowTagTF(tag0, argument);
            //        break;
            //    case "tag_1":
            //        ShowTagTF(tag1, argument);
            //        break;
            //    case "tag_2":
            //        ShowTagTF(tag2, argument);
            //        break;
            //    //case "tag_3":
            //    //    ShowTagTF(tag3, argument);
            //    //    break;
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExecuteProgram("realsense_camera");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ExecuteProgram("realsense_camera_cancle");
        }

        /// <summary>
        /// 透過 Service 執行程式
        /// </summary>
        /// <param name="task_name"></param>
        void ExecuteProgram(string task_name = "realsense_camera_cancle")
        {
            new Thread(new ThreadStart(() =>
            {
                //Random r = new Random();
                while (ROS.ok)
                {
                    try
                    {
                        MuxSelect.Request req = new MuxSelect.Request() { topic = task_name };
                        MuxSelect.Response resp = new MuxSelect.Response();
                        DateTime before = DateTime.Now;
                        bool res = _nh.ServiceClient<MuxSelect.Request, MuxSelect.Response>("/phone_booth").Call(req, ref resp);
                        TimeSpan dif = DateTime.Now.Subtract(before);

                        string str = "";
                        if (res)
                        {
                            str = "" + resp.prev_topic + "\n";
                            Console.WriteLine(str);
                            break;
                        }
                        else
                            str = "call failed after\n";
                        str += Math.Round(dif.TotalMilliseconds, 2) + " ms";
                        Console.WriteLine(str);
                    }
                    catch
                    {

                    }
                    Thread.Sleep(500);
                }
            })).Start();
        }

        private void ReceiveImage(Messages.sensor_msgs.Image message)
        {
            int width = Convert.ToInt32(message.width);
            int height = Convert.ToInt32(message.height);
            // 將ROS影像訊息轉換為Bitmap
            Bitmap bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int index = (y * width + x) * 3;
                    Color color = Color.FromArgb(message.data[index], message.data[index + 1], message.data[index + 2]);
                    bitmap.SetPixel(x, y, color);
                }
            }

            // 在PictureBox中顯示圖像
            pictureBox1.Invoke((MethodInvoker)delegate
            {
                pictureBox1.Image = bitmap;
            });
        }

        private void ReceiveCompressedImage(Messages.sensor_msgs.CompressedImage message)
        {
            // 將ROS壓縮圖像數據轉換為Bitmap
            byte[] imageData = message.data;
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                Bitmap bitmap = new Bitmap(ms);

                // 在PictureBox中顯示圖像
                pictureBox1.Invoke((MethodInvoker)delegate
                {
                    pictureBox1.Image = bitmap;
                });
            }
        }

        Subscriber<Messages.sensor_msgs.CompressedImage> sub_c;
        private void button6_Click(object sender, EventArgs e)
        {
            if (sub_c != null) sub_c.Shutdown();
            //Subscriber<Messages.sensor_msgs.Image> sub = nh.Subscribe<Messages.sensor_msgs.Image>("/camera/color/image_raw", 10, ReceiveImage);
            sub_c = _nh.Subscribe<Messages.sensor_msgs.CompressedImage>("/camera/color/image_raw/compressed", 10, ReceiveCompressedImage);
            
        }

        private async void button7_Click(object sender, EventArgs e)
        {

            await RosSharp_Tool.RosInit(server_ip.Text, 11311, local_ip.Text);
            _nh = RosSharp_Tool.nh;
        }
    }
}
