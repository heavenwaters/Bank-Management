using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerBankAccountManagementSystem
{
    public partial class Form10 : Form
    {
        string customername;
        int customerid;
        string username;
        string password;
        public Form10(string n, int ci, int ai, string u, string p)
        {
            InitializeComponent();
            customername = n;
            customerid = ci;
            username = u;
            password = p;
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            textBox1.Text = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                if (textBox2.Text == password && textBox3.Text == textBox4.Text)
                {
                    DBconnectioncs c = new DBconnectioncs();
                    c.Inserts("update customerappaccount set password_2 = '"+textBox4.Text+"' where Customer_idCustomer = "+customerid+";");
                    MessageBox.Show("Password changed successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Some details did not match!");
                }
            }
            else
            {
                MessageBox.Show("Please enter all the required details");
            }
        }
    }
}
