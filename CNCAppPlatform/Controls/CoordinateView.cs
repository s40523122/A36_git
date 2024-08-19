using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RosSharp_HMI.Controls
{
    class CoordinateView : Panel
    {
        private Color[] lineColors = new Color[6];

        public CoordinateView()
        {
            // 設置6條線的預設顏色
            //lineColors[0] = Color.Red;
            //lineColors[1] = Color.Green;
            //lineColors[2] = Color.Blue;
            //lineColors[3] = Color.Orange;
            //lineColors[4] = Color.Purple;
            //lineColors[5] = Color.Yellow;

            SetAxis(new List<float>() { 1, 0, 0 }, Color.Red);
            SetAxis(new List<float>() { 0, 1, 0 }, Color.Green);
            SetAxis(new List<float>() { 0, 0, 1 }, Color.Blue);
            BackColor = Color.Black;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawStar(e.Graphics);
        }

        private void DrawStar(Graphics graphics)
        {
            int centerX = this.Width / 2;
            int centerY = this.Height / 2;
            int radius = Math.Min(this.Width, this.Height) * 4 / 5 / 2;

            for (int i = 0; i < 6; i++)
            {
                // 起始角度設定為90度，第一條線垂直向下
                double angle = (i * 60 + 90) * Math.PI / 180;
                int x = centerX + (int)(radius * Math.Cos(angle));
                int y = centerY + (int)(radius * Math.Sin(angle));

                using (Pen pen = new Pen(lineColors[i], 4)) // 每條線使用不同顏色和粗細
                {
                    graphics.DrawLine(pen, centerX, centerY, x, y);
                }
            }
        }

        /// <summary>
        /// 方法用來設置線條的顏色
        /// </summary>
        /// <param name="axisIndex">XYZ軸編號 (X: 0, Y: 1, Z: 2)</param>
        /// <param name="direction">軸向 (1: 正向, -1: 反向)</param>
        /// <param name="color"></param>
        public void SetLineColor(int axisIndex, int direction, Color color)
        {
            switch (axisIndex)
            {
                case 0:
                    if (direction == 1)
                    {
                        lineColors[5] = color;
                        lineColors[2] = Color.Black;
                    }
                    else if (direction == -1)
                    {
                        lineColors[5] = Color.Black;
                        lineColors[2] = color;
                    }
                    return;

                case 1:
                    if (direction == 1)
                    {
                        lineColors[4] = color;
                        lineColors[1] = Color.Black;
                    }
                    else if (direction == -1)
                    {
                        lineColors[4] = Color.Black;
                        lineColors[1] = color;
                    }
                    return;

                case 2:
                    if (direction == 1)
                    {
                        lineColors[3] = color;
                        lineColors[0] = Color.Black;
                    }
                    else if (direction == -1)
                    {
                        lineColors[3] = Color.Black;
                        lineColors[0] = color;
                    }
                    return;

                default:
                    this.Invalidate(); // 重繪控制項
                    return;
            }
        }

        public void SetAxis(List<float> matrix3x1, Color color)
        {
            for (int i=0; i<3; i++)
            {
                if (matrix3x1[i] > 0.5)
                {
                    SetLineColor(i, 1, color);
                    return;
                }
                else if (matrix3x1[i] < -0.5)
                {
                    SetLineColor(i, -1, color);
                    return;
                }
            }
        }
    }

}
