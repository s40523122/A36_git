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
using ActUtlTypeLib;
using RosSharp.MsgGen;

namespace CNCAppPlatform
{ 
   
    public partial class Form1 : Form
    {
        private const int SW_NORMAL = 1;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);

        private IntPtr handle;

        private const int CS_DropShadow = 0x00020000;

        public static ActUtlType axActUtlType = new ActUtlType();

        public string ConnectStatus
        {
            get { return connStatusLabel.Text; }
            set { connStatusLabel.Text = value; }
        }

        public Form1()
        {
            InitializeComponent();
            //sidePanel.Width = 150;
            string path = Application.StartupPath;

            if (!Debugger.IsAttached) WindowState = FormWindowState.Maximized;

            btnHome.Click += btnHome_Click;
            DateTime nowTime = DateTime.Now;

            JinToolkit.Services.LineNotify.connectToken = "4cNqk5otAwItnPkpeNvJKNsRylhrsndmFfAIiztJ4QU";
            JinToolkit.Services.LineNotify.intervalMin = 0.1;

            if (Debugger.IsAttached)
            {
                //btnFormControl.Visible = true;
                btnFormControl.Click += BtnFormControl_Click;
            }
        }

        private void BtnFormControl_Click(object sender, EventArgs e)
        {
            if (btnFormControl.Change) WindowState = FormWindowState.Normal;
            else WindowState = FormWindowState.Maximized;
        }

        private void btPower_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Navibar
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            Process[] processName = Process.GetProcessesByName("iCAPS");
            var p = System.Diagnostics.Process.GetProcessesByName("iCAPS").FirstOrDefault();
            ShowWindow(p.MainWindowHandle, SW_NORMAL);
            handle = processName[0].MainWindowHandle;
            SetForegroundWindow(handle);
        }

        private void btnOrderLog_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            btnColor(button);
            if (!(button.Tag is Form))
            {
                Control frame = new Control()
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

        private void btnDeviceOverall_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            btnColor(button);
            if (!(button.Tag is Form))
            {
                deviceOverview frame = new deviceOverview()
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

        private void btnPlcSetting_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            btnColor(button);
            if (!(button.Tag is Form))
            {
                PlcConn plcConn = new PlcConn()
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

        private void btnPlcTest_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            btnColor(button);
            if (!(button.Tag is Form))
            {
                PlcControl plcControl = new PlcControl()
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

        private void btnColor(Button btn)
        {
            Button[] tbtn = new Button[] { btnPlcSetting, btnOrderLog, btnDeviceOverView, btnSetting, btnPlcTest };
            btn.BackColor = Color.DodgerBlue;
            slidePanel.Top = btn.Top + 114;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string inputDir = AppDomain.CurrentDomain.BaseDirectory + "common_msgs/";
            string outputdir = AppDomain.CurrentDomain.BaseDirectory + "Messages";
            Console.WriteLine("开始生成ROS Messages...\n");
            GenerateHelper.GenerateMsgAndSrv(inputDir, outputdir);
            Console.WriteLine("生成完成");
            Console.ReadLine();
        }
    }

}
