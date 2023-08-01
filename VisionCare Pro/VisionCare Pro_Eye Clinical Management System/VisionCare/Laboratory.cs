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
//using System.Data.SqlClient;

namespace Eye_Managment_System_Front
{
    public partial class Laboratory : Form
    {
        public Laboratory()
        {
            InitializeComponent();
            DisplayTest();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\OneDrive\Documents\ClinicalDb.mdf;Integrated Security=True;Connect Timeout=30");
        
        private void DisplayTest()
        {
            Con.Open();
            string Query = "select * from TestTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            LabTestDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        int Key = 0;
        private void clear()
        {
            LabTestTb.Text = "";
            LabCostTb.Text = "";
            Key = 0;
        }


        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }


        //Delete
        //private void DeleteBtn_Click(object sender, EventArgs e)
        //{
        //    if (Key == 0)
        //    {
        //        MessageBox.Show("Select Lab Test");
        //    }
        //    else
        //    {
        //        try
        //        {
        //            Con.Open();
        //            SqlCommand cmd = new SqlCommand("Delete from TestTbl where TestNum=@TKey", Con);
        //            cmd.Parameters.AddWithValue("@TKey", Key);
        //            cmd.Parameters.AddWithValue("@TN", LabTestTb.Text);
        //            cmd.Parameters.AddWithValue("@TC", LabCostTb.Text);

        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show("Lab Test Deleted");
        //            Con.Close();
        //            DisplayTest();
        //        }
        //        catch (Exception Ex)
        //        {
        //            MessageBox.Show(Ex.Message);
        //        }
        //    }
        //}


        //private void EditBtn_Click(object sender, EventArgs e)
        //{
        //    if (LabCostTb.Text == "" || LabTestTb.Text == "")
        //    {
        //        MessageBox.Show("Missing Information");
        //    }

            //    else
            //    {
            //try
            //{

            //    Con.Open();
            //    SqlCommand cmd = new SqlCommand("update TestTbl Set TestName=@TN, TestCost=@TC where TestNum=@TKey", Con);
            //    cmd.Parameters.AddWithValue("@TN", LabTestTb.Text);
            //    cmd.Parameters.AddWithValue("@TC", LabCostTb.Text);
            //    cmd.Parameters.AddWithValue("@TKey", Key);

            //    cmd.ExecuteNonQuery();
            //    MessageBox.Show("Test Update");
            //    Con.Close();
            //    DisplayTest();
            //    clear();
            //}


            //catch (Exception Ex)
            //{
            //    MessageBox.Show(Ex.Message);
            //}



        
        

        private void AddLabbtn_Click(object sender, EventArgs e)
        {
            if (LabCostTb.Text == "" || LabTestTb.Text == "")
            {
                MessageBox.Show("Missing Information ");
            }
            else
            {
                try
                {

                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into TestTbl(TestName,TestCost)values(@TN,@TC)", Con);
                    cmd.Parameters.AddWithValue("@TN", LabTestTb.Text);
                    cmd.Parameters.AddWithValue("@TC", LabCostTb.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Test Added");
                    Con.Close();
                    DisplayTest();
                    clear();
                }


                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }



            }

        }

        private void DeleteBtn_Click_1(object sender, EventArgs e)
        {

            if (Key == 0)
            {
                MessageBox.Show("Select Lab Test");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from TestTbl where TestNum=@TKey", Con);
                    cmd.Parameters.AddWithValue("@TKey", Key);
                    cmd.Parameters.AddWithValue("@TN", LabTestTb.Text);
                    cmd.Parameters.AddWithValue("@TC", LabCostTb.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Lab Test Deleted");
                    Con.Close();
                    DisplayTest();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EditBtn_Click_1(object sender, EventArgs e)
        {
            if (LabCostTb.Text == "" || LabTestTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }

            else
            {
                try
                {

                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update TestTbl Set TestName=@TN, TestCost=@TC where TestNum=@TKey", Con);
                    cmd.Parameters.AddWithValue("@TN", LabTestTb.Text);
                    cmd.Parameters.AddWithValue("@TC", LabCostTb.Text);
                    cmd.Parameters.AddWithValue("@TKey", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Test Update");
                    Con.Close();
                    DisplayTest();
                    clear();
                }


                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }



            }
        }

        private void LabTestDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LabTestTb.Text = LabTestDGV.SelectedRows[0].Cells[1].Value.ToString();
            LabCostTb.Text = LabTestDGV.SelectedRows[0].Cells[2].Value.ToString();
            if (LabTestTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(LabTestTb.Text = LabTestDGV.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void Laboratory_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void label22_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }
    }
}


