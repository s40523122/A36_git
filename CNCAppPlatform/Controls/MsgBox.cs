using LiveCharts.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RosSharp_HMI.Controls
{
    public partial class MsgBox : Form
    {
        public Form backForm;
        public MsgBox()
        {
            InitializeComponent();

            backForm = new Form()
            {
                StartPosition = FormStartPosition.Manual,
                FormBorderStyle = FormBorderStyle.None,
                Opacity = .65d,
                BackColor = Color.Black,
                //WindowState = FormWindowState.Maximized,
                Size = Form1.FormSize,
                TopMost = true,
                Location = Form1.FormLocation,
                ShowInTaskbar = false,
            };
            //if (!System.Diagnostics.Debugger.IsAttached) backForm.Show();
            backForm.Show();

            TopMost = true;
            
            FormBorderStyle = FormBorderStyle.None;
            Width = Form1.FormSize.Width;
            int calcHeight = Form1.FormSize.Height / 3;
            Height = calcHeight < 380 ? calcHeight : 380;
            Location = new Point(Form1.FormLocation.X , Form1.FormLocation.Y + (Form1.FormSize.Height - Height) / 2);
            //Anchor = AnchorStyles.None;
        }

        public static void Show(string msg, string title = "Message")
        {
            RosSharp_HMI.Controls.MsgBox thisform = new RosSharp_HMI.Controls.MsgBox();
            thisform.label1.Text = title;
            thisform.richTextBox1.Text = msg;
            thisform.ShowDialog();
            thisform.backForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
