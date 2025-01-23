// 2025/01/14

using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using System.Windows.Controls;

namespace RosSharp_HMI.Services
{
    public class Socket_Tool
    {
        #region Server Sample
        Socket_Server server = new Socket_Server(5000);     // 連線，開放所有 Client 端連線，需加入指定 port

        private async void server_main()
        {
            server.Start();

            // 可用 server.Connected 檢查是否連線，初次檢查需等待連線1秒  (可選)
            await Task.Delay(1000);
            if (server.Connected) Console.WriteLine( "已開啟伺服器!");

            // 不論如何，送送訊息給已連接的 client (可選)
            server.SendToClient("Hi"); 

            // 訂閱訊息接收事件，接收訊息為 e.Message
            server.MessageReceived += ServerMessageReceived;
            
        }
        private void ServerMessageReceived(object sender, Socket_Server.MessageEventArgs e)
        {
            //richTextBox1.Invoke((MethodInvoker)delegate
            //{
            //    richTextBox1.Text = "收到客戶端消息：" + e.Message;
            //});

            string response = "Received message: " + e.Message;
            server.SendToClient(response); // 發送回應
        }
        #endregion

        #region Client Sample
        Socket_Client client = new Socket_Client("192.168.32.164", 5000);
        private async void client_main()
        {
            // 連線至指定 Server
            client.Connect();

            // 可用 client.Connected 檢查是否連線，初次檢查需等待連線1秒  (可選)
            await Task.Delay(1000);
            if (client.Connected) Console.WriteLine("已連線至伺服器!");

            // 傳送訊息至 Server 端
            client.Send("tell server i need");

            // 訂閱訊息接收事件，接收訊息為 e.Message
            client.MessageReceived += ClientMessageReceived; ;
        }

        private void ClientMessageReceived(object sender, Socket_Client.MessageEventArgs e)
        {
            //richTextBox1.Invoke((MethodInvoker)delegate
            //{
            //    richTextBox1.Text = "收到客戶端消息：" + e.Message;
            //});

            string response = "Received message: " + e.Message;
        }
        #endregion
    }

    class Socket_Server
    {
        private Socket serverSocket;   // 用於監聽和接受連接的伺服器 Socket
        private Socket clientSocket;   // 用於與客戶端進行通訊的 Socket

        /// <summary>
        /// Socket 接收資料
        /// </summary>
        public string Log { get; private set; }

        /// <summary>
        /// Server 狀態
        /// </summary>
        public bool Connected { get; private set; } = false;

        // 監聽端點
        private IPEndPoint endPoint;

        public Socket_Server(int port)
        {
            // 設定監聽端點，監聽所有IP上的 port 端口
            endPoint = new IPEndPoint(IPAddress.Any, port);
        }

        /// <summary>
        /// 啟動伺服器
        /// </summary>
        public void Start()
        {
            // 在背景執行緒中啟動伺服器
            Task.Run(() => StartServer());
        }

        // 啟動伺服器的主要邏輯
        private void StartServer()
        {
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(10); // 設置最大佇列長度為10
                Connected = true;

                while (true)
                {
                    // 等待客戶端連接
                    clientSocket = serverSocket.Accept();
                    // 為每個客戶端連接啟動新的背景任務
                    Task.Run(() => HandleClient(clientSocket));
                }
            }
            catch (Exception ex)
            {
                // 顯示啟動伺服器時的錯誤訊息
                Log = "伺服器啟動失敗：" + ex.Message;
                Console.WriteLine(Log);
            }
        }

        // 處理與客戶端的通訊
        private void HandleClient(Socket client)
        {
            try
            {
                // 設置接收和發送超時為10秒
                client.ReceiveTimeout = 5000; // 接收超時
                client.SendTimeout = 5000; // 發送超時
                
                while (client.Connected)
                {
                    try
                    {
                        byte[] buffer = new byte[1024];
                        int received = client.Receive(buffer); // 接收來自客戶端的數據
                        if (received == 0) return; // 客戶端斷開連接

                        string text = Encoding.ASCII.GetString(buffer, 0, received);
                        
                        // 在 UI 執行緒中顯示收到的消息
                        Log = "收到客戶端消息：" + text;
                        Console.WriteLine(Log);

                        // 觸發事件
                        OnMessageReceived(text);
                    }
                    catch (SocketException ex)
                    {
                        if (ex.SocketErrorCode == SocketError.TimedOut)
                        {
                            // 接收超時，不退出循環，繼續等待消息
                            continue;
                        }
                        else
                        {
                            // 其他 Socket 錯誤，退出循環
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 顯示處理客戶端時的錯誤訊息(斷線)
                Log = "處理客戶端時出錯：" + ex.Message;
                Console.WriteLine(Log);

                client.Close(); // 關閉客戶端連接
            }
        }

        /// <summary>
        /// 按下發送消息按鈕時的事件處理函數
        /// </summary>
        public void SendToClient(string message)
        {
            try
            {
                if (clientSocket != null && clientSocket.Connected)
                {
                    // 發送消息到客戶端
                    byte[] data = Encoding.ASCII.GetBytes(message);
                    clientSocket.Send(data);
                }
                else
                {
                    Log = "沒有連接的客戶端。";
                    Console.WriteLine(Log);
                }
            }
            catch (Exception ex)
            {
                // 顯示發送消息時的錯誤訊息
                Log = "發送消息到客戶端失敗：" + ex.Message;
                Console.WriteLine(Log);
            }
        }

        /// <summary>
        /// 關閉 Server 端連線
        /// </summary>
        public void Close()
        {
            serverSocket.Close();
            Connected = false;
        }

        // 定義訊息接收事件與委派
        public delegate void MessageReceivedHandler(object sender, MessageEventArgs e);

        public class MessageEventArgs : EventArgs
        {
            public string Message { get; }

            public MessageEventArgs(string message)
            {
                Message = message;
            }
        }

        // 定義一個事件，使用 MessageReceivedHandler 委派
        public event MessageReceivedHandler MessageReceived;

        // 當接收到新消息時，觸發事件
        protected virtual void OnMessageReceived(string message)
        {
            MessageReceived?.Invoke(this, new MessageEventArgs(message));
        }
    }

    class Socket_Client
    {
        private Socket ClientSocket; // 用於與伺服器通訊的 Socket

        /// <summary>
        /// Client 狀態
        /// </summary>
        public bool Connected { get; private set; } = false;

        /// <summary>
        /// Socket 接收資料
        /// </summary>
        public string Log { get; private set; }

        // 伺服器端點
        private IPEndPoint endPoint;

        public Socket_Client(string Server_ip, int port)
        {
            // 設定伺服器端點，連接到指定ip的port
            endPoint = new IPEndPoint(IPAddress.Parse(Server_ip), port);
        }

        /// <summary>
        /// 連接伺服器
        /// </summary>
        public void Connect()
        {
            // 在背景執行緒中連接到伺服器
            Task.Run(() => ConnectToServer());
        }

        /// <summary>
        /// 連接到伺服器的主要邏輯
        /// </summary>
        private void ConnectToServer()
        {
            try
            {
                ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ClientSocket.Connect(endPoint);

                // 設置接收和發送超時為5秒
                ClientSocket.ReceiveTimeout = 5000; // 接收超時
                ClientSocket.SendTimeout = 5000; // 發送超時

                // 顯示連接成功消息
                Log = "已連接到伺服器！";
                Console.WriteLine(Log);

                Connected = true;

                // 啟動背景任務以接收消息
                Task.Run(() => ReceiveMessages());
            }
            catch (Exception ex)
            {
                // 顯示連接伺服器時的錯誤訊息
                Log = "連接伺服器失敗：" + ex.Message;
                Console.WriteLine(Log);
            }
        }

        /// <summary>
        /// 接收來自伺服器的消息
        /// </summary>
        private void ReceiveMessages()
        {
            try
            {
                while (Connected)
                {
                    try
                    {
                        byte[] buffer = new byte[1024];
                        int received = ClientSocket.Receive(buffer); // 接收伺服器發來的數據
                        if (received == 0) return; // 伺服器斷開連接

                        string text = Encoding.ASCII.GetString(buffer, 0, received);
                        // 在 UI 執行緒中顯示收到的消息
                        Log = "收到伺服器消息：" + text;
                        Console.WriteLine(Log);

                        // 觸發事件
                        OnMessageReceived(text);
                    }
                    catch (SocketException ex)
                    {
                        if (ex.SocketErrorCode == SocketError.TimedOut)
                        {
                            // 接收超時，不退出循環，繼續等待消息
                            continue;
                        }
                        else
                        {
                            // 其他 Socket 錯誤，退出循環
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 顯示接收消息時的錯誤訊息
                Log = "接收伺服器消息時出錯：" + ex.Message;
                Console.WriteLine(Log);

                ClientSocket.Close(); // 關閉連接
            }
        }

        /// <summary>
        /// 發送消息至 Server 端
        /// </summary>
        public void Send(string message)
        {
            try
            {
                if (ClientSocket != null && ClientSocket.Connected)
                {
                    // 發送消息到伺服器
                    byte[] data = Encoding.ASCII.GetBytes(message);
                    ClientSocket.Send(data);
                }
                else
                {
                    Log = "未連接到伺服器。";
                    Console.WriteLine(Log);
                }
            }
            catch (Exception ex)
            {
                // 顯示發送消息時的錯誤訊息
                Log = "發送消息到伺服器失敗：" + ex.Message;
                Console.WriteLine(Log);
            }
        }

        /// <summary>
        /// 關閉 Client 端連線
        /// </summary>
        public void Close()
        {
            ClientSocket.Close();
            Connected = false;
        }

        // 定義訊息接收事件與委派
        public delegate void MessageReceivedHandler(object sender, MessageEventArgs e);

        public class MessageEventArgs : EventArgs
        {
            public string Message { get; }

            public MessageEventArgs(string message)
            {
                Message = message;
            }
        }

        // 定義一個事件，使用 MessageReceivedHandler 委派
        public event MessageReceivedHandler MessageReceived;

        // 當接收到新消息時，觸發事件
        protected virtual void OnMessageReceived(string message)
        {
            MessageReceived?.Invoke(this, new MessageEventArgs(message));
        }
    }
}
