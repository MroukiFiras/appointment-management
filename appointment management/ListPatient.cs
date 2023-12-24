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
    public partial class ListPatient : Form
    {
        public ListPatient()
        {
            InitializeComponent();
        }
        public static DataTable table = new DataTable();


        private void ListPatient_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("CIN", typeof(int));
            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            table.Columns.Add("DateOfBirth", typeof(DateTime));
            table.Columns.Add("Gender", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("PhoneNumber", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("DateAdded", typeof(DateTime));
            foreach (Patient newPatient in Program.tablePatient)
            {
                DataRow row = table.NewRow();
                row["Cin"] = newPatient.cin;
                row["FirstName"] = newPatient.firstName;
                row["LastName"] = newPatient.lastName;
                row["DateOfBirth"] = newPatient.dateOfBirth;
                row["Gender"] = newPatient.gender;
                row["Address"] = newPatient.adress;
                row["PhoneNumber"] = newPatient.phoneNumber;
                row["Email"] = newPatient.email;
                row["DateAdded"] = DateTime.Today;
                table.Rows.Add(row);
            }
            dataGridView1.DataSource = table;
        }
        private void label2_Click(object sender, EventArgs e)
        {
            homeSec homeSec = new homeSec();
            homeSec.Show();
            this.Close();
        }


    }
}
