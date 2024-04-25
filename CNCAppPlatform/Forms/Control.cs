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
using System.Windows.Shapes;
using Messages.roscpp_tutorials;
using Messages.topic_tools;
using CNCAppPlatform.Services;

namespace CNCAppPlatform
{
    public partial class Control : Form
    {
        NodeHandle nh;
        public Control()
        {
            InitializeComponent();
            
            RosSharp_Tool.RosInit();
            nh = RosSharp_Tool.nh;

            rosConn1.Click += SshConn2_Click;
            
        }

        private void SshConn2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(rosConn1.Command);
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

            Subscriber<Messages.tf2_msgs.TFMessage> sub = nh.Subscribe<Messages.tf2_msgs.TFMessage>("/tf", 10, subCallback);
            //Console.CancelKeyPress += Console_CancelKeyPress;
        }

        private static void Console_CancelKeyPress()
        {
            ROS.Shutdown();
            ROS.WaitForShutdown();
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

        private void subCallback(Messages.tf2_msgs.TFMessage argument)
        {
            switch (argument.transforms[0].child_frame_id)
            {
                case "tag_0":
                    ShowTagTF(tag0, argument);
                    break;
                case "tag_1":
                    ShowTagTF(tag1, argument);
                    break;
                case "tag_2":
                    ShowTagTF(tag2, argument);
                    break;
                //case "tag_3":
                //    ShowTagTF(tag3, argument);
                //    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExecuteProgram("realsense_camera");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ExecuteProgram("realsense_camera_cancle");
        }

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
                        bool res = nh.ServiceClient<MuxSelect.Request, MuxSelect.Response>("/phone_booth").Call(req, ref resp);
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
    }
}
