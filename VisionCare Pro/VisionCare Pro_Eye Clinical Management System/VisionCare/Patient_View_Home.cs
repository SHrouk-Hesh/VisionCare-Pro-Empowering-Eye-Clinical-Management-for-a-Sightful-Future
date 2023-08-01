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
    public partial class Patient_View_Home : Form
    {
        public Patient_View_Home()
        {
            InitializeComponent();
        }

        private void Specilbl_Click(object sender, EventArgs e)
        {
            Eye_Specification Obj = new Eye_Specification();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

            Emergy_chat Obj = new Emergy_chat();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Profile_Picture_Patient Obj = new Profile_Picture_Patient();
            Obj.Show();
            this.Hide();


        }
    }
}
