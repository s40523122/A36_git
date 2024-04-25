namespace CNCAppPlatform
{
    partial class Control
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tag0 = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tag1 = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tag2 = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.rosConn1 = new CNCAppPlatform.Controls.RosRemoteConnectBtn();
            this.sshConn1 = new CNCAppPlatform.Controls.sshConn1();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(16)))), ((int)(((byte)(22)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 626);
            this.panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(223, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(16)))), ((int)(((byte)(22)))));
            this.button1.Location = new System.Drawing.Point(355, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(476, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tag0);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(223, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 203);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tag_0";
            // 
            // tag0
            // 
            this.tag0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(44)))), ((int)(((byte)(53)))));
            this.tag0.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tag0.Location = new System.Drawing.Point(9, 35);
            this.tag0.Name = "tag0";
            this.tag0.Size = new System.Drawing.Size(161, 147);
            this.tag0.TabIndex = 0;
            this.tag0.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tag1);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(418, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 203);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tag_1";
            // 
            // tag1
            // 
            this.tag1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(44)))), ((int)(((byte)(53)))));
            this.tag1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tag1.Location = new System.Drawing.Point(6, 35);
            this.tag1.Name = "tag1";
            this.tag1.Size = new System.Drawing.Size(164, 147);
            this.tag1.TabIndex = 0;
            this.tag1.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tag2);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(222, 305);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(176, 203);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tag_2";
            // 
            // tag2
            // 
            this.tag2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(44)))), ((int)(((byte)(53)))));
            this.tag2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tag2.Location = new System.Drawing.Point(9, 35);
            this.tag2.Name = "tag2";
            this.tag2.Size = new System.Drawing.Size(161, 147);
            this.tag2.TabIndex = 0;
            this.tag2.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.richTextBox4);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(418, 305);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(176, 203);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tag_3";
            // 
            // richTextBox4
            // 
            this.richTextBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(44)))), ((int)(((byte)(53)))));
            this.richTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox4.Location = new System.Drawing.Point(9, 35);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(161, 147);
            this.richTextBox4.TabIndex = 0;
            this.richTextBox4.Text = "";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(16)))), ((int)(((byte)(22)))));
            this.button2.Location = new System.Drawing.Point(588, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 50);
            this.button2.TabIndex = 5;
            this.button2.Text = "roscore";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(16)))), ((int)(((byte)(22)))));
            this.button3.Location = new System.Drawing.Point(667, 11);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 50);
            this.button3.TabIndex = 6;
            this.button3.Text = "dis";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(44)))), ((int)(((byte)(53)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(614, 90);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(376, 255);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1013, 172);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(164, 70);
            this.button4.TabIndex = 10;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1013, 270);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(167, 75);
            this.button5.TabIndex = 11;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // rosConn1
            // 
            this.rosConn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(16)))), ((int)(((byte)(22)))));
            this.rosConn1.Content = "realsense";
            this.rosConn1.ContentFont = new System.Drawing.Font("微軟正黑體", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rosConn1.Font = new System.Drawing.Font("微軟正黑體", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rosConn1.Location = new System.Drawing.Point(681, 392);
            this.rosConn1.Margin = new System.Windows.Forms.Padding(0);
            this.rosConn1.Name = "rosConn1";
            this.rosConn1.Radius = 10;
            this.rosConn1.Size = new System.Drawing.Size(177, 60);
            this.rosConn1.TabIndex = 9;
            // 
            // sshConn1
            // 
            this.sshConn1.Appearance = System.Windows.Forms.Appearance.Button;
            this.sshConn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(16)))), ((int)(((byte)(22)))));
            this.sshConn1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(16)))), ((int)(((byte)(22)))));
            this.sshConn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sshConn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sshConn1.Location = new System.Drawing.Point(771, 11);
            this.sshConn1.Name = "sshConn1";
            this.sshConn1.Radius = 10;
            this.sshConn1.Size = new System.Drawing.Size(193, 50);
            this.sshConn1.TabIndex = 8;
            this.sshConn1.Text = "roscore";
            this.sshConn1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sshConn1.UseVisualStyleBackColor = false;
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(1284, 626);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.rosConn1);
            this.Controls.Add(this.sshConn1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Control";
            this.Text = "Setting";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox tag0;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox tag1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox tag2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private Controls.sshConn1 sshConn1;
        private Controls.RosRemoteConnectBtn rosConn1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}