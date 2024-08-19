using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using RosSharp;
using Messages.topic_tools;
using System.Collections;
using RosSharp_HMI.Services;

namespace RosSharp_HMI.Controls
{
    public partial class RosRemoteConnectBtn : UserControl
    {
        [Description("控制項邊緣圓角的半徑。"), Category("自訂值")]
        public int Radius
        {
            get { return _radius; }
            set
            {
                _radius = value;
                InitializeRegion();
            }
        }
        private int _radius = 10;


        [Description("欲執行的任務名稱。"), Category("自訂值")]
        public string TaskText
        {
            get { return checkBox1.Text.TrimStart(); }
            set{ checkBox1.Text = "  " + value; }
        }

        [Description("用來顯示控制項文字的字型。"), Category("自訂值")]
        public Font CommandTextFont
        {
            get { return checkBox1.Font; }
            set { checkBox1.Font = value; }
        }


        [Description("主體的背景顏色。"), Category("自訂值")]
        public Color BodyColor 
        { 
            get { return checkBox1.BackColor; } 
            set 
            { 
                checkBox1.BackColor = value;
                checkBox1.FlatAppearance.CheckedBackColor = value;
            } 
        }

        [Description("啟動時邊緣的燈色。"), Category("自訂值")]
        public Color ColorEnable { get;set; } = Color.FromArgb(37, 250, 51);

        [Description("關閉時邊緣的燈色。"), Category("自訂值")]
        public Color ColorDisable { get; set; } = Color.Gray;

        [Description("選擇通訊模式"), Category("自訂值")]
        public ConnectEnum ConnectMode { get;set; } = ConnectEnum.Topic;

        private Image LinkImage = null;
        private Image BrokenLinkImage = null;


        public RosRemoteConnectBtn()
        {
            InitializeComponent();

            checkBox1.Click += CheckBox1_Click;
            SizeChanged += UserControl_SizeChanged;
        }

        static void _Main(string[] args)
        {
            IDictionary remappings;
            RemappingHelper.GetRemappings(out remappings);
            Network.Init(remappings);
            Master.Init(remappings);
            ThisNode.Init("", remappings, (int)(InitOption.AnonymousName | InitOption.NoRousout));
            Param.Init(remappings);
            
            //设置参数值
            //Param.set(key, value);
            //Param.del(key)
            Console.ReadKey();
        }

        private async void CheckBox1_Click(object sender, EventArgs e)
        {
            string task_name = checkBox1.Checked ? TaskText : TaskText + "_cancle";     // 當 checked 為 False 時，命令文字後綴加上 "_cancel"
            
            switch (ConnectMode)
            {
                case ConnectEnum.Topic:
                    
                    break;
                
                case ConnectEnum.Parameter:
                    break;

                case ConnectEnum.Service:
                    bool success = await RosSharp_Tool.execute_task_by_service(task_name);
                    if (success)
                    {
                        checkBox1.Image = checkBox1.Checked ? LinkImage : BrokenLinkImage;
                        BackColor = checkBox1.Checked ? ColorEnable : ColorDisable;
                        Refresh();
                    }
                    break;
            }
        }

        private Image ResizeImage(Image image, int sideLength)
        {
            var resizedImage = new Bitmap(sideLength, sideLength);
            using (var graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(image, 0, 0, sideLength, sideLength);
            }
            return resizedImage;
        }

        private void UserControl_SizeChanged(object sender, EventArgs e)
        {
            InitializeRegion();
            LinkImage = ResizeImage(checkBox1.LinkImage, this.Height/2); 
            checkBox1.Image = BrokenLinkImage = ResizeImage(checkBox1.BrokenLinkImage, this.Height/2);
            Refresh();
        }
        private void InitializeRegion()
        {
            SetRegion(bodypath => Region = new Region(bodypath));
            SetRegion(bodypath => checkBox1.Region = new Region(bodypath), 4);
        }

        private void SetRegion(Action<GraphicsPath> action, int padding = 0)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddLine(_radius + padding, padding, Width - _radius * 2 - padding, padding); // 上邊緣
                path.AddArc(Width - _radius * 2 - padding, padding, _radius * 2, _radius * 2, 270, 90); // 右上角
                path.AddLine(Width - padding, _radius + padding, Width - padding, Height - _radius * 2 - padding); // 右邊緣
                path.AddArc(Width - _radius * 2 - padding, Height - _radius * 2 - padding, _radius * 2, _radius * 2, 0, 90); // 右下角
                path.AddLine(Width - _radius * 2 - padding, Height - padding, _radius + padding, Height - padding); // 下邊緣
                path.AddArc(padding, Height - _radius * 2 - padding, _radius * 2, _radius * 2, 90, 90); // 左下角
                path.AddLine(padding, Height - _radius * 2 - padding, padding, _radius + padding); // 左邊緣
                path.AddArc(padding, padding, _radius * 2, _radius * 2, 180, 90); // 左上角
                path.CloseFigure(); // 關閉圖形
                action(path);

            }
        }

        private partial class MyCheckBox : CheckBox
        {
            [Description("鎖鏈圖片。"), Category("自訂值")]
            public Image LinkImage { get;  set; } = null;

            [Description("斷開鎖鏈圖片。"), Category("自訂值")]
            public Image BrokenLinkImage { get; set; } = null;
        }
    }

    /// <summary>
    /// Enum ModeType
    /// </summary>
    public enum ConnectEnum
    {
        Topic,
        Parameter,
        Service
    }
}
