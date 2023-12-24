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
    public partial class PatientsTodayForm : Form
    {
        public PatientsTodayForm()
        {
            InitializeComponent();
        }
        private void lblBackHome_Click(object sender, EventArgs e)
        {
            HomeDoctor homeDoctor = new HomeDoctor();
            homeDoctor.Show();
            this.Close();
        }


    }
}
