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
            int cin = Convert.ToInt32(cinTxt.Text);
            string firstName = firstNameTxt.Text;
            string lastName = lastNameTxt.Text;
            DateTime dateOfBirth = dateOfbirth.Value;
            string gendre = comboBox1.Text;
            string adress = adrTxt.Text;
            string phoneNumber = phoneNumberTxt.Text.Trim();
            string email = emailTxt.Text.Trim();
            Patient newPatient = new Patient(cin,firstName,lastName,dateOfBirth,gendre,adress, phoneNumber, email);
            if (!newPatient.IsPhoneNumberValid(phoneNumber))
            {
                MessageBox.Show("Please enter a valid phone number.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                phoneNumberTxt.Focus();
                return;
            }
            if (!newPatient.IsEmailValid(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                emailTxt.Focus();
                return;
            }
            Program.tablePatient.Add(newPatient);
            ListPatient listPatient = new ListPatient();
            listPatient.Show();
            this.Hide();


        }

        private void lblBackHome_Click(object sender, EventArgs e)
        {
            homeSec homeSec = new homeSec();
            homeSec.Show();
            this.Hide();
        }
    }
}
