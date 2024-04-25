namespace CNCAppPlatform.Controls
{
    partial class RosRemoteConnectBtn
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RosRemoteConnectBtn));
            this.checkBox1 = new CNCAppPlatform.Controls.RosRemoteConnectBtn.MyCheckBox();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.BrokenLinkImage = ((System.Drawing.Image)(resources.GetObject("checkBox1.BrokenLinkImage")));
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox1.FlatAppearance.BorderSize = 0;
            this.checkBox1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(41)))), ((int)(((byte)(92)))));
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Image = ((System.Drawing.Image)(resources.GetObject("checkBox1.Image")));
            this.checkBox1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBox1.LinkImage = ((System.Drawing.Image)(resources.GetObject("checkBox1.LinkImage")));
            this.checkBox1.Location = new System.Drawing.Point(0, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.checkBox1.Size = new System.Drawing.Size(168, 84);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "    bcheckBox1";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // RosRemoteConnectBtn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox1);
            this.Name = "RosRemoteConnectBtn";
            this.Size = new System.Drawing.Size(168, 84);
            this.ResumeLayout(false);

        }

        #endregion

        private MyCheckBox checkBox1;
    }
}
