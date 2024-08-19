using Messages.topic_tools;
using RosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RosSharp_HMI.Services
{
    internal class RosSharp_Tool
    {
        // 設置 ROS 主機的 IP 地址和端口
        //public static string ros_server_ip = "r-ubuntu";
        //public static int ros_server_port = 11311;
        //public static string ros_host_ip = "192.168.32.164";
        public static NodeHandle nh;

        public async static Task RosInit(string ros_server_ip, int ros_server_port, string ros_host_ip)
        {
            ROS.ROS_IP = ros_server_ip;
            ROS.ROS_MASTER_URI = $"http://{ros_server_ip}:{ros_server_port}";
            ROS.ROS_HOSTNAME = ros_host_ip;

            await Task.Run(() =>
            {
                ROS.Init("ros_sharp");
                nh = new NodeHandle();
                MessageBox.Show("OK");
            });

            //ROS.Init("ros_sharp");
            //nh = new NodeHandle();
            
        }

        /// <summary>
        /// 關閉 ROS
        /// </summary>
        public static void Close_ROS()
        {
            ROS.Shutdown();
            ROS.WaitForShutdown();
        }

        /// <summary>
        /// 透過 /phone_booth 服務，自動執行遠端主機中的 ROS 節點。
        /// </summary>
        /// <param name="task_name">欲執行之任務名稱</param>
        /// <returns>
        /// 是否成功執行任務。
        /// </returns>
        /// <remarks>
        /// 當遠端服務器接收到指定任務名稱後，服務器會透過 python 的 subprocess 套件執行 ROS 節點。
        /// </remarks>
        public async static Task<bool> execute_task_by_service(string task_name = "task")
        {
            bool result = false;
            if (!ROS.ok)
            {
                Console.WriteLine("尚未連接至 ROS 伺服器");
                return result;
            }
            await Task.Run(async () =>
            {
                int times = 0;      // 呼叫次數

                while (ROS.ok)
                {
                    try
                    {
                        MuxSelect.Request req = new MuxSelect.Request() { topic = task_name };
                        MuxSelect.Response resp = new MuxSelect.Response();
                        DateTime before = DateTime.Now;

                        bool res = nh.ServiceClient<MuxSelect.Request, MuxSelect.Response>("/phone_booth").Call(req, ref resp);     // 發起交握
                        
                        TimeSpan dif = DateTime.Now.Subtract(before);   // 紀錄交握時間

                        string msg = "";
                        
                        // 當 res 存在時，表示交握成功，結束迴圈。
                        if (res)
                        {
                            msg = "" + resp.prev_topic + "\n";
                            Console.WriteLine(msg);
                            result = true;
                            break;
                        }
                        else
                        {
                            msg = "call failed after " + Math.Round(dif.TotalMilliseconds, 2) + " ms";
                            Console.WriteLine(msg);
                        }

                        // 每次呼叫紀錄 times 1 次，超過 5 次後判定 Time out，結束迴圈
                        times++;
                        if (times > 5)
                        {
                            Console.WriteLine("Time out !");
                            break;
                        }
                    }
                    catch(Exception ex) 
                    {
                        Console.WriteLine(ex.Message);
                    }

                    await Task.Delay(500); // 使用 await 等待一段時間後繼續下一次迴圈
                }
            });
            return result;
        }


    }

}
