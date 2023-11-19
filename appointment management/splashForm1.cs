using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appointment_management
{
    public partial class splashForm1 : Form
    {
        public splashForm1()
        {
            InitializeComponent();
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                homeForm1 homeForm1 = new homeForm1();
                homeForm1.Show();
                this.Hide();
            }


        }
    }
}
