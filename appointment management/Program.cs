using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appointment_management
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static List<Patient> tablePatient = new List<Patient>();
        public static List<AppointmentConfirmation> tableConfirmation = new List<AppointmentConfirmation>();
        public static List<Appointment> tableAppointment = new List<Appointment>();

        public static AppointmentConfirmation GetConfirmationStatus(Patient patient)
        {
            return tableConfirmation.FirstOrDefault(c => c.Patient == patient);
        }


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new splashForm1());
        }
    }
}
