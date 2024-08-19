using System;
using System.Windows.Forms;
using RosSharp_HMI.Services;
using System.Threading.Tasks;

namespace RosSharp_HMI
{
    public partial class SocketTest : Form
    {
        Socket_Server server = new Socket_Server(5000);
        Socket_Client client = new Socket_Client("192.168.32.164", 5000);

        public SocketTest()
        {
            InitializeComponent();

            // 訂閱事件
            server.MessageReceived += ServerMessageReceived;
            client.MessageReceived += Client_MessageReceived;
        }

        #region Server 端
        // 當接收 Client 訊息時
        private void ServerMessageReceived(object sender, Socket_Server.MessageEventArgs e)
        {
            richTextBox1.Invoke((MethodInvoker)delegate
            {
                richTextBox1.Text = "收到客戶端消息：" + e.Message;
            });

            string response = "Received message: " + e.Message;
            server.SendToClient(response); // 發送回應
        }
        
        // 按下啟動伺服器按鈕時的事件處理函數
        private async void btnStartServer_Click(object sender, EventArgs e)
        {
            // 在背景執行緒中啟動伺服器
            server.Start();

            await Task.Delay(1000);
            if (server.Connected) richTextBox1.Text = "已開啟伺服器!";
        }

        // 按下發送消息按鈕時的事件處理函數
        private void btnSendToClient_Click(object sender, EventArgs e)
        {
            server.SendToClient(textBox1.Text);
        }
        #endregion

        #region Client 端
        // 按下連接伺服器按鈕時的事件處理函數
        private async void btnConnect_Click(object sender, EventArgs e)
        {
            // 在背景執行緒中連接到伺服器
            client.Connect();

            await Task.Delay(1000);
            if (client.Connected) richTextBox2.Text = "已連接到伺服器！";
        }

        // 當接收 Server 訊息時
        private void Client_MessageReceived(object sender, Socket_Client.MessageEventArgs e)
        {
            richTextBox2.Invoke((MethodInvoker)delegate
            {
                richTextBox2.Text = "收到伺服器消息：" + e.Message;
            });
        }

        // 按下發送消息按鈕時的事件處理函數
        private void btnSend_Click(object sender, EventArgs e)
        {
            client.Send(textBox2.Text);
        }

        #endregion

    }
}
