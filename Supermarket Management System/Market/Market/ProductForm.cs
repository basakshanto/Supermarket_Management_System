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
    public partial class ProductForm : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6VBO5VT;Initial Catalog=Market;Integrated Security=True");
        public ProductForm()
        {
            InitializeComponent();
            BindGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (Cat.Text != "" && ProName.Text != "" && Price.Text != "" && Quantity.Text != "")
            {
                string query = "insert into Product_Table values( @Category, @Product_Name, @Price, @Quantity)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Category", Cat.Text);
                cmd.Parameters.AddWithValue("@Product_Name", ProName.Text);
                cmd.Parameters.AddWithValue("@Price", Price.Text);
                cmd.Parameters.AddWithValue("@Quantity", Quantity.Text);
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Cat.Text != "" && ProName.Text != "" && Price.Text != "" && Quantity.Text != "")
            {
                string query = "update Product_Table set Cat=@Category, ProName=@Product_Name, Price=@Price, Quantity=@Quantity where Cat=@Category";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@Category", Cat.Text);
                cmd.Parameters.AddWithValue("@Product_Name", ProName.Text);
                cmd.Parameters.AddWithValue("@Price", Price.Text);
                cmd.Parameters.AddWithValue("@Quantity", Quantity.Text);

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

        private void btnRemove_Click(object sender, EventArgs e)
        {

            string query = "delete from  Product_Table where Cat=@Category";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Category", Cat.Text);
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

            string query = "select * from Product_Table";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);


            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;



            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 50;
        }
        private void ClearData()
        {
            Cat.Text = "";
            ProName.Text = "";
            Price.Text = "";
            Quantity.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
