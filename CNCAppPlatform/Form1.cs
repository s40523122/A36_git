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

        public static string debug_path = Application.StartupPath;

        /// <summary>
        /// 連線狀態文字
        /// </summary>
        public string ConnectStatus
        {
            get { return connStatusLabel.Text; }
            set { connStatusLabel.Text = value; }
        }

        public Form1()
        {
            InitializeComponent();
            

            // 返回主頁
            btnHome.Click += btnHome_Click;

            // 設定 Line Notify
            //JinToolkit.Services.LineNotify.connectToken = "4cNqk5otAwItnPkpeNvJKNsRylhrsndmFfAIiztJ4QU";

            // Debug 模式下，開放視窗縮放功能。反之，視窗為全螢幕。
            if (Debugger.IsAttached)
            {
                btnFormControl.Visible = true;
                btnFormControl.Click += BtnFormControl_Click;
            }
            else WindowState = FormWindowState.Maximized;
        }

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
            this.WindowState = FormWindowState.Minimized;
            Process[] processName = Process.GetProcessesByName("iCAPS");
            var p = System.Diagnostics.Process.GetProcessesByName("iCAPS").FirstOrDefault();
            ShowWindow(p.MainWindowHandle, SW_NORMAL);
            handle = processName[0].MainWindowHandle;
            SetForegroundWindow(handle);
        }

        /// <summary>
        /// Menu 1 (點擊事件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            btnColor(button);
            if (!(button.Tag is Form))
            {
                dynamic plcConn = new Control()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    Parent = panel1,
                    FormBorderStyle = FormBorderStyle.None
                };

                button.Tag = plcConn;
            }

            Tag = button.Tag;
            (button.Tag as Form).Show();

            moduleTitle.Text = button.Text.Trim();
        }

        /// <summary>
        /// Menu 2 (點擊事件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_2_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            btnColor(button);
            if (!(button.Tag is Form))
            {
                dynamic frame = new SocketTest()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    Parent = panel1,
                    FormBorderStyle = FormBorderStyle.None
                };

                button.Tag = frame;
            }

            Tag = button.Tag;

            (button.Tag as Form).Show();

            moduleTitle.Text = button.Text.Trim();
        }

        /// <summary>
        /// Menu 3 (點擊事件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_3_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            btnColor(button);
            if (!(button.Tag is Form))
            {
                dynamic frame = new Hand_eye()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    Parent = panel1,
                    FormBorderStyle = FormBorderStyle.None
                };

                button.Tag = frame;
            }

            Tag = button.Tag;
            (button.Tag as Form).Show();

            moduleTitle.Text = button.Text.Trim();
        }

        /// <summary>
        /// menu test1 (點擊事件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_test1_Click(object sender, EventArgs e)
        {
            //Button button = sender as Button;
            //btnColor(button);
            //if (!(button.Tag is Form))
            //{
            //    PlcControl plcControl = new PlcControl()
            //    {
            //        Dock = DockStyle.Fill,
            //        TopLevel = false,
            //        Parent = panel1,
            //        FormBorderStyle = FormBorderStyle.None
            //    };

            //    button.Tag = plcControl;
            //}

            //Tag = button.Tag;
            //(button.Tag as Form).Show();

            //moduleTitle.Text = button.Text.Trim();
        }

        /// <summary>
        /// 設定 (點擊事件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetting_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            btnColor(button);
            if (!(button.Tag is Form))
            {
                Control plcControl = new Control()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false,
                    Parent = panel1,
                    FormBorderStyle = FormBorderStyle.None
                };

                button.Tag = plcControl;
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
    public class myButton : Button
    {
        public myButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Font = new Font("微軟正黑體", 14, FontStyle.Bold);
            this.ForeColor = Color.White;
            this.TextAlign = ContentAlignment.MiddleRight;
            this.TextImageRelation = TextImageRelation.ImageBeforeText;
            //this.BackColor = Color.Black;
        
        }
    }

}
