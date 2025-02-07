using RosSharp_HMI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;


namespace RosSharp_HMI
{

    public partial class Form1 : iCAPS.Form1
    {
        public Form1()
        {
            InitializeComponent();
            FormClosed += Form1_FormClosed;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            RosSharp_Tool.Close_ROS();
        }
    }

}
