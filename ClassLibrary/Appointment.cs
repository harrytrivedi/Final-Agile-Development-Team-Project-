using System;

namespace Medi2GoLibrary.Models
{
    public class Appointment
    {
        public int AppId { get; set; }
        public string Username { get; set; }
        public string AppoTime { get; set; }
        public string AppoDate { get; set; }
        public string DoctorName { get; set; }
    }
}
