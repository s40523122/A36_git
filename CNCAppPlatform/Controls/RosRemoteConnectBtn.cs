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

namespace CNCAppPlatform.Controls
{
    public partial class RosRemoteConnectBtn : UserControl
    {
        [Description("控制項邊緣圓角的半徑。"), Category("自訂值")]
        public int Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                //SetRegion(path => Region = new Region(path));
            }
        }
        private int radius = 10;


        [Description("與控制項關聯的文字。"), Category("自訂值")]
        public string Content
        {
            get { return checkBox1.Text.TrimStart(); }
            set{ checkBox1.Text = "  " + value; }
        }

        [Description("用來顯示控制項文字的字型。"), Category("自訂值")]
        public Font ContentFont
        {
            get { return checkBox1.Font; }
            set { checkBox1.Font = value; }
        }

        public string Command
        {
            get
            {
                return checkBox1.Checked ? Content : Content + "_cancle";
            }
        }

        Color BORDER_COLOR = Color.Gray;

        private Image LinkImage = null;
        private Image BrokenLinkImage = null;


        public RosRemoteConnectBtn()
        {
            //checkBox1.Image = checkBox1.LinkImage;
            InitializeComponent();

            checkBox1.BackColorChanged += checkBox1_BackColorChanged;
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
            SizeChanged += SshConn_SizeChanged;
            checkBox1.Paint += CheckBox1_Paint;
        }

        private void RosRemoteConnectBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Command);
        }

        private void CheckBox1_Paint(object sender, PaintEventArgs e)
        {
            SetRegion(path => e.Graphics.DrawPath(new Pen(BORDER_COLOR, 4), path), 2);
        }

        private void checkBox1_BackColorChanged(object sender, EventArgs e)
        {
            checkBox1.FlatAppearance.CheckedBackColor = BackColor;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Image = checkBox1.Checked ? LinkImage : BrokenLinkImage;
            BORDER_COLOR = checkBox1.Checked ? Color.FromArgb(37, 250, 51) : Color.Gray;
            Refresh();
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

        private void SshConn_SizeChanged(object sender, EventArgs e)
        {
            SetRegion(path => Region = new Region(path));
            LinkImage = ResizeImage(checkBox1.LinkImage, this.Height/2);
            checkBox1.Image = BrokenLinkImage = ResizeImage(checkBox1.BrokenLinkImage, this.Height/2);
            Refresh();
        }

        private void SetRegion(Action<GraphicsPath> action, int padding = 0)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddLine(radius + padding, padding, Width - radius * 2 - padding, padding); // 上邊緣
                path.AddArc(Width - radius * 2 - padding, padding, radius * 2, radius * 2, 270, 90); // 右上角
                path.AddLine(Width - padding, radius + padding, Width - padding, Height - radius * 2 - padding); // 右邊緣
                path.AddArc(Width - radius * 2 - padding, Height - radius * 2 - padding, radius * 2, radius * 2, 0, 90); // 右下角
                path.AddLine(Width - radius * 2 - padding, Height - padding, radius + padding, Height - padding); // 下邊緣
                path.AddArc(padding, Height - radius * 2 - padding, radius * 2, radius * 2, 90, 90); // 左下角
                path.AddLine(padding, Height - radius * 2 - padding, padding, radius + padding); // 左邊緣
                path.AddArc(padding, padding, radius * 2, radius * 2, 180, 90); // 左上角
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
}
