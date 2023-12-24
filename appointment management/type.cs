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
    public partial class type : Form
    {
        public type()
        {
            InitializeComponent();
        }
        private void panelSec_Click(object sender, EventArgs e)
        {
            OpenLoginForm("Welcome Secretary");
        }
        private void panelDoctor_Click(object sender, EventArgs e)
        {
            OpenLoginForm("Welcome Doctor");
        }
        private void OpenLoginForm(string welcomeMessage)
        {
            this.Hide();
            loginForm loginForm = new loginForm();
            loginForm.WelcomeMessage = welcomeMessage;
            loginForm.FormClosed += (s, args) => this.Show();
            loginForm.ShowDialog();
        }
    }
}
