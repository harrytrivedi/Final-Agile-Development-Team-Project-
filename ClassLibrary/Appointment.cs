using System;

public class Appointment
{
    public int AppId { get; set; }
    public string Username { get; set; }
    public TimeSpan AppoTime { get; set; }
    public DateTime AppoDate { get; set; }
    public string DoctorName { get; set; }
}
