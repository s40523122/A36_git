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
using System.Numerics;
using iCAPS;


namespace RosSharp_HMI
{
    public partial class ControlFrame : Form
    {
        NodeHandle _nh;

        // 連線/中斷連線顯示設定
        string exec_txt = "roscore";
        string inter_txt = "disroscore";

        string layout_path = Path.Combine(Env.debug_path, "config/layout.ini");
        static string hand_eye_poses_path = Path.Combine(Env.debug_path, "config/hand_eye_poses.ini");

        Socket_Client client = new Socket_Client(ConnectionConfiguration.remote_ip, ConnectionConfiguration.socket_port);

        public ControlFrame()
        {
            InitializeComponent();

            Load += Control_Load;

            //ros_stream.SizeChanged += Stream_SizeChange_1080p;
        }

        private void Control_Load(object sender, EventArgs e)
        {
            client.MessageReceived += Client_MessageReceived1;

            InitSocket();

            
        }

        private async void InitSocket()
        {
            // 在背景執行緒中連接到伺服器
            client.Connect();
            await Task.Delay(1000);
            if (client.Connected) socket_response.Text = "已連接到伺服器！";
        }

        private void Client_MessageReceived1(object sender, Socket_Client.MessageEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                socket_response.Text += "\n收到伺服器消息：" + e.Message;
            });
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
                //Host = server_ip.Text,
                //Username = server_username.Text,
                //Password = server_pwd.Text,
                Command = "rosco",
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
            Subscriber<Messages.tf2_msgs.TFMessage> sub = RosSharp_Tool.nh.Subscribe<Messages.tf2_msgs.TFMessage>("/tf", 10, tfsubCallback);
            // Subscriber<Messages.std_msgs.String> sub = _nh.Subscribe<Messages.std_msgs.String>("/receive_from_client", 10, subCallback);
            // Console.CancelKeyPress += Console_CancelKeyPress;
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
            switch (argument.transforms[0].child_frame_id)
            {
                case "filtered_apriltag":
                    ShowTagTF(richTextBox2, argument);
                    break;
                //case "tag_1":
                //    ShowTagTF(tag1, argument);
                //    break;
                //case "tag_2":
                //    ShowTagTF(tag2, argument);
                //    break;
                //case "tag_3":
                //    ShowTagTF(tag3, argument);
                //    break;
            }
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
            ros_stream.Invoke((MethodInvoker)delegate
            {
                ros_stream.Image = bitmap;
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
                ros_stream.Invoke((MethodInvoker)delegate
                {
                    ros_stream.Image = bitmap;
                });
            }
        }

        Subscriber<Messages.sensor_msgs.CompressedImage> sub_c;
        private void Sub_Video(object sender, EventArgs e)
        {
            if (sub_c != null)
            {
                sub_c.Shutdown();
                sub_c = null;
                playbtn.Visible = true;
            }
            //Subscriber<Messages.sensor_msgs.Image> sub = nh.Subscribe<Messages.sensor_msgs.Image>("/camera/color/image_raw", 10, ReceiveImage);
            else
            {
                sub_c = RosSharp_Tool.nh.Subscribe<Messages.sensor_msgs.CompressedImage>("/camera/color/image_raw/compressed", 10, ReceiveCompressedImage);
                playbtn.Visible = false;
            }
        }

        int record_index = 0;

        
        // 當接收 Server 訊息時
        private void Client_MessageReceived(object sender, Socket_Client.MessageEventArgs e)
        {
            switch (record_index)
            {
                case 0:
                    panel2.BackColor = Color.GreenYellow; 
                    break;
                case 1:
                    panel3.BackColor = Color.GreenYellow;
                    break;
                case 2:
                    panel4.BackColor = Color.GreenYellow;
                    break;
            }

            record_index++;

            //richTextBox2.Invoke((MethodInvoker)delegate
            //{
            //    richTextBox2.Text = "收到伺服器消息：" + e.Message;
            //});
        }

        Subscriber<Messages.tf2_msgs.TFMessage> static_sub;
        private void panel2_Click(object sender, EventArgs e)
        {
            client.Send("MULTI_0");

            static_sub = RosSharp_Tool.nh.Subscribe<Messages.tf2_msgs.TFMessage>("/tf_static", 10, multi_subCallback);
        }

        private void multi_subCallback(Messages.tf2_msgs.TFMessage argument)
        {
            switch (argument.transforms[0].child_frame_id)
            {
                case "MULTI_0":
                    Invoke(new MethodInvoker(delegate
                    {
                        Messages.geometry_msgs.Vector3 translation = argument.transforms[0].transform.translation;
                        Messages.geometry_msgs.Quaternion rotation = argument.transforms[0].transform.rotation;

                        multi_0_x.Text = $"{Math.Round(translation.x, 4)} \n";
                        multi_0_y.Text = $"{Math.Round(translation.y, 4)} \n";
                        multi_0_z.Text = $"{Math.Round(translation.z, 4)} \n";
                        multi_0_qw.Text = $"{Math.Round(rotation.w, 5)} \n";
                        multi_0_qx.Text = $"{Math.Round(rotation.x, 5)} \n";
                        multi_0_qy.Text = $"{Math.Round(rotation.y, 5)} \n";
                        multi_0_qz.Text = $"{Math.Round(rotation.z, 5)}";
                    }));
                    break;
                    //case "tag_1":
                    //    ShowTagTF(tag1, argument);
                    //    break;
                    //case "tag_2":
                    //    ShowTagTF(tag2, argument);
                    //    break;
                    //case "tag_3":
                    //    ShowTagTF(tag3, argument);
                    //    break;
            }
            static_sub.Shutdown();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            client.Send(textBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            client.Send(textBox2.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            client.Send(textBox3.Text);
        }

        static List<List<string>> poses = RosSharp_HMI.Services.INiReader.GetAllList(hand_eye_poses_path, "tsai");      // 需要調整為iCaps版本 !!!!!
        IEnumerator<List<string>> enumerator = poses.GetEnumerator();

        private async void button7_Click(object sender, EventArgs e)
        {
            if (enumerator.Current == null) { enumerator.MoveNext(); }
            client.Send($"tsair {enumerator.Current[1]}");

            if (int.Parse(enumerator.Current[0]) > 2)
            {
                // 暫停 2 秒（2000 毫秒）
                await Task.Delay(2000);
                client.Send($"tsai_result");
            }

            bool has_next = enumerator.MoveNext();
            if (!has_next)
            {
                enumerator.Reset();
                enumerator.MoveNext();
            }

            pose_index.Text = enumerator.Current[0].ToString();

            
        }

        private void btn_get_0_Click(object sender, EventArgs e)
        {
            client.Send("multi_0");
        }

        private void btn_get_x_Click(object sender, EventArgs e)
        {
            client.Send("multi_x");
        }

        private void btn_get_y_Click(object sender, EventArgs e)
        {
            client.Send("multi_y");
        }

        private void btn_get_fusion_Click(object sender, EventArgs e)
        {
            client.Send("fusion");
        }

        private void btn_set_fusion_Click(object sender, EventArgs e)
        {
            client.Send("fusion_set");
        }
        private void btn_set_0_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            InitSocket();
        }

        private void Stream_SizeChange_1080p(object sender, EventArgs e)
        {
            Form _form = sender as Form;

            int width_radio = ros_stream.Width / 16;
            int height_radio = ros_stream.Height / 9;

            int min_radio = Math.Min(width_radio, height_radio);

            ros_stream.Size = new Size(min_radio*16, min_radio*9);
        }
    }
}
