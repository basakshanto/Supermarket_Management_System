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
using System.IO;

namespace Market
{
    public partial class Sellerform : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6VBO5VT;Initial Catalog=Market;Integrated Security=True");
        public Sellerform()
        {
            InitializeComponent();
            BindGridView();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (name.Text!="" && age.Text!="" && phnNum.Text != "" && pass.Text != "")
            {
                string query = "insert into M_Seller values( @Name, @Age, @Phone_Number, @Password)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", name.Text);
                cmd.Parameters.AddWithValue("@Age", age.Text);
                cmd.Parameters.AddWithValue("@Phone_number", phnNum.Text);
                cmd.Parameters.AddWithValue("@Password", pass.Text);
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a != 0)
                {
                    MessageBox.Show("Data insert Sucessful", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGridView();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Data insert Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }     
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (name.Text != "" && age.Text != "" && phnNum.Text != "" && pass.Text != "")
            {
                string query = "update M_Seller set Name=@Name, Age=@Age, Phone_Number=@Phone_Number, Password=@Password where Phone_Number=@Phone_Number";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@Name", name.Text);
                cmd.Parameters.AddWithValue("@Age", age.Text);
                cmd.Parameters.AddWithValue("@Password", pass.Text);
                cmd.Parameters.AddWithValue("@Phone_Number", phnNum.Text);

                int a = cmd.ExecuteNonQuery();
                if (a != 0)
                {
                    MessageBox.Show("Data Updated sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGridView();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Data  is not Updated ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "delete from  M_Seller where Phone_Number=@Phone_Number";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Phone_Number", phnNum.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a != 0)
            {
                MessageBox.Show("Data Deleted", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
                ClearData();
            }
            else
            {
                MessageBox.Show("Data  not deleted ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageCustomer mc = new ManageCustomer();
          
            mc.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        void BindGridView()
        {

            string query = "select * from M_Seller";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);


            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;



            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 50;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ClearData()
        {
            name.Text = "";
            age.Text = "";
            pass.Text = "";
            phnNum.Text = "";
        }
    }
}
