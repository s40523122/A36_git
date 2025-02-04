using RosSharp_HMI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RosSharp_HMI.Forms
{
    public partial class Welcome : UserControl
    {
        Socket_Client client;

        public Welcome()
        {
            InitializeComponent();

            Load += Welcome_Load;
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            local_ip.Text = ConnectionConfiguration.local_ip;
            remote_ip.Text = ConnectionConfiguration.remote_ip;
            socket_port.Text = ConnectionConfiguration.socket_port.ToString();
        }

        private async void connect_btn_Click(object sender, EventArgs e)
        {
            ConnectionConfiguration.local_ip = local_ip.Text;
            ConnectionConfiguration.remote_ip = remote_ip.Text;

            int portInt;
            if (!int.TryParse(INiReader.ReadINIFile(socket_port.Text, "Control", "socket_port"), out portInt))
            {
                portInt = 0;
            }

            ConnectionConfiguration.socket_port = portInt;

            connect_btn.Visible = false;
            connect_btn.Visible = await RosSharp_Tool.RosInit(remote_ip.Text, 11311, local_ip.Text);
            this.Visible = false;
            // _nh = RosSharp_Tool.nh;

            return;
            // 更新 Client 端連線
            client = new Socket_Client(remote_ip.Text, 5000);

            // 在背景執行緒中連接到伺服器
            client.Connect();

            await Task.Delay(1000);
            //if (client.Connected) richTextBox2.Text = "已連接到伺服器！";

            client.MessageReceived += Client_MessageReceived;
        }

        // 當接收 Server 訊息時
        private void Client_MessageReceived(object sender, Socket_Client.MessageEventArgs e)
        {
           
        }

        private void shutdown_Click(object sender, EventArgs e)
        {
            RosSharp_Tool.Close_ROS();
        }

        private void btn_pass_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
