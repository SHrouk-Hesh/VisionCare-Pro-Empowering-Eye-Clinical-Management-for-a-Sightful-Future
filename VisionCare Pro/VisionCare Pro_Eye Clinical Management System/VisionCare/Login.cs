using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Eye_Managment_System_Front
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Connection here
        /// </summary>
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\OneDrive\Documents\ClinicalDb.mdf;Integrated Security=True;Connect Timeout=30");
        public static string Role;
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (RoleCb.SelectedIndex == -1)
            {
                MessageBox.Show("Select Your Position");
            }
            else if (RoleCb.SelectedIndex == 0)
            {

                if (NameTb.Text == "" || PassTb.Text == "")
                {
                    MessageBox.Show("Enter Both Admin Name and Password");
                }
                else if (NameTb.Text == "Admin" && PassTb.Text == "Password")
                {
                    Role = "Admin";
                    Home Obj = new Home();
                    Obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Admin Name and Passord");
                }

            }
            //doctor
            else if (RoleCb.SelectedIndex == 1)
            {

                    if (NameTb.Text == "" || PassTb.Text == "")
                    {
                        MessageBox.Show("Enter Both Doctor Name and Password");
                    }
                    else if (NameTb.Text == "Doctor" && PassTb.Text == "Password")
                    {
                        Role = "Doctor";
                        Doctor_View_Home Obj = new Doctor_View_Home();
                        Obj.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Doctor Name and Passord");
                    }
            }
            //reception
            else if (RoleCb.SelectedIndex == 2)
            {
                if (NameTb.Text == "" || PassTb.Text == "")
                {
                    MessageBox.Show("Enter Both Reception Name and Password");
                }
                else if (NameTb.Text == "Reception" && PassTb.Text == "Password")
                {
                    Role = "Receptionist";
                    Receotionist_View_Home Obj = new Receotionist_View_Home();
                    Obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Receptionist Name and Passord");
                }


            }
            //patient
            else if (RoleCb.SelectedIndex == 3)
            {

                if (NameTb.Text == "" || PassTb.Text == "")
                {
                    MessageBox.Show("Enter Both Patient Name and Password");
                }
                else if (NameTb.Text == "Patient" && PassTb.Text == "Password")
                {
                    Role = "Patient";
                    Patient_View_Home Objp = new Patient_View_Home();
                    Objp.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Patient Name and Passoword");
                }

            }


        }

        private void label4_Click(object sender, EventArgs e)
        {
            RoleCb.SelectedIndex = 0;
            NameTb.Text = "";
            PassTb.Text = "";
        }

        private void NameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void NameTb_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void RoleCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}