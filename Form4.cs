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
    public partial class Form4 : Form
    {
        string customername;
        int customerid;
        int accountno;
        public Form4(string n, int ci, int ai)
        {
            InitializeComponent();
            customername = n;
            customerid = ci;
            accountno = ai;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.Text = customername;
            textBox2.Text = accountno.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            if (radioButton4.Checked == true)
            {
                c.Inserts("insert into CustomerCard(Customer_idCustomer,IsDebit) values("+customerid.ToString()+", 0);");
            }
            else if (radioButton5.Checked == true)
            {
                c.Inserts("insert into CustomerCard(Customer_idCustomer, IsDebit) values("+customerid.ToString()+", 1);");
            }
            MessageBox.Show("Card Issued");
            this.Close();
        }
    }
}
