using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eye_Managment_System_Front
{
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
            DisplayPat();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\OneDrive\Documents\ClinicalDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void DisplayPat()
        {
            Con.Open();
            String Query = "Select * from PatientTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PatientDGV1.DataSource = ds.Tables[0];
            Con.Close();
        }
        int Key = 0;
        private void clear()
        {
            PatName.Text = "";
            PatGen.SelectedIndex = 0;
            PatAdd.Text = "";
            PatPhone.Text = "";
            PatAl.Text = "";
            Key = 0;
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (PatName.Text == "" || PatAl.Text == "" || PatPhone.Text == "" || PatAdd.Text == "" || PatGen.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into PatientTbl(PatName,PatGen,PatDate,PatAdd,PatPhone,PatAl,)values(@PN,@PG,@PD,@PA,@PP,@PAL)", Con);
                    cmd.Parameters.AddWithValue("@PN", PatName.Text);
                    cmd.Parameters.AddWithValue("@PG", PatGen.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PD", PatDate.Value.Date);
                    cmd.Parameters.AddWithValue("@PA", PatAdd.Text);
                    cmd.Parameters.AddWithValue("@PP", PatPhone.Text);
                    cmd.Parameters.AddWithValue("@PAL", PatAl.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Added");
                    Con.Close();
                    DisplayPat();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            {
                if (PatName.Text == "" || PatAl.Text == "" || PatPhone.Text == "" || PatAdd.Text == "" || PatGen.SelectedIndex == -1)
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    try
                    {
                        Con.Open();
                        SqlCommand cmd = new SqlCommand("update PatientTbl set PatName=@PN , PatGen=@PG , PatDate=@PD, PatAdd=@PA,PatPhone=@PP,PatAl=@PAL where PatId=@Pkey", Con);
                        cmd.Parameters.AddWithValue("@PN", PatName.Text);
                        cmd.Parameters.AddWithValue("@PG", PatGen.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@PD", PatDate.Value.Date);
                        cmd.Parameters.AddWithValue("@PA", PatAdd.Text);
                        cmd.Parameters.AddWithValue("@PP", PatPhone.Text);
                        cmd.Parameters.AddWithValue("@PAL", PatAl.Text);
                        cmd.Parameters.AddWithValue("@PKey", Key);


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Patient Updated");
                        Con.Close();
                        DisplayPat();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }

                }
            }
        }

        private void PatientDGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PatName.Text = PatientDGV1.SelectedRows[0].Cells[1].Value.ToString();
            PatGen.SelectedItem = PatientDGV1.SelectedRows[0].Cells[2].Value.ToString();
            PatDate.Text = PatientDGV1.SelectedRows[0].Cells[3].Value.ToString();
            PatAdd.Text = PatientDGV1.SelectedRows[0].Cells[4].Value.ToString();
            PatPhone.Text = PatientDGV1.SelectedRows[0].Cells[5].Value.ToString();
            PatAl.Text = PatientDGV1.SelectedRows[0].Cells[6].Value.ToString();

            if (PatName.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(PatientDGV1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Patient");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from PatientTbl where PatId=@PKey", Con);

                    cmd.Parameters.AddWithValue("@RKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Deleted");
                    Con.Close();
                    DisplayPat();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Patient_Load(object sender, EventArgs e)
        {

        }
    }
}
