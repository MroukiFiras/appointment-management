using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace appointment_management
{
    public partial class AddPatient : Form
    {
        public AddPatient()
        {
            InitializeComponent();
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }
            AddNewPatient();

            ListPatient listPatient = new ListPatient();
            listPatient.Show();
            this.Hide();
        }
        // Method to validate input data
        private bool ValidateInput()
        {
            int cin;
            if (!int.TryParse(cinTxt.Text, out cin))
            {
                MessageBox.Show("Please enter a valid CIN (numeric value).", "Invalid CIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cinTxt.Focus();
                return false;
            }
            if (Program.tablePatient.Any(patient => patient.cin == cin))
            {
                MessageBox.Show($"The CIN '{cin}' already exists.", "Duplicate CIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cinTxt.Clear();
                cinTxt.Focus();
                return false;
            }
            string firstName = firstNameTxt.Text;
            string lastName = lastNameTxt.Text;
            string gendre = comboBox1.Text;
            string adress = adrTxt.Text;
            string phoneNumber = phoneNumberTxt.Text.Trim();
            string email = emailTxt.Text.Trim();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(gendre) || string.IsNullOrEmpty(adress) ||
                string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill in all the required fields.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Patient newPatient = new Patient(cin, firstName, lastName, dateOfbirth.Value, gendre, adress, phoneNumber, email);

            if (!newPatient.IsPhoneNumberValid(phoneNumber))
            {
                MessageBox.Show("Please enter a valid phone number.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                phoneNumberTxt.Focus();
                return false;
            }

            if (!newPatient.IsEmailValid(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                emailTxt.Focus();
                return false;
            }
            return true;
        }
        // Method to add a new patient
        private void AddNewPatient()
        {
            int cin = int.Parse(cinTxt.Text);
            string firstName = firstNameTxt.Text;
            string lastName = lastNameTxt.Text;
            string gendre = comboBox1.Text;
            string adress = adrTxt.Text;
            string phoneNumber = phoneNumberTxt.Text.Trim();
            string email = emailTxt.Text.Trim();
            Patient newPatient = new Patient(cin, firstName, lastName, dateOfbirth.Value, gendre, adress, phoneNumber, email);
            Program.tablePatient.Add(newPatient);
        }
        private void lblBackHome_Click(object sender, EventArgs e)
        {
            homeSec homeSec = new homeSec();
            homeSec.Show();
            this.Hide();
        }
    }
}
