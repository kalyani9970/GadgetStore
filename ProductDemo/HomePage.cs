using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductDemo
{
    public partial class HomePage : Form
    {
        string str;
        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            str = "A gadgets shopping center is a specialized retail hub \n" +
                "offering the latest electronic devices, accessories, \n" +
                "and tech solutions under one roof. These centers, such \n" +
                "as Croma in Chinchwad or local specialists like Gadget \n" +
                "Shoppe, provide hands-on experience with products like \n" +
                "phones, headphones, and home automation tools. They often \n" +
                "feature knowledgeable staff to assist with technical queries \n" +
                "and offer post-purchase support, ensuring a comprehensive consumer \n" +
                "electronics experience.";
            label2.Text = str;
        }

        private void Register_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            reg.Show();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
        }
    }
}
