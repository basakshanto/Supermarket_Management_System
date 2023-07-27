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
    public partial class SellingForm : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6VBO5VT;Initial Catalog=Market;Integrated Security=True");
        public SellingForm()
        {
            InitializeComponent();
        }

        private void SellingForm_Load(object sender, EventArgs e)
        {
            using(MarketEntities db = new MarketEntities())
            {
                productTableBindingSource.DataSource = db.Product_Table.ToList();
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            for(int i =dataGridView1.RowCount - 1; i >= 0; i--)
            {
                DataGridViewRow row = dataGridView1.Rows[i];

                if(Convert.ToBoolean(row.Cells["Column1"].Value))
                {
                    productTableBindingSource1.Add((Product_Table)row.DataBoundItem);
                    

                }
            }
           
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            for (int i = dataGridView2.RowCount - 1; i >= 0; i--)
            {
                DataGridViewRow row = dataGridView2.Rows[i];
                if (Convert.ToBoolean(row.Cells["colright"].Value))
                {
                   
                    productTableBindingSource1.RemoveAt(row.Index);

                }
            }
        }

        private void Total_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                label1.Text = Convert.ToString(double.Parse(label1.Text) +double.Parse(dataGridView2.Rows[i].Cells[3].Value.ToString()));
            }
        }
    }
}
