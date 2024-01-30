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
    public partial class Form8 : Form
    {
        string customername;
        int customerid;
        int accountno;
        double balance;
        string payeename;
        int payeeid;
        string username;

        public Form8(string n, int ci, int ai,string u)
        {
            InitializeComponent();
            customername = n;
            customerid = ci;
            accountno = ai;
            username = u;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            textBox1.Text = customername;
            textBox2.Text = accountno.ToString();
            DBconnectioncs c = new DBconnectioncs();
            DataTable d = new DataTable();
            d = c.Select("select * from customerbankaccount where accountno = " + accountno.ToString() + ";");
            //bool found = false;
            foreach (DataRow row in d.Rows)
            {
                //found = true;
                balance = row.Field<double>(4);
            }
            textBox4.Text = balance.ToString();
            textBox6.Text = "0";

        }

        private void button1_Click(object sender, EventArgs e)
        {   if (textBox3.Text != "")
            {
                if (textBox3.Text != "ID not found")
                {
                    if (Convert.ToInt32(textBox5.Text) != accountno)
                    {
                        if (Convert.ToInt32(textBox6.Text) <= balance)
                        {
                            DBconnectioncs c = new DBconnectioncs();
                            c.Inserts("update customerbankaccount set balance = balance - " + textBox6.Text + " where AccountNo = " + accountno.ToString() + ";");
                            c.Inserts("update customerbankaccount set balance = balance + " + textBox6.Text + " where AccountNo = " + textBox5.Text + ";");
                            c.Inserts("insert into TransferRequest(CustomerAppAccount_Username, PayeeID, PayeeAccountNo, Amount) values ('"+username+"', "+payeeid.ToString()+", "+textBox5.Text+", "+textBox6.Text+");");
                            MessageBox.Show("Your transfer has been processed");
                        }
                        else
                        {
                            MessageBox.Show("Insufficient Funds!");
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("You can not transfer to yourself!");
                    }
                }
                else
                {
                    MessageBox.Show("This account does not exist!");
                }
            }
            else
            {
                MessageBox.Show("Please enter all the required details!");
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char[] symbols = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '\b' };
            //char[] symbols = { 'a', 'b', 'c' };
            if (symbols.Contains(e.KeyChar) == false)
            {
                e.Handled = true;
            }
            else
            {
                //e.Handled = true;
            }

        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "0";
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char[] symbols = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '\b' };
            //char[] symbols = { 'a', 'b', 'c' };
            if (symbols.Contains(e.KeyChar) == false)
            {
                e.Handled = true;
            }
            else
            {
                //e.Handled = true;
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != "") { 
                //string payeename;
                //int payeeid;
                DBconnectioncs c = new DBconnectioncs();
                DataTable d = new DataTable();
                d = c.Select("select * from customerbankaccount where accountno = " + textBox5.Text + ";");
                bool found = false;
                foreach (DataRow row in d.Rows)
                {
                    found = true;
                    payeeid = row.Field<int>(1);
                }
                if (found == false)
                {
                    textBox3.BackColor = textBox3.BackColor;
                    textBox3.ForeColor = Color.Red;
                    textBox3.Text = "ID not found";
                }
                else
                {
                    textBox3.ForeColor = SystemColors.WindowText;
                    d = c.Select("select * from customer where idcustomer = " + payeeid.ToString() + ";");
                    foreach (DataRow row in d.Rows)
                    {
                        payeename = row.Field<string>(1);
                    }
                    textBox3.Text = payeename;
                }
            }
            else
            {
                textBox3.ForeColor = SystemColors.WindowText;
                textBox3.Text = "";
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
