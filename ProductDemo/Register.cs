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
    public partial class Register : Form
    {
        string role;
        SqlConnection con;
        SqlCommand cmd;
        string str, query;
        public Register()
        {
            InitializeComponent();
            str = "Data Source=localhost\\sqlexpress;Initial Catalog=DemoTables;Integrated Security=True;TrustServerCertificate=True";
            con = new SqlConnection(str);
            query = "insert into users values (@username,@password,@role,@email,@phno)";
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "" || textBox2.Text == ""|| textBox3.Text == ""|| textBox4.Text == ""|| textBox5.Text == "")
            {
                MessageBox.Show("All fields are mandatory.");
                return;
            }
            if (textBox5.Text != textBox4.Text)
            {
                MessageBox.Show("Password doesn't match!");
                return;
            }
            role = "User";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox4.Text);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.Parameters.AddWithValue("@email", textBox2.Text);
            cmd.Parameters.AddWithValue("@phno", textBox3.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Registration successful!!!", "status", MessageBoxButtons.OKCancel);
            Login l = new Login();
            l.Show();
            this.Hide();
        }
    }
}
