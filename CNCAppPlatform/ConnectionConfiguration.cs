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
        static string layout_path = Path.Combine(iCAPS.Env.debug_path, "config/layout.ini");
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
                string ip = INiReader.ReadINIFile(layout_path, "Control", "remote_ip");
                if (ip == "") ip = "127.0.0.1";
                return ip;
            }
            set
            {
                INiReader.WriteINIFile(layout_path, "Control", "remote_ip", value);
            }
        }

        static public int socket_port
        {
            get
            {
                int portInt;
                if (!int.TryParse(INiReader.ReadINIFile(layout_path, "Control", "socket_port"), out portInt))
                {
                    portInt = 0;
                }
                return portInt;
            }
            set
            {
                INiReader.WriteINIFile(layout_path, "Control", "socket_port", value.ToString());
            }
        }

        static public string user_name
        {
            get
            {
                return INiReader.ReadINIFile(layout_path, "Control", "user_name");
            }
            set
            {
                INiReader.WriteINIFile(layout_path, "Control", "user_name", value);
            }
        }
        static public string pass_word
        {
            get
            {
                return INiReader.ReadINIFile(layout_path, "Control", "pass_word");
            }
            set
            {
                INiReader.WriteINIFile(layout_path, "Control", "pass_word", value);
            }
        }
    }
}
