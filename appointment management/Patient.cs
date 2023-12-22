using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace appointment_management
{
    internal class Patient
    {
        public int cin { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string gender { get; set; }
        public string adress { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }

        public Patient(int cin, string firstName, string lastName, DateTime dateOfBirth, string gender, string address, string phoneNumber, string email)
        {
            this.cin = cin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.adress = address;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }
        public bool IsEmailValid(string email)
        {
            string emailPattern = @"^\w+(\.\w+)*@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
            return Regex.IsMatch(email, emailPattern);
        }
        public bool IsPhoneNumberValid(string phoneNumber)
        {
            string phonePattern = @"^\d{8}$"; 
            return Regex.IsMatch(phoneNumber, phonePattern);
        }

    }
}
