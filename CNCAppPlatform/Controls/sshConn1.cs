using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace CNCAppPlatform.Controls
{
    internal class sshConn1 : CheckBox
    {
        [Description("圓角半徑"), Category("自訂值")]
        public int Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                SetRegion();
            }
        }
        private int radius = 10;

        Panel panel;

        public sshConn1() 
        {
            Appearance = Appearance.Button;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.MouseDownBackColor = Color.FromArgb(14, 41, 92);
            
            AutoSize = false;
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            panel = new Panel() { BackColor = Color.FromArgb(37, 250, 51), Width = 30};
            Controls.Add(panel);
            panel.Dock = DockStyle.Left;
            

            BackColorChanged += SshConn_BackColorChanged;
            CheckedChanged += SshConn_CheckedChanged;
            SizeChanged += SshConn_SizeChanged;

        }

        private void SshConn_SizeChanged(object sender, EventArgs e)
        {
            SetRegion();
        }

        private void SshConn_CheckedChanged(object sender, EventArgs e)
        {
            panel.BackColor = Checked? Color.FromArgb(37, 250, 51) : Color.FromArgb(86, 89, 97);
        }

        private void SshConn_BackColorChanged(object sender, EventArgs e)
        {
            FlatAppearance.CheckedBackColor = BackColor;
        }

        private void SetRegion()
        {
            // 建立 GraphicsPath 物件，定義帶圓角的方形
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddLine(radius, 0, Width - radius * 2, 0); // 上邊緣
                path.AddArc(Width - radius * 2, 0, radius * 2, radius * 2, 270, 90); // 右上角
                path.AddLine(Width, radius, Width, Height - radius * 2); // 右邊緣
                path.AddArc(Width - radius * 2, Height - radius * 2, radius * 2, radius * 2, 0, 90); // 右下角
                path.AddLine(Width - radius * 2, Height, radius, Height); // 下邊緣
                path.AddArc(0, Height - radius * 2, radius * 2, radius * 2, 90, 90); // 左下角
                path.AddLine(0, Height - radius * 2, 0, 0 + radius); // 左邊緣
                path.AddArc(0, 0, radius * 2, radius * 2, 180, 90); // 左上角
                path.CloseFigure(); // 關閉圖形

                Region = new Region(path);
            }
        }
    }
}
