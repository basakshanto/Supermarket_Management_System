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
    public partial class SignUpForm : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6VBO5VT;Initial Catalog=Market;Integrated Security=True");
        public SignUpForm()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (name.Text != "" && SetPass.Text != "" && ConPass.Text != "" && PhoneNum.Text != "")
            {
                string query = "insert into CustomerLoginPage values(@Name,@Phone_number,@Pass)";
                SqlCommand cmd = new SqlCommand(query, con);
                
                cmd.Parameters.AddWithValue("@Phone_number", PhoneNum.Text);
                cmd.Parameters.AddWithValue("@Name", name.Text);
                cmd.Parameters.AddWithValue("@Pass", ConPass.Text);
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a!=0)
                {
                    if (ConPass.Text == SetPass.Text)
                    {
                        MessageBox.Show("SignUp Succsesfull ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Form1 f1 = new Form1();
                        f1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Password not matched. Try again. ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("SignUp Not Succsesfull ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}