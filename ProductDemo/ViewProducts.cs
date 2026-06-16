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

namespace ProductDemo
{
    public partial class ViewProducts : Form
    {
        string str, info;
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder cmd;
        DataSet ds;
        DataTable dt;
        public ViewProducts()
        {
            InitializeComponent();
            str = "Data Source=localhost\\sqlexpress;Initial Catalog=DemoTables;Integrated Security=True;TrustServerCertificate=True";
            con = new SqlConnection(str);
            da = new SqlDataAdapter("select * from products", con);
            dt = new DataTable();
            da.Fill(dt);
            textBox1.DataBindings.Add("text", dt, "pid");
            textBox2.DataBindings.Add("text", dt, "pname");
            textBox3.DataBindings.Add("text", dt, "brand");
            textBox4.DataBindings.Add("text", dt, "pdesc");
            textBox5.DataBindings.Add("text", dt, "price");
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if (BindingContext[dt].Position > 0)
            {
                BindingContext[dt].Position -= 1;
            }
            else
            {
                MessageBox.Show("This is the first record.");
            }
        }

        private void ViewProducts_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (BindingContext[dt].Position < dt.Rows.Count - 1)
            {
                BindingContext[dt].Position += 1;
            }
            else
            {
                MessageBox.Show("This is the last record.");
            }
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            str = comboBox1.Text;
            dv.RowFilter = $"pname='{str}'";
            dataGridView1.DataSource = dv;
        }

        private void Sort_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.Sort = "price";
            //dv.Sort = "price desc";
            dataGridView1.DataSource = dv;
        }

        private void BuyNow_Click(object sender, EventArgs e)
        {
            info = $"        Your Purchased Product Details: \nProduct ID: {textBox1.Text}\nProduct Name: {textBox2.Text}\nProduct Brand: {textBox3.Text}\nDescription: {textBox4.Text}\nPrice: Rs.{textBox5.Text}/-\t(*inclusive of taxes)\n\n";
            PaymentForm pf = new PaymentForm(info);
            pf.Show();
            
        }
    }
}
