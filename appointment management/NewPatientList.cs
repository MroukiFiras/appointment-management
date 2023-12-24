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
        Dictionary<int, Color> rowColors = new Dictionary<int, Color>();

        private void NewPatientList_Load(object sender, EventArgs e)
        {
            DataTable patientTable = ListPatient.table;
            DataTable todayPatientsTable = patientTable.Clone();
            if (!todayPatientsTable.Columns.Contains("Confirmation"))
            {
                todayPatientsTable.Columns.Add("Confirmation", typeof(string));
            }
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
        // UpdateConfirmationAndColor method sets the "Confirmation" cell value and updates the row color based on the confirmation value
        private void UpdateConfirmationAndColor(string confirmationValue, DataGridViewRow selectedRow)
        {
            selectedRow.Cells["Confirmation"].Value = confirmationValue; // Set the value in the "Confirmation" cell
            if (confirmationValue == "Yes")
            {
                selectedRow.DefaultCellStyle.BackColor = Color.Green; // Green for "Yes"
            }
            else if (confirmationValue == "No")
            {
                selectedRow.DefaultCellStyle.BackColor = Color.Red; // Red for "No"
            }
        }
        // UpdateRowColors method loops through rows and updates row colors based on the "Confirmation" cell value
        private void UpdateRowColors()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string confirmationValue = row.Cells["Confirmation"].Value?.ToString();
                if (confirmationValue == "Yes")
                {
                    rowColors[row.Index] = Color.Green; 
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
                else if (confirmationValue == "No")
                {
                    rowColors[row.Index] = Color.Red; 
                    row.DefaultCellStyle.BackColor = Color.Red; 
                }
            }
        }
        // Method to update DataGridView colors after refresh or data reorder
        private void UpdateDataGridViewColors()
        {
            foreach (var pair in rowColors)
            {
                dataGridView1.Rows[pair.Key].DefaultCellStyle.BackColor = pair.Value;
            }
        }
        // HandleAppointmentConfirmation method handles the appointment confirmation logic
        private void HandleAppointmentConfirmation(DataGridViewRow selectedRow)
        {
            string firstName = selectedRow.Cells["FirstName"].Value?.ToString();
            string lastName = selectedRow.Cells["LastName"].Value?.ToString();
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                if (string.IsNullOrEmpty(selectedRow.Cells["Confirmation"].Value?.ToString()))
                {
                    string patientName = $"{firstName} {lastName}";
                    DialogResult dialogResult = MessageBox.Show(
                        $"Give an appointment soon to {patientName}?",
                        "Appointment Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                    if (dialogResult == DialogResult.Yes)
                    {
                        UpdateConfirmationAndColor("Yes", selectedRow);
                        MessageBox.Show("Appointment scheduled soon.", "Appointment Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        UpdateConfirmationAndColor("No", selectedRow);
                    }
                    UpdateRowColors();
                }
                else
                {
                    MessageBox.Show("Already responded.", "Already Responded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                HandleAppointmentConfirmation(selectedRow); // Call method to handle appointment confirmation
            }
        }
        private void RefreshDataAndColors()
        {
            UpdateRowColors();
            // Perform data refresh here (e.g., reassigning data source or updating DataGridView)
            // After refreshing data, call UpdateDataGridViewColors() to reapply row colors
            UpdateDataGridViewColors();
        }
    }
}
