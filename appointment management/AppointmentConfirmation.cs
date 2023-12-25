using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appointment_management
{
    internal class AppointmentConfirmation
    {
        public Patient Patient { get; }
        public string ConfirmationStatus { get; private set; }

        public AppointmentConfirmation(Patient patient)
        {
            Patient = patient;
        }

        public void ConfirmAppointment(string status)
        {
            
            ConfirmationStatus = status;
        }
    }
}
