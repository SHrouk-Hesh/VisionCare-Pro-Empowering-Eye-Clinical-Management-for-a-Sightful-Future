using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Eye_Managment_System_Front
{
    public partial class Eye_Specification : Form
    {
        public Eye_Specification()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void OptometristLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            Process.Start("https://www.aao.org/eye-health/tips-prevention/what-is-ophthalmologist");

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(" https://www.edmundoptics.com/knowledge-center/application-notes/optics/understanding-optical-specifications/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.lensnspecks.com/ophthalmology");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Patient_View_Home Obj = new Patient_View_Home();
            Obj.Show();
            this.Hide();
        }
    }
}
