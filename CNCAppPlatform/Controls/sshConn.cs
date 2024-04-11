using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNCAppPlatform.Controls
{
    public partial class sshConn : UserControl
    {
        public sshConn()
        {
            //checkBox1.Image = checkBox1.LinkImage;
            InitializeComponent();

            checkBox1.BackColorChanged += checkBox1_BackColorChanged;
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
        }

        private void checkBox1_BackColorChanged(object sender, EventArgs e)
        {
            checkBox1.FlatAppearance.CheckedBackColor = BackColor;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Image = checkBox1.Checked ? checkBox1.LinkImage : checkBox1.BrokenLinkImage;
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

        private partial class MyCheckBox : CheckBox
        {
            [Description("鎖鏈圖片。"), Category("自訂值")]
            public Image LinkImage { get;  set; } = null;

            [Description("斷開鎖鏈圖片。"), Category("自訂值")]
            public Image BrokenLinkImage { get; set; } = null;
        }
    }
}
