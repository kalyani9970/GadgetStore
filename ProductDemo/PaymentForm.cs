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
    public partial class PaymentForm : Form
    {
        string str;
        public PaymentForm(string s)
        {
            InitializeComponent();
            str = s;
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("✨Congratulations!!! Order confirmed.✨");
            label1.Text = $"{str}We're happy to know you bought a product from our collection. \nThanks for shopping with us! \nHave a great day!!!";
        }
    }
}
