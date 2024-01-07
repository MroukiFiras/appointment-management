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
    public partial class AppointmentDetailsForm : Form
    {
        private readonly int _cin;

        public AppointmentDetailsForm(int appointmentId, int cin, string fullName)
        {
            InitializeComponent();
            lblAppointementId.Text = appointmentId.ToString("D3");
            lblCin.Text = cin.ToString();
            lblName.Text = fullName;

            _cin = cin; 
        }
        private void label6_Click(object sender, EventArgs e)
        {
            homeSec homeSec = new homeSec();
            homeSec.Show();
            this.Hide();
        }
        private void btnAllApp_Click(object sender, EventArgs e)
        {
            appointment_Form frm = new appointment_Form();
            frm.Show();
            this.Hide();
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            Appointment newAppointment = new Appointment(GenerateAppointmentId(), DateTime.Now, GetPatientByCIN(_cin));

            if (newAppointment != null)
            {
                if (newAppointment.AppointmentDateTime.Date <= DateTime.Today)
                {
                    MessageBox.Show("Please select a future date for the appointment.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Program.tableAppointment.Add(newAppointment);
                    MessageBox.Show("Appointment added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a patient to add an appointment.", "No Patient Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private int GenerateAppointmentId()
        {
            Random random = new Random();
            return random.Next(100, 1000);
        }
        private Patient GetPatientByCIN(int cin)
        {
            return Program.tablePatient.FirstOrDefault(p => p.cin == cin);
        }


    }
}