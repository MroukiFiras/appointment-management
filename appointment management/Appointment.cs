using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appointment_management
{
    internal class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public Patient Patient { get; set; }
        public Appointment(int appointmentId, DateTime appointmentDateTime, Patient patient)
        {
            AppointmentId = appointmentId;
            AppointmentDateTime = appointmentDateTime;
            Patient = patient;
        }
    }
}
