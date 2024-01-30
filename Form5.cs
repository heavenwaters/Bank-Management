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
    public partial class Form5 : Form
    {
        string customername;
        int customerid;
        string username;

        public Form5(string n, int id, string u)
        {
            InitializeComponent();
            customername = n;
            customerid = id;
            username = u;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            c.Inserts("insert into Complaint(Customerappaccount_username, description) values('"+username+"', '"+richTextBox1.Text+"')");
            MessageBox.Show("Your complaint will be reviewed by the administration");
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox1.Text = customername;
            textBox2.Text = customerid.ToString();
        }
    }
}
