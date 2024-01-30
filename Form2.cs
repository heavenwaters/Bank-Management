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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Gray;
            textBox2.ForeColor = Color.Gray;
            textBox3.ForeColor = Color.Gray;
            textBox4.ForeColor = Color.Gray;
            textBox5.ForeColor = Color.Gray;
            textBox1.Text = "<e.g. heavenWaters123>";
            textBox2.Text = "<e.g. Alpha#Dex52?>";
            textBox4.Text =  "<e.g. heavenWaters123>";
            textBox3.Text = "<e.g. Alpha#Dex52?>";
            textBox5.Text = "Retype password";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.ForeColor = SystemColors.WindowText;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.ForeColor = SystemColors.WindowText;

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            this.ForeColor = SystemColors.WindowText;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.ForeColor = SystemColors.WindowText;

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            this.ForeColor = SystemColors.WindowText;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            DataTable d = new DataTable();
            d = c.Select("select * from customerappaccount where username = '" + textBox4.Text + "'");
            bool found = false;
            foreach (DataRow row in d.Rows)
            {
                found = true;
            }
            if (found == false)
            {
                if (textBox3.Text == textBox5.Text && textBox3.Text.Length >= 8)
                {
                    this.Hide();
                    (new Form1(textBox4.Text, textBox3.Text)).ShowDialog();
                    //(new Form3()).ShowDialog();
                    textBox1.Text = "<e.g. heavenWaters123>";
                    textBox2.Text = "<e.g. Alpha#Dex52?>";
                    textBox4.Text = "<e.g. heavenWaters123>";
                    textBox3.Text = "<e.g. Alpha#Dex52?>";
                    textBox5.Text = "Retype password";
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Password Incorrect!");
                }
            }
            else
            {
                MessageBox.Show("This user already exists!");
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = Color.Gray;
                textBox1.Text = "<e.g. heavenWaters123>";

            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
            textBox1.ForeColor = SystemColors.WindowText;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Clear();
            textBox2.PasswordChar = '*';
            textBox2.ForeColor = SystemColors.WindowText;
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.Clear();
            textBox4.ForeColor = SystemColors.WindowText;

        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Clear();
            textBox3.PasswordChar = '*';
            textBox3.ForeColor = SystemColors.WindowText;

        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            textBox5.Clear();
            textBox5.PasswordChar = '*';
            textBox5.ForeColor = SystemColors.WindowText;

        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.ForeColor = Color.Gray;
                textBox5.PasswordChar = '\0';
                textBox5.Text = "Retype password";

            }

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.ForeColor = Color.Gray;
                textBox3.PasswordChar = '\0';
                textBox3.Text = "<e.g.Alpha#Dex52?>";

            }

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.ForeColor = Color.Gray;
                textBox4.Text = "<e.g. heavenWaters123>";

            }

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.ForeColor = Color.Gray;
                textBox2.PasswordChar = '\0';
                textBox2.Text = "<e.g. Alpha#Dex52?>";

            }

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Exit?!", "Exit",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            DataTable d = new DataTable();
            d = c.Select("select * from customerappaccount where username = '"+textBox1.Text+"'");
            bool found = false;
            foreach (DataRow row in d.Rows)
            {
                found = true;
                if (row.Field<string>(1) == textBox1.Text && row.Field<string>(3) == textBox2.Text)
                {
                    this.Hide();
                    (new Form3(textBox1.Text, textBox2.Text)).ShowDialog();
                    textBox1.Text = "<e.g. heavenWaters123>";
                    textBox2.Text = "<e.g. Alpha#Dex52?>";
                    textBox4.Text = "<e.g. heavenWaters123>";
                    textBox3.Text = "<e.g. Alpha#Dex52?>";
                    textBox5.Text = "Retype password";
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Username or Password Incorrect!");
                }
            }

            if (found == false)
            {
                MessageBox.Show("This user is not registerd");
            }
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.ForeColor = SystemColors.WindowText;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.ForeColor = SystemColors.WindowText;
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.ForeColor = SystemColors.WindowText;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.ForeColor = SystemColors.WindowText;
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.ForeColor = SystemColors.WindowText;
        }
    }
}
