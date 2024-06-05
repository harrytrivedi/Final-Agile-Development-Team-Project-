using Medi2GoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ClassLibrary
{
    public class AppointmentCollection
    {
        private List<Appointment> appointments = new List<Appointment>();

        public List<Appointment> Appointments
        {
            get { return appointments; }
            set { appointments = value; }
        }

        public int Count
        {
            get { return appointments.Count; }
        }

        public Appointment this[int index]
        {
            get { return appointments[index]; }
            set { appointments[index] = value; }
        }

        public void Add(Appointment appointment)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@Username", appointment.Username);
            db.AddParameter("@AppoTime", appointment.AppoTime);
            db.AddParameter("@AppoDate", appointment.AppoDate);
            db.AddParameter("@DoctorName", appointment.DoctorName);
            db.Execute("spAddAppointment");
        }

        public void Remove(int appId)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@AppId", appId);
            db.Execute("spDeleteAppointment");
        }

        public void Update(Appointment appointment)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@AppId", appointment.AppId);
            db.AddParameter("@Username", appointment.Username);
            db.AddParameter("@AppoTime", appointment.AppoTime);
            db.AddParameter("@AppoDate", appointment.AppoDate);
            db.AddParameter("@DoctorName", appointment.DoctorName);
            db.Execute("spUpdateAppointment");
        }

        public void LoadAppointments()
        {
            clsDataConnection db = new clsDataConnection();
            db.Execute("spGetAllAppointments");
            DataTable dt = db.DataTable;

            foreach (DataRow row in dt.Rows)
            {
                Appointment appointment = new Appointment
                {
                    AppId = Convert.ToInt32(row["AppId"]),
                    Username = row["Username"].ToString(),
                    AppoTime = row["AppoTime"].ToString(), // Changed to string
                    AppoDate = ((DateTime)row["AppoDate"]).ToString("yyyy-MM-dd"), // Formatting the date
                    DoctorName = row["DoctorName"].ToString()
                };
                appointments.Add(appointment);
            }
        }

        public Appointment FindById(int appId)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@AppId", appId);
            db.Execute("spGetAppointment");

            if (db.Count == 1)
            {
                DataRow row = db.DataTable.Rows[0];
                return new Appointment
                {
                    AppId = Convert.ToInt32(row["AppId"]),
                    Username = row["Username"].ToString(),
                    AppoTime = row["AppoTime"].ToString(), // Changed to string
                    AppoDate = ((DateTime)row["AppoDate"]).ToString("yyyy-MM-dd"), // Formatting the date
                    DoctorName = row["DoctorName"].ToString()
                };
            }
            return null;
        }
    }
}
