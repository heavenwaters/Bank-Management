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
    public partial class Form3 : Form
    {
        string username;
        string password;
        int customerid;
        string customername;
        int accountno;
        public Form3(string u, string p)
        {
            InitializeComponent();
            username = u;
            password = p;
        }

        private void serviceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void infoPrivacySettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Form10(customername, customerid, accountno, username, password)).ShowDialog();
            this.Close();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            DataTable d = new DataTable();
            d = c.Select("select * from customerappaccount where username = '" + username + "'");
            //bool found = false;
            foreach (DataRow row in d.Rows)
            {
                //found = true;
                customerid = row.Field<int>(2);
            }
            d = c.Select("select * from customer where idcustomer = " + customerid.ToString());
            foreach (DataRow row in d.Rows)
            {
                customername = row.Field<string>(1);
            }

            textBox1.Text = customername;
            textBox2.Text = customerid.ToString();
            d = c.Select("select * from customerbankaccount where customer_idcustomer = " + customerid + "");
            foreach (DataRow row in d.Rows)
            {
                accountno = row.Field<int>(0);
            }
            textBox3.Text = accountno.ToString();

            //recent transactions
            //DBconnectioncs c = new DBconnectioncs();
            //DataTable d = new DataTable();
            d = c.Select("select top(2) * from transactionrequest where customerappaccount_username = '"+username+"' order by TransactionReqID desc;");
            dataGridView1.DataSource = d;

            d = c.Select("select top(2) * from transferrequest where customerappaccount_username = '" + username + "' order by TransferReqID desc;");
            dataGridView2.DataSource = d;

            d = c.Select("select top(2) * from billpaymentrequest where customerappaccount_username = '" + username + "' order by idBillPaymentRequest desc;");
            dataGridView3.DataSource = d;

            d = c.Select("select * from customercard where customer_idcustomer = "+customerid.ToString());
            dataGridView4.DataSource = d;
        }

        private void complaintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Form5(customername,customerid,username)).ShowDialog();
            this.Show();

        }

        private void withdrawDepositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Form7(customername, customerid, accountno, username)).ShowDialog();
            DBconnectioncs c = new DBconnectioncs();
            DataTable d = new DataTable();
            d = c.Select("select top(2) * from transactionrequest where customerappaccount_username = '" + username + "' order by TransactionReqID desc;");
            dataGridView1.DataSource = d;

            d = c.Select("select top(2) * from transferrequest where customerappaccount_username = '" + username + "' order by TransferReqID desc;");
            dataGridView2.DataSource = d;

            d = c.Select("select top(2) * from billpaymentrequest where customerappaccount_username = '" + username + "' order by idBillPaymentRequest desc;");
            dataGridView3.DataSource = d;

            this.Show();
        }

        private void transferToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Form8(customername, customerid, accountno, username)).ShowDialog();
            DBconnectioncs c = new DBconnectioncs();
            DataTable d = new DataTable();
            d = c.Select("select top(2) * from transactionrequest where customerappaccount_username = '" + username + "' order by TransactionReqID desc;");
            dataGridView1.DataSource = d;

            d = c.Select("select top(2) * from transferrequest where customerappaccount_username = '" + username + "' order by TransferReqID desc;");
            dataGridView2.DataSource = d;

            d = c.Select("select top(2) * from billpaymentrequest where customerappaccount_username = '" + username + "' order by idBillPaymentRequest desc;");
            dataGridView3.DataSource = d;


            this.Show();

        }

        private void billPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Form9(customername, customerid, accountno, username)).ShowDialog();
            DBconnectioncs c = new DBconnectioncs();
            DataTable d = new DataTable();
            d = c.Select("select top(2) * from transactionrequest where customerappaccount_username = '" + username + "' order by TransactionReqID desc;");
            dataGridView1.DataSource = d;

            d = c.Select("select top(2) * from transferrequest where customerappaccount_username = '" + username + "' order by TransferReqID desc;");
            dataGridView2.DataSource = d;

            d = c.Select("select top(2) * from billpaymentrequest where customerappaccount_username = '" + username + "' order by idBillPaymentRequest desc;");
            dataGridView3.DataSource = d;

            this.Show();
        }

        private void addNewCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Form4(customername, customerid, accountno)).ShowDialog();

            DBconnectioncs c = new DBconnectioncs();
            DataTable d = new DataTable();
            d = c.Select("select * from customercard where customer_idcustomer = " + customerid.ToString());
            dataGridView4.DataSource = d;

            this.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
