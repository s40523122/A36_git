using System;
using System.Drawing;
using System.Windows.Forms;

namespace JinToolkit
{
    public partial class GroupBoxForm : GroupBox
    {
        public GroupBoxForm()
        {
            InitializeComponent();
            
            // 主窗體設定
            Size = new Size(496, 309);
            Cursor = Cursors.SizeAll;

            // 彈出視窗按鈕設定
            pictureBox1.Size = new Size(24, 24);
            pictureBox1.Left = Width - 35;
            pictureBox1.Cursor = Cursors.Hand;
            
            Controls.Add(pictureBox1);

            // 設定主窗體可拖曳
            MouseDown += Drag_MouseDown;
            MouseMove += Drag_MouseMove;
            // 設定雙擊後，移動至最上方
            DoubleClick += Drag_DoubleClick;

            // 設定彈出視窗動作
            pictureBox1.Click += pictureBox1_Click;

            SizeChanged += GroupBoxForm_SizeChanged;
        }

        private void GroupBoxForm_SizeChanged(object sender, EventArgs e)
        {
            // 需加入 SizeChanged 動作，否則當控制項加入後，窗體設計會回歸初始化設定( 尺寸未修改前 )
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
            Form sub_page = new Form()
            {
                Text = this.Text,
                ClientSize = this.Size,
                BackColor = Color.FromArgb(33, 35, 44),
                FormBorderStyle = FormBorderStyle.SizableToolWindow,
                Padding = new Padding(10),
                StartPosition = FormStartPosition.CenterScreen,
                TopMost = true
            };
            sub_page.Controls.Add(Controls[1]);     // 指定將第2個控制項加入彈出式視窗，第一個是開啟按鈕

            pictureBox1.Visible = false;        // 隱藏按鈕

            sub_page.Show();

            sub_page.FormClosed += Sub_page_FormClosed;
        }

        private void Sub_page_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 關閉視窗後，將控制項歸還原位
            Controls.Add((sender as Form).Controls[0]);

            pictureBox1.Visible = true;     // 顯示按鈕
        }
    }

}
