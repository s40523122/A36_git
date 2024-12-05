using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace RosSharp_HMI.Controls
{
    public partial class GroupBoxForm : GroupBox
    {
        //[Description("groupbox 文字的字型。"), Category("自訂值")]
        //public Font GroupBoxFont 
        //{ 
        //    get 
        //    {
        //        return groupBox1.Font;
        //    }
        //    set
        //    {
        //        groupBox1.Font = value;
        //    }
        //}

        //[Description("groupbox 文字的字體顏色。"), Category("自訂值")]
        //public Color GroupBoxForeColor
        //{
        //    get
        //    {
        //        return groupBox1.ForeColor;
        //    }
        //    set
        //    {
        //        groupBox1.ForeColor = value;
        //    }
        //}

        //[Description("groupbox 標題文字內容。"), Category("自訂值")]
        //public string GroupBoxText
        //{
        //    get
        //    {
        //        return groupBox1.Text;
        //    }
        //    set
        //    {
        //        groupBox1.Text = value;
        //    }
        //}


        public GroupBoxForm()
        {
            InitializeComponent();
            
            Size = new Size(496, 309);
            Cursor = Cursors.SizeAll;

            pictureBox1.Size = new Size(24, 24);
            pictureBox1.Left = Width - 35;
            pictureBox1.Cursor = Cursors.Hand;
            
            Controls.Add(pictureBox1);

            MouseDown += Drag_MouseDown;
            MouseMove += Drag_MouseMove;
            DoubleClick += Drag_DoubleClick;
            SizeChanged += GroupBoxForm_SizeChanged;
            pictureBox1.Click += pictureBox1_Click;

        }

        private void GroupBoxForm_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Left = Width - 35;
        }

        private Point mousePoint = new Point();
        private void Drag_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = e.Location;
        }

        private void Drag_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Top += e.Y - mousePoint.Y;
                Left += e.X - mousePoint.X;
            }
        }
        private void Drag_DoubleClick(object sender, EventArgs e)
        {
            BringToFront();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Control control = Controls[1];
            Form sub_page = new Form()
            {
                Text = this.Text,
                Size = this.Size,
                BackColor = Color.FromArgb(33, 35, 44),
                FormBorderStyle = FormBorderStyle.SizableToolWindow,
                Padding = new Padding(10),
                StartPosition = FormStartPosition.CenterScreen
            };
            sub_page.Controls.Add(control);

            sub_page.Show();

            sub_page.FormClosed += Sub_page_FormClosed;
            //sub_page.SizeChanged += Sub_page_SizeChanged;

        }

        //private void Sub_page_SizeChanged(object sender, EventArgs e)
        //{
        //    Form _form = sender as Form;

        //    int width_radio = _form.ClientSize.Width / 16;
        //    int height_radio = _form.ClientSize.Height / 9;

        //    int min_radio = Math.Max(width_radio, height_radio);

        //    _form.ClientSize = new Size(min_radio * 16, min_radio * 9);
        //}

        private void Sub_page_FormClosed(object sender, FormClosedEventArgs e)
        {
            Controls.Add((sender as Form).Controls[0]);
        }


    }

}
