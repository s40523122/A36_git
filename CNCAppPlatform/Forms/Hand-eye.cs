using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace RosSharp_HMI
{
    public partial class Hand_eye : Form
    {

        Matrix4x4 handMatrix = Matrix4x4.CreateRotationX(0);
        Matrix4x4 eyeMatrix = Matrix4x4.CreateRotationX(0);

        public Hand_eye()
        {
            InitializeComponent();

            // 設定旋轉角度（以度為單位）
            float pitch = 90.0f; // 俯仰角（繞X軸）
            float yaw = 0.0f;   // 航向角（繞Y軸）
            float roll = 90.0f;  // 滾轉角（繞Z軸）

            // 轉換為弳度
            float pitchRad = (float)Math.PI * pitch / 180.0f;
            float yawRad = (float)Math.PI * yaw / 180.0f;
            float rollRad = (float)Math.PI * roll / 180.0f;
            float nine = (float)Math.PI / 2;

            // 計算每個旋轉的矩陣
            Matrix4x4 rollMatrix = Matrix4x4.CreateRotationZ(rollRad);   // 滾轉角
            Matrix4x4 yawMatrix = Matrix4x4.CreateRotationY(yawRad);     // 航向角
            Matrix4x4 pitchMatrix = Matrix4x4.CreateRotationX(pitchRad); // 俯仰角

            

            // 合併矩陣：Roll → Yaw → Pitch
            Matrix4x4 rotationMatrix = Matrix4x4.Multiply(pitchMatrix, Matrix4x4.Multiply(yawMatrix, rollMatrix));
            //rotationMatrix = Matrix4x4.Multiply(ninehMatrix, rotationMatrix);
            // 顯示結果
            Console.WriteLine("旋轉矩陣:");
            List<float> Matrix3x1_X = new List<float>() { rotationMatrix.M11, rotationMatrix.M12, rotationMatrix.M13 };
            List<float> Matrix3x1_Y = new List<float>() { rotationMatrix.M21, rotationMatrix.M22, rotationMatrix.M23 };
            List<float> Matrix3x1_Z = new List<float>() { rotationMatrix.M31, rotationMatrix.M32, rotationMatrix.M33 };

            Console.WriteLine(Matrix3x1_X[0]);
        }

        private void Refresh_Coordination()
        {
            List<float> Matrix3x1_eye_X = new List<float>() { eyeMatrix.M11, eyeMatrix.M12, eyeMatrix.M13 };
            List<float> Matrix3x1_eye_Y = new List<float>() { eyeMatrix.M21, eyeMatrix.M22, eyeMatrix.M23 };
            List<float> Matrix3x1_eye_Z = new List<float>() { eyeMatrix.M31, eyeMatrix.M32, eyeMatrix.M33 };
            
            eye_coordinateView.SetAxis(Matrix3x1_eye_X, Color.Red);
            eye_coordinateView.SetAxis(Matrix3x1_eye_Y, Color.Green);
            eye_coordinateView.SetAxis(Matrix3x1_eye_Z, Color.Blue);
            label2.Text = $"{eyeMatrix.M11.ToString("F0")} {eyeMatrix.M12.ToString("F0")} {eyeMatrix.M13.ToString("F0")}\n{eyeMatrix.M21.ToString("F0")} {eyeMatrix.M22.ToString("F0")} {eyeMatrix.M23.ToString("F0")}\n{eyeMatrix.M31.ToString("F0")} {eyeMatrix.M32.ToString("F0")} {eyeMatrix.M33.ToString("F0")}";
            eye_coordinateView.Invalidate();        // 重繪控制項

            List<float> Matrix3x1_hand_X = new List<float>() { handMatrix.M11, handMatrix.M12, handMatrix.M13 };
            List<float> Matrix3x1_hand_Y = new List<float>() { handMatrix.M21, handMatrix.M22, handMatrix.M23 };
            List<float> Matrix3x1_hand_Z = new List<float>() { handMatrix.M31, handMatrix.M32, handMatrix.M33 };

            hand_coordinateView.SetAxis(Matrix3x1_hand_X, Color.Red);
            hand_coordinateView.SetAxis(Matrix3x1_hand_Y, Color.Green);
            hand_coordinateView.SetAxis(Matrix3x1_hand_Z, Color.Blue);
            label6.Text = $"{handMatrix.M11.ToString("F0")} {handMatrix.M12.ToString("F0")} {handMatrix.M13.ToString("F0")}\n{handMatrix.M21.ToString("F0")} {handMatrix.M22.ToString("F0")} {handMatrix.M23.ToString("F0")}\n{handMatrix.M31.ToString("F0")} {handMatrix.M32.ToString("F0")} {handMatrix.M33.ToString("F0")}";
            hand_coordinateView.Invalidate();        // 重繪控制項


        }

        private void button12_Click(object sender, EventArgs e)
        {
            Matrix4x4 rotMatrix = Matrix4x4.CreateRotationX(1.5707963f); // 正轉 90 度
            eyeMatrix = Matrix4x4.Multiply(rotMatrix, eyeMatrix);
            Refresh_Coordination();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Matrix4x4 rotMatrix = Matrix4x4.CreateRotationX(-1.5707963f); // 反轉 90 度
            eyeMatrix = Matrix4x4.Multiply(rotMatrix, eyeMatrix);
            Refresh_Coordination();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Matrix4x4 rotMatrix = Matrix4x4.CreateRotationY(1.5707963f); // 正轉 90 度
            eyeMatrix = Matrix4x4.Multiply(rotMatrix, eyeMatrix);
            Refresh_Coordination();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Matrix4x4 rotMatrix = Matrix4x4.CreateRotationY(-1.5707963f); // 反轉 90 度
            eyeMatrix = Matrix4x4.Multiply(rotMatrix, eyeMatrix);
            Refresh_Coordination();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Matrix4x4 rotMatrix = Matrix4x4.CreateRotationZ(1.5707963f); // 正轉 90 度
            eyeMatrix = Matrix4x4.Multiply(rotMatrix, eyeMatrix);
            Refresh_Coordination();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Matrix4x4 rotMatrix = Matrix4x4.CreateRotationZ(-1.5707963f); // 反轉 90 度
            eyeMatrix = Matrix4x4.Multiply(rotMatrix, eyeMatrix);
            Refresh_Coordination();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Matrix4x4 rotMatrix = Matrix4x4.CreateRotationX(1.5707963f); // 正轉 90 度
            handMatrix = Matrix4x4.Multiply(rotMatrix, handMatrix);
            Refresh_Coordination();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Matrix4x4 rotMatrix = Matrix4x4.CreateRotationX(-1.5707963f); // 反轉 90 度
            handMatrix = Matrix4x4.Multiply(rotMatrix, handMatrix);
            Refresh_Coordination();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Matrix4x4 rotMatrix = Matrix4x4.CreateRotationY(1.5707963f); // 正轉 90 度
            handMatrix = Matrix4x4.Multiply(rotMatrix, handMatrix);
            Refresh_Coordination();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Matrix4x4 rotMatrix = Matrix4x4.CreateRotationY(-1.5707963f); // 反轉 90 度
            handMatrix = Matrix4x4.Multiply(rotMatrix, handMatrix);
            Refresh_Coordination();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Matrix4x4 rotMatrix = Matrix4x4.CreateRotationZ(1.5707963f); // 正轉 90 度
            handMatrix = Matrix4x4.Multiply(rotMatrix, handMatrix);
            Refresh_Coordination();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Matrix4x4 rotMatrix = Matrix4x4.CreateRotationZ(-1.5707963f); // 反轉 90 度
            handMatrix = Matrix4x4.Multiply(rotMatrix, handMatrix);
            Refresh_Coordination();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Matrix4x4 invert;
            Matrix4x4.Invert(eyeMatrix, out invert);
            Matrix4x4 relateMatrix = Matrix4x4.Multiply(handMatrix, invert);
            label9.Text = $"{relateMatrix.M11.ToString("F0")} {relateMatrix.M12.ToString("F0")} {relateMatrix.M13.ToString("F0")}\n{relateMatrix.M21.ToString("F0")} {relateMatrix.M22.ToString("F0")} {relateMatrix.M23.ToString("F0")}\n{relateMatrix.M31.ToString("F0")} {relateMatrix.M32.ToString("F0")} {relateMatrix.M33.ToString("F0")}";
        }
    }
}
