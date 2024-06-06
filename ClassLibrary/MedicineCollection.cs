using Medi2GoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ClassLibrary
{
    public class MedicineCollection
    {
        private List<Medicine> medicines = new List<Medicine>();

        public List<Medicine> Medicines
        {
            get { return medicines; }
            set { medicines = value; }
        }

        public int Count
        {
            get { return medicines.Count; }
        }

        public Medicine this[int index]
        {
            get { return medicines[index]; }
            set { medicines[index] = value; }
        }

        public void Add(Medicine medicine)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@MedName", medicine.MedName);
            db.AddParameter("@Price", medicine.Price);
            db.AddParameter("@Supplier", medicine.Supplier);
            db.Execute("spAddMedicine");
        }

        public void Remove(int medId)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@MedID", medId);
            db.Execute("spDeleteMedicine");
        }

        public void Update(Medicine medicine)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@MedID", medicine.MedID);
            db.AddParameter("@MedName", medicine.MedName);
            db.AddParameter("@Price", medicine.Price);
            db.AddParameter("@Supplier", medicine.Supplier);
            db.Execute("spUpdateMedicine");
        }

        public void LoadMedicines()
        {
            clsDataConnection db = new clsDataConnection();
            db.Execute("spGetAllMedicines");
            DataTable dt = db.DataTable;

            foreach (DataRow row in dt.Rows)
            {
                Medicine medicine = new Medicine
                {
                    MedID = Convert.ToInt32(row["MedID"]),
                    MedName = row["MedName"].ToString(),
                    Price = Convert.ToDecimal(row["Price"]),
                    Supplier = row["Supplier"].ToString()
                };
                medicines.Add(medicine);
            }
        }

        public Medicine FindById(int medId)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@MedID", medId);
            db.Execute("spGetMedicine");

            if (db.Count == 1)
            {
                DataRow row = db.DataTable.Rows[0];
                return new Medicine
                {
                    MedID = Convert.ToInt32(row["MedID"]),
                    MedName = row["MedName"].ToString(),
                    Price = Convert.ToDecimal(row["Price"]),
                    Supplier = row["Supplier"].ToString()
                };
            }
            return null;
        }
    }
}
