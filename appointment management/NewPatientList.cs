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
        private DataTable todayPatientsTable;
        public NewPatientList()
        {
            InitializeComponent();
            
        }
        private void NewPatientList_Load(object sender, EventArgs e)
        {
            LoadPatientData();
        }
        private void LoadPatientData()
        {
            DataTable patientTable = ListPatient.table;
            todayPatientsTable = patientTable.Clone();
            if (!todayPatientsTable.Columns.Contains("Confirmation"))
            {
                todayPatientsTable.Columns.Add("Confirmation", typeof(string));
            }
            DateTime today = DateTime.Today;
            var todayPatients = patientTable.AsEnumerable()
                .Where(row => row.Field<DateTime>("DateAdded").Date == today);
            foreach (var patient in todayPatients)
            {
                DataRow newRow = todayPatientsTable.Rows.Add(patient.ItemArray);
                int cin = int.Parse(patient["CIN"].ToString());
                AppointmentConfirmation confirmation = Program.tableConfirmation
                    .FirstOrDefault(c => c.Patient.cin == cin);

                if (confirmation != null)
                {
                    newRow["Confirmation"] = confirmation.ConfirmationStatus;
                }
            }
            dataGridView1.DataSource = todayPatientsTable;
            UpdateRowColors();
        }
        private void UpdateRowColors()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string confirmationValue = row.Cells["Confirmation"].Value?.ToString();
                if (confirmationValue == "Yes")
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
                else if (confirmationValue == "No")
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
        private void HandleAppointmentConfirmation(DataGridViewRow selectedRow)
        {
            int cin;
            bool isCinValid = int.TryParse(selectedRow.Cells["CIN"].Value?.ToString(), out cin);
            if (isCinValid)
            {
                Patient patient = Program.tablePatient.FirstOrDefault(p => p.cin == cin);
                if (patient != null)
                {
                    string confirmationValue = selectedRow.Cells["Confirmation"].Value?.ToString();

                    if (string.IsNullOrEmpty(confirmationValue))
                    {
                        string patientName = $"{patient.firstName} {patient.lastName}";
                        DialogResult dialogResult = MessageBox.Show(
                            $"Give an appointment soon to {patientName}?",
                            "Appointment Confirmation",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );
                        if (dialogResult == DialogResult.Yes || dialogResult == DialogResult.No)
                        {
                            AppointmentConfirmation confirmation = Program.tableConfirmation.FirstOrDefault(c => c.Patient.cin == cin);
                            if (confirmation == null)
                            {
                                confirmation = new AppointmentConfirmation(patient);
                                Program.tableConfirmation.Add(confirmation);
                            }
                            string confirmationStatus = (dialogResult == DialogResult.Yes) ? "Yes" : "No";
                            confirmation.ConfirmAppointment(confirmationStatus);

                            UpdateConfirmationAndColor(confirmationStatus, selectedRow);
                            MessageBox.Show("Appointment scheduled soon.", "Appointment Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            UpdateRowColors();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Already responded.", "Already Responded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid CIN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateConfirmationAndColor(string confirmationValue, DataGridViewRow selectedRow)
        {
            selectedRow.Cells["Confirmation"].Value = confirmationValue;
            if (confirmationValue == "Yes")
            {
                selectedRow.DefaultCellStyle.BackColor = Color.Green;
            }
            else if (confirmationValue == "No")
            {
                selectedRow.DefaultCellStyle.BackColor = Color.Red;
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                HandleAppointmentConfirmation(selectedRow);
            }
        }
        private void lblBackHome_Click(object sender, EventArgs e)
        {            HomeDoctor homeDoctor = new HomeDoctor();
            homeDoctor.Show();
            this.Close();
        }
    }
}
