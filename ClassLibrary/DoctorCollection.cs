using ClassLibrary;
using System.Collections.Generic;
using System.Data;
using System;

public class DoctorCollection
{
    private clsDataConnection db = new clsDataConnection();

    public List<clsDoctor> GetAllDoctors()
    {
        db.Execute("GetAllDoctors");
        DataTable dt = db.DataTable;
        List<clsDoctor> doctors = new List<clsDoctor>();

        foreach (DataRow row in dt.Rows)
        {
            clsDoctor doctor = new clsDoctor
            {
                DocId = Convert.ToInt32(row["DocId"]),
                DocName = row["DocName"].ToString(),
                FirstName = row["FirstName"].ToString(),
                LastName = row["LastName"].ToString(),
                Designation = row["Designation"].ToString(),
                Username = row["Username"].ToString(),
                Address = row["Address"].ToString(),
                ContactNO = Convert.ToInt32(row["ContactNO"])
            };
            doctors.Add(doctor);
        }

        return doctors;
    }

    public clsDoctor GetDoctorById(int docId)
    {
        db.AddParameter("@DocId", docId);
        db.Execute("GetDoctorById");
        DataTable dt = db.DataTable;

        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            return new clsDoctor
            {
                DocId = Convert.ToInt32(row["DocId"]),
                DocName = row["DocName"].ToString(),
                FirstName = row["FirstName"].ToString(),
                LastName = row["LastName"].ToString(),
                Designation = row["Designation"].ToString(),
                Username = row["Username"].ToString(),
                Address = row["Address"].ToString(),
                ContactNO = Convert.ToInt32(row["ContactNO"])
            };
        }
        else
        {
            return null;
        }
    }

    public void AddDoctor(clsDoctor doctor)
    {
        db.AddParameter("@DocId", doctor.DocId);
        db.AddParameter("@DocName", doctor.DocName);
        db.AddParameter("@FirstName", doctor.FirstName);
        db.AddParameter("@LastName", doctor.LastName);
        db.AddParameter("@Designation", doctor.Designation);
        db.AddParameter("@Username", doctor.Username);
        db.AddParameter("@Address", doctor.Address);
        db.AddParameter("@ContactNO", doctor.ContactNO);
        db.Execute("AddDoctor");
    }

    public void UpdateDoctor(clsDoctor doctor)
    {
        db.AddParameter("@DocId", doctor.DocId);
        db.AddParameter("@DocName", doctor.DocName);
        db.AddParameter("@FirstName", doctor.FirstName);
        db.AddParameter("@LastName", doctor.LastName);
        db.AddParameter("@Designation", doctor.Designation);
        db.AddParameter("@Username", doctor.Username);
        db.AddParameter("@Address", doctor.Address);
        db.AddParameter("@ContactNO", doctor.ContactNO);
        db.Execute("UpdateDoctor");
    }

    public void DeleteDoctor(int docId)
    {
        db.AddParameter("@DocId", docId);
        db.Execute("DeleteDoctor");
    }
}
