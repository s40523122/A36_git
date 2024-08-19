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

namespace RosSharp_HMI.Controls
{
    internal class sshConn : UserControl
    {
        [Description("圓角半徑"), Category("自訂值")]
        public int Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                SetRegion(checkBox1);
            }
        }
        private int radius = 10;
        private CheckBox checkBox1 = new CheckBox();
        private RichTextBox richTextBox1 = new RichTextBox();
        Panel panel;

        public sshConn() 
        {
            checkBox1.FlatAppearance.MouseDownBackColor = Color.FromArgb(14, 41, 92);
            checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            panel = new Panel() { BackColor = Color.FromArgb(86, 89, 97), Width = 30};
            checkBox1.Controls.Add(panel);
            panel.Dock = DockStyle.Left;


            //checkBox1.BackColorChanged += SshConn_BackColorChanged;
            checkBox1.CheckedChanged += SshConn_CheckedChanged;
            checkBox1.SizeChanged += SshConn_SizeChanged;

        }

        private void SshConn_SizeChanged(object sender, EventArgs e)
        {
            SetRegion(checkBox1);
        }

        private void SshConn_CheckedChanged(object sender, EventArgs e)
        {
            panel.BackColor = checkBox1.Checked ? Color.FromArgb(37, 250, 51) : Color.FromArgb(86, 89, 97);
        }

        private void SshConn_BackColorChanged(object sender, EventArgs e)
        {
            checkBox1.FlatAppearance.CheckedBackColor = BackColor;
        }

        private void SetRegion(dynamic control)
        {
            // 建立 GraphicsPath 物件，定義帶圓角的方形
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddLine(radius, 0, control.Width - radius * 2, 0); // 上邊緣
                path.AddArc(control.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90); // 右上角
                path.AddLine(control.Width, radius, control.Width, control.Height - radius * 2); // 右邊緣
                path.AddArc(control.Width - radius * 2, control.Height - radius * 2, radius * 2, radius * 2, 0, 90); // 右下角
                path.AddLine(control.Width - radius * 2, control.Height, radius, control.Height); // 下邊緣
                path.AddArc(0, control.Height - radius * 2, radius * 2, radius * 2, 90, 90); // 左下角
                path.AddLine(0, control.Height - radius * 2, 0, 0 + radius); // 左邊緣
                path.AddArc(0, 0, radius * 2, radius * 2, 180, 90); // 左上角
                path.CloseFigure(); // 關閉圖形

                control.Region = new Region(path);
            }
        }

        private void InitializeComponent()
        {
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(0, 0);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(150, 60);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(0, 60);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(150, 90);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // sshConn
            // 
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.checkBox1);
            this.Name = "sshConn";
            this.ResumeLayout(false);

        }
    }
}
