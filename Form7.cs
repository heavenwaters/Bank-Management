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
    public partial class Form7 : Form
    {
        string customername;
        int customerid;
        int accountno;
        double balance;
        string username;
        public Form7(string n, int ci, int ai, string u)
        {
            InitializeComponent();
            customername = n;
            customerid = ci;
            accountno = ai;
            username = u;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            textBox1.Text = customername;
            textBox2.Text = accountno.ToString();
            DBconnectioncs c = new DBconnectioncs();
            DataTable d = new DataTable();
            d = c.Select("select * from customerbankaccount where accountno = "+accountno.ToString()+";");
            //bool found = false;
            foreach (DataRow row in d.Rows)
            {
                //found = true;
                balance = row.Field<double>(4);
            }
            textBox4.Text = balance.ToString();
            textBox3.Text = "0";
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char[] symbols = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '\b'};
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

        private void button1_Click(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            if (comboBox1.Text == "Withdraw" && textBox3.Text != "")
            {
                if (Convert.ToInt32(textBox3.Text) <= balance)
                {
                    c.Inserts("update customerbankaccount set balance = balance - " + textBox3.Text + " where AccountNo = " + accountno.ToString() + ";");
                    c.Inserts("insert into TransactionRequest(CustomerBankAccount_Customer_idCustomer, CustomerBankAccount_AccountNo, TransactionType_idTransaction, CustomerAppAccount_Username, Amount, date) values ("+customerid.ToString()+", "+accountno.ToString()+", 'Withdraw', '"+username+"', "+textBox3.Text+", GETDATE())");
                    MessageBox.Show("Your transaction has been processed");
                }
                else
                {
                    MessageBox.Show("Insufficient Funds!");
                }
                this.Close();

            }
            else if (comboBox1.Text == "Deposit" && textBox3.Text != "")
            {
                c.Inserts("update customerbankaccount set balance = balance + " + textBox3.Text + " where AccountNo = " + accountno.ToString() + ";");
                c.Inserts("insert into TransactionRequest(CustomerBankAccount_Customer_idCustomer, CustomerBankAccount_AccountNo, TransactionType_idTransaction, CustomerAppAccount_Username, Amount, date) values (" + customerid.ToString() + ", " + accountno.ToString() + ", 'Deposit', '" + username + "', " + textBox3.Text + ", GETDATE())");

                MessageBox.Show("Your transaction has been processed");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter all the details required");
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "0";
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
        }
    }
}
