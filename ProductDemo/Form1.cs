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
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder cmd;
        DataSet ds;
        DataTable dt;
        string str;
        public Form1()
        {
            InitializeComponent();
            str = "Data Source=localhost\\sqlexpress;Initial Catalog=DemoTables;Integrated Security=True;TrustServerCertificate=True";
            con =new SqlConnection(str);
            da = new SqlDataAdapter("select * from products", con);
            dt = new DataTable();
            da.Fill(dt);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt;
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            DataRow dr = dt.NewRow();
            dr[1] = textBox2.Text;
            dr[2] = textBox3.Text;
            dr[3] = textBox4.Text;
            dr[4] = Convert.ToInt32(textBox5.Text);
            dt.Rows.Add(dr);
            cmd = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("Data added!!!", "status", MessageBoxButtons.OKCancel);
        }

        private void Update_Click(object sender, EventArgs e)
        {
            int pid = Convert.ToInt32(textBox1.Text);
            DataRow[] dr = dt.Select($"select pid={pid}");
            dr[0][1] = textBox2.Text;
            dr[0][2] = textBox3.Text;
            dr[0][3] = textBox4.Text;
            dr[0][4] = Convert.ToInt32(textBox5.Text);
            dt.Rows.Add(dr);
            cmd = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("Data added!!!");
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            int pid = Convert.ToInt32(textBox1.Text);
            DataRow[] dd = dt.Select($"pid={pid}");
            dd[0].Delete();
            cmd = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("Data added!!!", "status", MessageBoxButtons.OKCancel);
        }
    }
}
