using RosSharp_HMI.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosSharp_HMI
{
    internal class ConnectionConfiguration
    {
        static string layout_path = Path.Combine(Form1.debug_path, "config/layout.ini");
        static public string local_ip 
        { 
            get
            {
                return INiReader.ReadINIFile(layout_path, "Control", "local_ip");
            }
            set 
            {
                INiReader.WriteINIFile(layout_path, "Control", "local_ip", value);
            } 
        }
        static public string remote_ip
        {
            get
            {
                return INiReader.ReadINIFile(layout_path, "Control", "remote_ip");
            }
            set
            {
                INiReader.WriteINIFile(layout_path, "Control", "remote_ip", value);
            }
        }

        static public string socket_port
        {
            get
            {
                return INiReader.ReadINIFile(layout_path, "Control", "socket_port");
            }
            set
            {
                INiReader.WriteINIFile(layout_path, "Control", "socket_port", value);
            }
        }

        static public string user_name { get; set; }
        static public string pass_word { get; set; }

    }
}
