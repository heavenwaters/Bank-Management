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
    public partial class Form9 : Form
    {
        string customername;
        int customerid;
        int accountno;
        string username;
        double balance;
        public Form9(string n, int ci, int ai, string u)
        {
            InitializeComponent();
            customername = n;
            customerid = ci;
            accountno = ai;
            username = u;
        }

        private void Form9_Load(object sender, EventArgs e)
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
        {
            if (textBox6.Text != "" && textBox3.Text != "")
            {
                if (Convert.ToInt32(textBox6.Text) <= balance)
                {
                    DBconnectioncs c = new DBconnectioncs();
                    c.Inserts("insert into BillPaymentRequest(CustomerBankAccount_Customer_idCustomer,CustomerBankAccount_AccountNo, CustomerAppAccount_Username, ServiceName, BillNo, AmountPaid, date) values (" + customerid.ToString() + ", " + accountno.ToString() + ", '" + username + "', '" + comboBox1.Text + "', '" + textBox3.Text + "', "+textBox6.Text+", GETDATE());");
                    c.Inserts("update customerbankaccount set balance = balance - " + textBox6.Text + " where AccountNo = " + accountno.ToString() + ";");
                    MessageBox.Show("Payment Successful");
                }
                else
                {
                    MessageBox.Show("Insufficient Funds!");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter all the required details!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Electricity Bill")
            {
                textBox6.Text = "500";
            }

            else if (comboBox1.Text == "Internet Bill")
            {
                textBox6.Text = "150";
            }
            else if (comboBox1.Text == "Gas Bill")
            {
                textBox6.Text = "350";
            }
        }
    }
}
