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
    public partial class appointment_Form : Form
    {
        public appointment_Form()
        {
            InitializeComponent();
  
        }
        private void appointment_Form_Load(object sender, EventArgs e)
        {
            LoadConfirmedAppointments();
        }
        private void LoadConfirmedAppointments()
        {
            List<AppointmentConfirmation> confirmedAppointments = Program.tableConfirmation.Where(c => c.ConfirmationStatus == "Yes").ToList();

            DataTable confirmedAppointmentsDataTable = new DataTable();
            confirmedAppointmentsDataTable.Columns.Add("CIN", typeof(int));
            confirmedAppointmentsDataTable.Columns.Add("FirstName", typeof(string));
            confirmedAppointmentsDataTable.Columns.Add("LastName", typeof(string));

            foreach (var confirmation in confirmedAppointments)
            {
                DataRow newRow = confirmedAppointmentsDataTable.NewRow();
                newRow["CIN"] = confirmation.Patient.cin;
                newRow["FirstName"] = confirmation.Patient.firstName;
                newRow["LastName"] = confirmation.Patient.lastName;
                confirmedAppointmentsDataTable.Rows.Add(newRow);
            }
            dataGridViewConfirmedAppointment.DataSource = confirmedAppointmentsDataTable;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            homeSec homeSec = new homeSec();
            homeSec.Show();
            this.Hide();
        }

        private void dataGridViewConfirmedAppointment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewConfirmedAppointment.Rows[e.RowIndex];
                Random random = new Random();
                int appointmentId = random.Next(100, 1000);
                int cin = Convert.ToInt32(selectedRow.Cells["CIN"].Value);
                string firstName = selectedRow.Cells["FirstName"].Value.ToString();
                string lastName = selectedRow.Cells["LastName"].Value.ToString();
                AppointmentDetailsForm appointmentDetailsForm = new AppointmentDetailsForm(appointmentId, cin, $"{firstName} {lastName}");
                appointmentDetailsForm.Show();
                this.Hide();
            }
        }
    }
}
