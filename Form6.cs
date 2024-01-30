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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            Timer timer = new Timer();
            timer.Interval = 1500;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();

        }
        void Timer_Tick(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
