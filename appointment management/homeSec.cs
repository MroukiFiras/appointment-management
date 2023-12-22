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
    public partial class homeSec : Form
    {
        public homeSec()
        {
            InitializeComponent();
        }

        private void addNewPatientTool_Click(object sender, EventArgs e)
        {
            AddPatient addPatient = new AddPatient();
            addPatient.Show();
            this.Hide();
        }

        private void listePatientTool_Click(object sender, EventArgs e)
        {
            ListPatient listPatient = new ListPatient();
            listPatient.Show();
            this.Hide();
        }

        private void logoutTool_Click(object sender, EventArgs e)
        {
            type typeForm = new type();
            typeForm.Show();
            this.Close();
        }
    }
}
