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
    public partial class HomeDoctor : Form
    {
        public HomeDoctor()
        {
            InitializeComponent();
        }
        private void grpBoxNbreOfPatientsToday_Click(object sender, EventArgs e)
        {
            PatientsTodayForm frm = new PatientsTodayForm();
            frm.Show();
            this.Hide();
        }
        private void HomeDoctor_Load(object sender, EventArgs e)
        {
            int newPatientsCount = 0;
            DateTime today = DateTime.Today;
            if (ListPatient.table != null) 
            {
                foreach (DataRow row in ListPatient.table.Rows)
                {
                    if (row.Field<DateTime>("DateAdded").Date == today)
                    {
                        newPatientsCount++;
                    }
                }
            }
            lblNewPatientsToday.Text = newPatientsCount.ToString();
        }
        private void grpBoxNewPatientsToday_Click(object sender, EventArgs e)
        {
            NewPatientList newPatientList = new NewPatientList();
            newPatientList.Show();
            this.Hide();
        }
    }
}
