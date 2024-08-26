using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using RosSharp_HMI.Services;

namespace RosSharp_HMI
{

    public partial class Form1 : Form
    {
        //private const int CS_DropShadow = 0x00020000;

        /// <summary>
        /// 專案 Debug 路徑
        /// </summary>
        public static string debug_path = Application.StartupPath;

        /// <summary>
        /// 連線狀態文字
        /// </summary>
        public string ConnectStatus
        {
            get { return connStatusLabel.Text; }
            set { connStatusLabel.Text = value; }
        }

        public static Size FormSize;
        public static Point FormLocation;
        public static Size WorkSize;

        public Form1()
        {
            InitializeComponent();


            MenuSetting();

            // 設定 Line Notify
            //JinToolkit.Services.LineNotify.connectToken = "4cNqk5otAwItnPkpeNvJKNsRylhrsndmFfAIiztJ4QU";

            // Debug 模式下，開放視窗縮放功能。反之，視窗為全螢幕。
            if (Debugger.IsAttached)
            {
                btnFormControl.Visible = true;
                btnFormControl.Click += BtnFormControl_Click;
            }
            else WindowState = FormWindowState.Maximized;

            SizeChanged += Form1_SizeChanged;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            FormSize = Size;
            FormLocation = Location;
            WorkSize = panel1.Size;
        }

        private void MenuSetting()
        {
            menu_1.Click += (sender, e) => menu_x_Click(sender, e, new Control());
            menu_2.Click += (sender, e) => menu_x_Click(sender, e, new SocketTest());
            menu_3.Click += (sender, e) => menu_x_Click(sender, e, new Hand_eye());
            //menu_4.Click += (sender, e) => menu_x_Click(sender, e, new Control());
            menu_setting.Click += (sender, e) => menu_x_Click(sender, e, new Form());
            menu_test1.Click += (sender, e) => menu_x_Click(sender, e, new Form());

            // 返回主頁
            btnHome.Click += btnHome_Click;
        }

        #region 視窗控制
        #region 視窗拖動設定
        private Point mousePoint = new Point();
        // 設定可拖動畫面
        void panel_title_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.mousePoint.X = e.X;
            this.mousePoint.Y = e.Y;
        }

        private void panel_title_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Top = Control.MousePosition.Y - mousePoint.Y;
                this.Left = Control.MousePosition.X - panel4.Width - mousePoint.X;
            }

            FormLocation = Location;
        }
        #endregion

        /// <summary>
        /// 視窗縮放 (點擊事件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFormControl_Click(object sender, EventArgs e)
        {
            if (btnFormControl.Change) WindowState = FormWindowState.Normal;
            else WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// 視窗最小化 (點擊事件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 關閉程式 (點擊事件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btPower_Click(object sender, EventArgs e)
        {
            RosSharp_Tool.Close_ROS();
            Application.Exit();
        }
        #endregion

        #region Navibar
        private const int SW_NORMAL = 1;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);

        private IntPtr handle;

        /// <summary>
        /// 返回主頁 (點擊事件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHome_Click(object sender, EventArgs e)
        {
            if (Debugger.IsAttached)
            {
                MessageBox.Show("現在是偵錯模式!");
                return;
            }
            
            this.WindowState = FormWindowState.Minimized;
            Process[] processName = Process.GetProcessesByName("iCAPS");
            var p = System.Diagnostics.Process.GetProcessesByName("iCAPS").FirstOrDefault();
            ShowWindow(p.MainWindowHandle, SW_NORMAL);
            handle = processName[0].MainWindowHandle;
            SetForegroundWindow(handle);
        }

        /// <summary>
        /// Menu 點擊事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_x_Click(object sender, EventArgs e, Form frame)
        {
            Button button = sender as Button;
            btnColor(button);
            if (!(button.Tag is Form))
            {
                frame.Dock = DockStyle.Fill;
                frame.TopLevel = false;
                frame.Parent = panel1;
                frame.FormBorderStyle = FormBorderStyle.None;

                button.Tag = frame;
            }

            Tag = button.Tag;
            (button.Tag as Form).Show();

            moduleTitle.Text = button.Text.Trim();
        }

        /// <summary>
        /// 按鈕選中後渲染
        /// </summary>
        /// <param name="btn"></param>
        private void btnColor(Button btn)
        {
            Button[] tbtn = new Button[] { menu_1, menu_2, menu_3, menu_setting, menu_test1 };
            btn.BackColor = Color.DodgerBlue;
            slidePanel.Top = btn.Top + btn.Parent.Top;
            slidePanel.Visible = true;
            foreach (var item in tbtn)
            {
                if (item.Name == btn.Name) continue;
                item.BackColor = Color.SteelBlue;
            }
            if (Tag is Form) (Tag as Form).Hide();
        }
        #endregion
        private void info_Click(object sender, EventArgs e)
        {
            //LineNotify hachunGroup = new LineNotify("ZZkOh8kZn3QLj9hGmy8lfWygcTCekFl1wBbPlavR2LX");
            //hachunGroup.pushNotify("Test", "");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //machineState1.timer1.Enabled = true;
        }

        
    }

}
