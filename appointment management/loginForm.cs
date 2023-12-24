using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace appointment_management
{
    public partial class loginForm : Form
    {
        public string WelcomeMessage { get; set; }
        public loginForm()
        {
            InitializeComponent();
            WelcomeMessage = "Welcome User";
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                usernametxt.Focus();
            }));
            passwordtxt.UseSystemPasswordChar = true;
            lblWelcome.Text = WelcomeMessage;
        }
        private void loginbtn_Click(object sender, EventArgs e)
        {
            string checkPassword = passwordtxt.Text;
            string checkUsername = usernametxt.Text;

            if ((checkUsername == "") || (checkPassword == ""))
            {
                MessageBox.Show("You must enter both username and password to log in.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                usernametxt.Focus();
            }
            else if (checkPassword == "secretary") 
            {
                homeSec homeForm1 = new homeSec();
                Program.name = checkUsername;
                homeForm1.Show();
                this.Hide();
            }
            else if (checkPassword == "doctor")
            {
                HomeDoctor homeDoctor = new HomeDoctor();
                Program.name = checkUsername;
                homeDoctor.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                usernametxt.Focus();
                usernametxt.Text = "";
                passwordtxt.Text = "";
            }
        }
    }
}
