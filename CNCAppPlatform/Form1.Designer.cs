namespace RosSharp_HMI
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sidePanel = new System.Windows.Forms.Panel();
            this.slidePanel = new System.Windows.Forms.Panel();
            this.info = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.menu_1 = new System.Windows.Forms.Button();
            this.menu_2 = new System.Windows.Forms.Button();
            this.menu_3 = new System.Windows.Forms.Button();
            this.menu_4 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.menu_test1 = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.menu_setting = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMini = new System.Windows.Forms.Button();
            this.btnFormControl = new ART_plus.DoubleImg();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btFold = new System.Windows.Forms.PictureBox();
            this.btPower = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.welcome1 = new RosSharp_HMI.Forms.Welcome();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.connStatusLabel = new System.Windows.Forms.Label();
            this.moduleTitle = new System.Windows.Forms.Label();
            this.sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.info)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFormControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btFold)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.SteelBlue;
            this.sidePanel.Controls.Add(this.slidePanel);
            this.sidePanel.Controls.Add(this.info);
            this.sidePanel.Controls.Add(this.flowLayoutPanel1);
            this.sidePanel.Controls.Add(this.tableLayoutPanel2);
            this.sidePanel.Controls.Add(this.panel4);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Margin = new System.Windows.Forms.Padding(4);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(280, 794);
            this.sidePanel.TabIndex = 0;
            // 
            // slidePanel
            // 
            this.slidePanel.BackColor = System.Drawing.Color.DarkOrange;
            this.slidePanel.Location = new System.Drawing.Point(0, 433);
            this.slidePanel.Margin = new System.Windows.Forms.Padding(4);
            this.slidePanel.Name = "slidePanel";
            this.slidePanel.Size = new System.Drawing.Size(11, 100);
            this.slidePanel.TabIndex = 2;
            this.slidePanel.Visible = false;
            // 
            // info
            // 
            this.info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.info.Image = ((System.Drawing.Image)(resources.GetObject("info.Image")));
            this.info.Location = new System.Drawing.Point(4, 464);
            this.info.Margin = new System.Windows.Forms.Padding(4);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(40, 41);
            this.info.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.info.TabIndex = 2;
            this.info.TabStop = false;
            this.info.Visible = false;
            this.info.Click += new System.EventHandler(this.info_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.menu_1);
            this.flowLayoutPanel1.Controls.Add(this.menu_2);
            this.flowLayoutPanel1.Controls.Add(this.menu_3);
            this.flowLayoutPanel1.Controls.Add(this.menu_4);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 140);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(280, 333);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // menu_1
            // 
            this.menu_1.BackColor = System.Drawing.Color.SteelBlue;
            this.menu_1.FlatAppearance.BorderSize = 0;
            this.menu_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.menu_1.ForeColor = System.Drawing.Color.White;
            this.menu_1.Image = ((System.Drawing.Image)(resources.GetObject("menu_1.Image")));
            this.menu_1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_1.Location = new System.Drawing.Point(4, 4);
            this.menu_1.Margin = new System.Windows.Forms.Padding(4);
            this.menu_1.Name = "menu_1";
            this.menu_1.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.menu_1.Size = new System.Drawing.Size(272, 98);
            this.menu_1.TabIndex = 2;
            this.menu_1.Text = "  主程序";
            this.menu_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.menu_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menu_1.UseVisualStyleBackColor = false;
            // 
            // menu_2
            // 
            this.menu_2.BackColor = System.Drawing.Color.SteelBlue;
            this.menu_2.FlatAppearance.BorderSize = 0;
            this.menu_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.menu_2.ForeColor = System.Drawing.Color.White;
            this.menu_2.Image = ((System.Drawing.Image)(resources.GetObject("menu_2.Image")));
            this.menu_2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_2.Location = new System.Drawing.Point(4, 110);
            this.menu_2.Margin = new System.Windows.Forms.Padding(4);
            this.menu_2.Name = "menu_2";
            this.menu_2.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.menu_2.Size = new System.Drawing.Size(272, 98);
            this.menu_2.TabIndex = 2;
            this.menu_2.Text = "    socket 測試";
            this.menu_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.menu_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menu_2.UseVisualStyleBackColor = false;
            // 
            // menu_3
            // 
            this.menu_3.BackColor = System.Drawing.Color.SteelBlue;
            this.menu_3.FlatAppearance.BorderSize = 0;
            this.menu_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_3.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.menu_3.ForeColor = System.Drawing.Color.White;
            this.menu_3.Image = ((System.Drawing.Image)(resources.GetObject("menu_3.Image")));
            this.menu_3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_3.Location = new System.Drawing.Point(4, 216);
            this.menu_3.Margin = new System.Windows.Forms.Padding(4);
            this.menu_3.Name = "menu_3";
            this.menu_3.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.menu_3.Size = new System.Drawing.Size(272, 98);
            this.menu_3.TabIndex = 2;
            this.menu_3.Text = "   姿態設定";
            this.menu_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.menu_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menu_3.UseVisualStyleBackColor = false;
            // 
            // menu_4
            // 
            this.menu_4.BackColor = System.Drawing.Color.SteelBlue;
            this.menu_4.FlatAppearance.BorderSize = 0;
            this.menu_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_4.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.menu_4.ForeColor = System.Drawing.Color.White;
            this.menu_4.Image = ((System.Drawing.Image)(resources.GetObject("menu_4.Image")));
            this.menu_4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_4.Location = new System.Drawing.Point(4, 322);
            this.menu_4.Margin = new System.Windows.Forms.Padding(4);
            this.menu_4.Name = "menu_4";
            this.menu_4.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.menu_4.Size = new System.Drawing.Size(272, 98);
            this.menu_4.TabIndex = 2;
            this.menu_4.Text = " ssh設定";
            this.menu_4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.menu_4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menu_4.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.menu_test1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnHome, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.menu_setting, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 473);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(280, 321);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // menu_test1
            // 
            this.menu_test1.BackColor = System.Drawing.Color.SteelBlue;
            this.menu_test1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menu_test1.FlatAppearance.BorderSize = 0;
            this.menu_test1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_test1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.menu_test1.ForeColor = System.Drawing.Color.White;
            this.menu_test1.Image = ((System.Drawing.Image)(resources.GetObject("menu_test1.Image")));
            this.menu_test1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_test1.Location = new System.Drawing.Point(4, 5);
            this.menu_test1.Margin = new System.Windows.Forms.Padding(4);
            this.menu_test1.Name = "menu_test1";
            this.menu_test1.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.menu_test1.Size = new System.Drawing.Size(272, 98);
            this.menu_test1.TabIndex = 2;
            this.menu_test1.Text = "  PLC 讀寫測試";
            this.menu_test1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.menu_test1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menu_test1.UseVisualStyleBackColor = false;
            this.menu_test1.Visible = false;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.SteelBlue;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(4, 219);
            this.btnHome.Margin = new System.Windows.Forms.Padding(4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.btnHome.Size = new System.Drawing.Size(272, 98);
            this.btnHome.TabIndex = 4;
            this.btnHome.Text = "  返回主頁";
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHome.UseVisualStyleBackColor = false;
            // 
            // menu_setting
            // 
            this.menu_setting.BackColor = System.Drawing.Color.SteelBlue;
            this.menu_setting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menu_setting.FlatAppearance.BorderSize = 0;
            this.menu_setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_setting.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.menu_setting.ForeColor = System.Drawing.Color.White;
            this.menu_setting.Image = ((System.Drawing.Image)(resources.GetObject("menu_setting.Image")));
            this.menu_setting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_setting.Location = new System.Drawing.Point(4, 112);
            this.menu_setting.Margin = new System.Windows.Forms.Padding(4);
            this.menu_setting.Name = "menu_setting";
            this.menu_setting.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.menu_setting.Size = new System.Drawing.Size(272, 98);
            this.menu_setting.TabIndex = 4;
            this.menu_setting.Text = " 設定";
            this.menu_setting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menu_setting.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(280, 140);
            this.panel4.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(0, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(347, 47);
            this.label2.TabIndex = 3;
            this.label2.Text = "  智慧電腦輔助生產系統";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(0, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(347, 75);
            this.label3.TabIndex = 4;
            this.label3.Text = "iCAPS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.Controls.Add(this.btnMini);
            this.panel2.Controls.Add(this.btnFormControl);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btFold);
            this.panel2.Controls.Add(this.btPower);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(280, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1040, 57);
            this.panel2.TabIndex = 1;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_title_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_title_MouseMove);
            // 
            // btnMini
            // 
            this.btnMini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMini.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMini.BackgroundImage")));
            this.btnMini.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMini.FlatAppearance.BorderSize = 0;
            this.btnMini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMini.Location = new System.Drawing.Point(872, 12);
            this.btnMini.Margin = new System.Windows.Forms.Padding(4);
            this.btnMini.Name = "btnMini";
            this.btnMini.Size = new System.Drawing.Size(39, 36);
            this.btnMini.TabIndex = 6;
            this.btnMini.UseVisualStyleBackColor = true;
            this.btnMini.Click += new System.EventHandler(this.btnMini_Click);
            // 
            // btnFormControl
            // 
            this.btnFormControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFormControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFormControl.Change = false;
            this.btnFormControl.Image = ((System.Drawing.Image)(resources.GetObject("btnFormControl.Image")));
            this.btnFormControl.Location = new System.Drawing.Point(935, 12);
            this.btnFormControl.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormControl.Name = "btnFormControl";
            this.btnFormControl.SetSquare = true;
            this.btnFormControl.Size = new System.Drawing.Size(31, 31);
            this.btnFormControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnFormControl.SubImg = ((System.Drawing.Image)(resources.GetObject("btnFormControl.SubImg")));
            this.btnFormControl.TabIndex = 5;
            this.btnFormControl.TabStop = false;
            this.btnFormControl.Tag = ((object)(resources.GetObject("btnFormControl.Tag")));
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1040, 1);
            this.panel3.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(57, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "State Monitor App";
            // 
            // btFold
            // 
            this.btFold.Image = ((System.Drawing.Image)(resources.GetObject("btFold.Image")));
            this.btFold.Location = new System.Drawing.Point(23, 16);
            this.btFold.Margin = new System.Windows.Forms.Padding(4);
            this.btFold.Name = "btFold";
            this.btFold.Size = new System.Drawing.Size(27, 27);
            this.btFold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btFold.TabIndex = 2;
            this.btFold.TabStop = false;
            // 
            // btPower
            // 
            this.btPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPower.FlatAppearance.BorderSize = 0;
            this.btPower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPower.Image = ((System.Drawing.Image)(resources.GetObject("btPower.Image")));
            this.btPower.Location = new System.Drawing.Point(999, 16);
            this.btPower.Margin = new System.Windows.Forms.Padding(4);
            this.btPower.Name = "btPower";
            this.btPower.Size = new System.Drawing.Size(27, 27);
            this.btPower.TabIndex = 0;
            this.btPower.UseVisualStyleBackColor = true;
            this.btPower.Click += new System.EventHandler(this.btPower_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(44)))));
            this.panel1.Controls.Add(this.welcome1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(280, 162);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1040, 632);
            this.panel1.TabIndex = 5;
            // 
            // welcome1
            // 
            this.welcome1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(35)))), ((int)(((byte)(44)))));
            this.welcome1.Location = new System.Drawing.Point(40, 31);
            this.welcome1.Margin = new System.Windows.Forms.Padding(5);
            this.welcome1.Name = "welcome1";
            this.welcome1.Size = new System.Drawing.Size(683, 529);
            this.welcome1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(280, 161);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1040, 1);
            this.panel5.TabIndex = 44;
            // 
            // connStatusLabel
            // 
            this.connStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.connStatusLabel.AutoSize = true;
            this.connStatusLabel.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.connStatusLabel.Location = new System.Drawing.Point(951, 90);
            this.connStatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.connStatusLabel.Name = "connStatusLabel";
            this.connStatusLabel.Size = new System.Drawing.Size(231, 34);
            this.connStatusLabel.TabIndex = 43;
            this.connStatusLabel.Text = "連線狀態：未連接";
            // 
            // moduleTitle
            // 
            this.moduleTitle.AutoSize = true;
            this.moduleTitle.BackColor = System.Drawing.Color.Black;
            this.moduleTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.moduleTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moduleTitle.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.moduleTitle.ForeColor = System.Drawing.Color.White;
            this.moduleTitle.Location = new System.Drawing.Point(280, 57);
            this.moduleTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.moduleTitle.Name = "moduleTitle";
            this.moduleTitle.Padding = new System.Windows.Forms.Padding(27);
            this.moduleTitle.Size = new System.Drawing.Size(397, 104);
            this.moduleTitle.TabIndex = 42;
            this.moduleTitle.Text = "設備狀態監控App";
            this.moduleTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1320, 794);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.connStatusLabel);
            this.Controls.Add(this.moduleTitle);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.sidePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "狀態監控App";
            this.sidePanel.ResumeLayout(false);
            this.sidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.info)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFormControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btFold)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox btFold;
        private System.Windows.Forms.Button menu_test1;
        private System.Windows.Forms.Panel slidePanel;
        private System.Windows.Forms.Button menu_1;
        private System.Windows.Forms.PictureBox info;
        private System.Windows.Forms.Button btPower;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label connStatusLabel;
        private System.Windows.Forms.Label moduleTitle;
        private System.Windows.Forms.Button menu_3;
        private System.Windows.Forms.Button menu_2;
        private ART_plus.DoubleImg btnFormControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button menu_setting;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnMini;
        private System.Windows.Forms.Button menu_4;
        private Forms.Welcome welcome1;
    }
}

