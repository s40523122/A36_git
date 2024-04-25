using RosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCAppPlatform.Services
{
    internal class RosSharp_Tool
    {
        // 設置 ROS 主機的 IP 地址和端口
        static string rosBridgeServerIP = "192.168.32.130";
        static int rosBridgeServerPort = 11311;
        static string rosBridgeHostIP = "192.168.32.164";
        public static NodeHandle nh;

        public static void RosInit()
        {
            ROS.ROS_IP = rosBridgeServerIP;
            ROS.ROS_MASTER_URI = $"http://{rosBridgeServerIP}:{rosBridgeServerPort}";
            ROS.ROS_HOSTNAME = rosBridgeHostIP;
            if (ROS.IsStarted())
            {
                ROS.Init("ros_sharp");
                nh = new NodeHandle();
            }
  
        }


    }

}
