using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eye_Managment_System_Front
{
    public partial class Profile_Picture_Patient : Form
    {
        public Profile_Picture_Patient()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Patient_View_Home Obj = new Patient_View_Home();
            Obj.Show();
            this.Hide();
        }
    }
}
