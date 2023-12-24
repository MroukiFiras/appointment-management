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
    public partial class NewPatientList : Form
    {
        public NewPatientList()
        {
            InitializeComponent();
        }
        private void NewPatientList_Load(object sender, EventArgs e)
        {
            DataTable patientTable = ListPatient.table;
            DataTable todayPatientsTable = patientTable.Clone(); 
            DateTime today = DateTime.Today;
            var todayPatients = patientTable.AsEnumerable()
                .Where(row => row.Field<DateTime>("DateAdded").Date == today);
            foreach (var patient in todayPatients)
            {
                todayPatientsTable.ImportRow(patient);
            }
            dataGridView1.DataSource = todayPatientsTable;
        }
        private void lblBackHome_Click(object sender, EventArgs e)
        {
            HomeDoctor homeDoctor = new HomeDoctor();
            homeDoctor.Show();
            this.Close();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                if (selectedRow.Cells["FirstName"].Value != null &&
                    selectedRow.Cells["LastName"].Value != null &&
                    !string.IsNullOrEmpty(selectedRow.Cells["FirstName"].Value.ToString()) &&
                    !string.IsNullOrEmpty(selectedRow.Cells["LastName"].Value.ToString()))
                {
                    string patientName = selectedRow.Cells["FirstName"].Value.ToString() + " " +
                                         selectedRow.Cells["LastName"].Value.ToString();
                    DialogResult dialogResult = MessageBox.Show(
                        $"Give an appointment soon to {patientName}?",
                        "Appointment Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (dialogResult == DialogResult.Yes)
                    {
                        MessageBox.Show("Appointment scheduled soon.", "Appointment Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        MessageBox.Show("No appointment scheduled.", "Appointment Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

    }

}
