using RosSharp_HMI.Services;
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
    public partial class SshControl : UserControl
    {
        [Description("執行命令。"), Category("自訂值")]
        public string Command
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        [Description("是否允許更改執行命令。"), Category("自訂值")]
        public bool LockCommand
        {
            get { return _lock_command; }
            set 
            { 
                _lock_command = value; 
                textBox1.Enabled = !value;
            }
        }
        private bool _lock_command = false;

        [Description("成功運行關鍵字。"), Category("自訂值")]
        public string Executed_key {
            get { return _exec_key; }
            set { _exec_key = value; }
        }
        private string _exec_key = "/rosout";

        [Description("中斷關鍵字。"), Category("自訂值")]
        public string Interrupt_key
        {
            get { return _intr_key; }
            set { _intr_key = value; }
        }
        private string _intr_key = "done";

        SSh_Tool core_ssh;

        public SshControl()
        {
            InitializeComponent();
        }

        private void scaleButton1_FontChanged(object sender, EventArgs e)
        {
            textBox1.Font = new Font(scaleButton1.Font.FontFamily, scaleButton1.Font.Height * 0.7f, scaleButton1.Font.Style);
        }

        private async void scaleButton1_Click(object sender, EventArgs e)
        {
            string input_command = textBox1.Text;

            // 若出現 sudo ，自動帶入密碼。
            if (input_command.StartsWith("sudo")){
                input_command = input_command.Replace("sudo", "sudo -S");
                input_command += $"<<< {ConnectionConfiguration.pass_word}";
            }

            if (core_ssh == null)
            {
                core_ssh = new SSh_Tool()
                {
                    Host = ConnectionConfiguration.remote_ip,
                    Username = ConnectionConfiguration.user_name,
                    Password = ConnectionConfiguration.pass_word,
                    Command = input_command,
                    Executed_key = _exec_key,
                    Interrupt_key = _intr_key
                };

                // richTextBox1.TextChanged += RichTextBox1_TextChanged;
                scaleButton2.Enabled = true;

                await core_ssh.Execute(richTextBox1);
            }
            else
            {
                core_ssh.Send_command(input_command);
            }
        }
        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            // 設定 ssh 命令執行/中止時的文字顯示
            scaleButton1.Text = core_ssh.Interrupt ? "執行" : "停止";
        }

        private void scaleButton2_Click(object sender, EventArgs e)
        {
            core_ssh.Send_interrupt();
        }
    }
}
