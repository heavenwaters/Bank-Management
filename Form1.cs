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
    public partial class Form1 : Form
    {
        string username;
        string password;
        public Form1(string u, string p)
        {
            InitializeComponent();
            username = u;
            password = p;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TinitalD.Text = "0";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DBconnectioncs c = new DBconnectioncs();
            int year = Tdate.Value.Year;
            int curryear = DateTime.Now.Year;

            //Tname.Text != "" && curryear - year >= 18 && Taddress.Text != "" && 
            //textBox1.Text = (curryear - year).ToString();


            if (Tname.Text != "" && TcontactNo.Text != "" && Taddress.Text != "" && (curryear - year) >= 18 && male.Checked == true && male.Checked != female.Checked && Convert.ToInt32(TinitalD.Text) >= 1000)
            {
                c.Inserts("insert into Customer([name], DOB, Gender, ContactNo, [address]) values ('" + Tname.Text + "',cast('" + Tdate.Value + "' as date),cast('1' as bit),cast('" + TcontactNo.Text + "' as int),'" + Taddress.Text + "')");
                c.Inserts("insert into CustomerAppAccount(username, customer_idcustomer ,password_2) values('" + username + "',(select top(1) idcustomer from customer order by idcustomer desc),'" + password + "')");
                c.Inserts("insert into CustomerBankAccount(customer_idcustomer, accountcreate_date, balance) values((select top(1) idcustomer from customer order by idcustomer desc), (getdate()),"+TinitalD.Text+")");


                this.Hide();
                (new Form3(username,password)).ShowDialog();
                this.Close();


            }
            else if (Tname.Text != "" && TcontactNo.Text != "" && Taddress.Text != "" && (curryear - year) >= 18 && female.Checked == true && male.Checked != female.Checked && Convert.ToInt32(TinitalD.Text) >= 1000)
            {
                c.Inserts("insert into Customer(name, DOB, Gender, ContactNo, address) values ('" + Tname.Text + "',cast('" + Tdate.Value + "' as date),cast('0' as bit),cast('" + TcontactNo.Text + "' as int),'" + Taddress.Text + "')");
                c.Inserts("insert into CustomerAppAccount(username, customer_idcustomer ,password_2) values('" + username + "',(select top(1) idcustomer from customer order by idcustomer desc),'" + password + "')");
                c.Inserts("insert into CustomerBankAccount(customer_idcustomer, accountcreate_date, balance) values((select top(1) idcustomer from customer order by idcustomer desc), (getdate()),"+TinitalD.Text+")");

                this.Hide();
                (new Form3(username,password)).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Details Entered!");
            }

        }

        private void male_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void TcontactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar == '-'){
                e.Handled = true;
            }
            */
            char[] symbols = { '1', '2', '3', '4', '5', '6', '7', '8','9', '0','\b'};
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

        private void TinitalD_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TinitalD_Leave(object sender, EventArgs e)
        {
            if (TinitalD.Text == "")
            {
                TinitalD.Text = "0";
            }
        }
    }
}
