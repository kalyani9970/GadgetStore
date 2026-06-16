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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProductDemo
{
    public partial class Login : Form
    {
        string role, str, query, username, password;
        SqlConnection con;
        SqlCommandBuilder cmdb;
        SqlDataAdapter da;
        DataTable dt;
        SqlCommand cmd;

        public Login()
        {
            InitializeComponent();
            str = "Data Source=localhost\\sqlexpress;Initial Catalog=DemoTables;Integrated Security=True;TrustServerCertificate=True";
            con = new SqlConnection(str);
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            password = textBox2.Text;
            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter username and password");
                return;
            }
            string query = "select * from users where username=@username and password=@password";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login successful!!!");
                role = dt.Rows[0]["role"].ToString();
                if (role == "Admin")
                {
                    Products p = new Products();
                    p.Show();
                }
                else
                {
                    ViewProducts vp = new ViewProducts();
                    vp.Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password...");
            }
        }
    }
}
