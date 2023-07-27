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

namespace Market
{
    public partial class ManageCustomer : Form
    {
        SqlConnection con = new SqlConnection("Data Source=BIJOY\\ASUS;Initial Catalog=Market;Integrated Security=True");
        public ManageCustomer()
        {
            InitializeComponent();
            BindGridView();

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" &&  txtPhone.Text != "" && txtPass.Text != "")
            {
                string query = "update CustomerLoginPage set Name=@Name, Phone_number=@Phone_number, Pass=@Pass where Phone_number=@Phone_number";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Pass", txtPass.Text);
                cmd.Parameters.AddWithValue("@Phone_number", txtPhone.Text);

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
            string query = "delete from  CustomerLoginPage where Phone_number=@Phone_number";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Phone_number", txtPhone.Text);
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

        void BindGridView()
        {

            string query = "select * from CustomerLoginPage";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);


            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;



            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 50;
        }

        private void ClearData()
        {
            txtName.Text = "";
            txtPass.Text = "";
            txtPhone.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
    

