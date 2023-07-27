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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6VBO5VT;Initial Catalog=Market;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Admin")
            {
                if (phoneNum.Text == "017" && Pass.Text == "0000")
                {
                    MessageBox.Show("Login Sucessful", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Sellerform sf = new Sellerform();
                    sf.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (comboBox1.Text == "Seller")
            {
                if (phoneNum.Text != "" && Pass.Text != "")
                {
                    string query = "select * from M_Seller where Phone_Number=@Phone_Number and Password=@Password";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Phone_Number", phoneNum.Text);
                    cmd.Parameters.AddWithValue("@Password", Pass.Text);
                    con.Open();
                    SqlDataReader sda = cmd.ExecuteReader();
                    if (sda.HasRows == true)
                    {
                        MessageBox.Show("Login Sucessful", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        ProductForm pf = new ProductForm();
                        pf.Show();

                    }
                    else

                        MessageBox.Show("Login Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    con.Close();


                }
            }
            else if (comboBox1.Text == "customer")
            {
                if (phoneNum.Text != "" && Pass.Text != "")
                {
                    string query = "select * from CustomerLoginPage where Phone_number=@Phone_number and Pass=@Pass";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Phone_number", phoneNum.Text);
                    cmd.Parameters.AddWithValue("@Pass", Pass.Text);
                    con.Open();
                    SqlDataReader sda = cmd.ExecuteReader();
                    if (sda.HasRows == true)
                    {
                        MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        SellingForm ssf = new SellingForm();
                        ssf.Show();

                    }
                    else
                        MessageBox.Show("Login Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    con.Close();


                }


            }
                else
                {
                    MessageBox.Show("Please select user option first", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    con.Close();
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpForm sgf = new SignUpForm();  
            sgf.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
