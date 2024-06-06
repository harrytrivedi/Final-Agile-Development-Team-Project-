using Medi2GoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ClassLibrary
{
    public class TherapyPackCollection
    {
        private List<TherapyPack> therapyPacks = new List<TherapyPack>();

        public List<TherapyPack> TherapyPacks
        {
            get { return therapyPacks; }
            set { therapyPacks = value; }
        }

        public int Count
        {
            get { return therapyPacks.Count; }
        }

        public TherapyPack this[int index]
        {
            get { return therapyPacks[index]; }
            set { therapyPacks[index] = value; }
        }

        public void Add(TherapyPack therapyPack)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@TheraName", therapyPack.TheraName);
            db.AddParameter("@Price", therapyPack.Price);
            db.AddParameter("@DoctorName", therapyPack.DoctorName);
            db.Execute("spAddTherapyPack");
        }

        public void Remove(int TheraID)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@TheraID", TheraID);
            db.Execute("spDeleteTherapyPack");
        }

        public void Update(TherapyPack therapyPack)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@TheraID", therapyPack.TheraID);
            db.AddParameter("@TheraName", therapyPack.TheraName);
            db.AddParameter("@Price", therapyPack.Price);
            db.AddParameter("@DoctorName", therapyPack.DoctorName);
            db.Execute("spUpdateTherapyPack");
        }

        public void LoadTherapyPacks()
        {
            clsDataConnection db = new clsDataConnection();
            db.Execute("spGetAllTherapyPacks");
            DataTable dt = db.DataTable;

            foreach (DataRow row in dt.Rows)
            {
                TherapyPack therapyPack = new TherapyPack
                {
                    TheraID = Convert.ToInt32(row["TheraID"]),
                    TheraName = row["TheraName"].ToString(),
                    Price = Convert.ToDecimal(row["Price"]),
                    DoctorName = row["DoctorName"].ToString()
                };
                therapyPacks.Add(therapyPack);
            }
        }

        public TherapyPack FindById(int TheraID)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@TheraID", TheraID);
            db.Execute("spGetTherapyPack");

            if (db.Count == 1)
            {
                DataRow row = db.DataTable.Rows[0];
                return new TherapyPack
                {
                    TheraID = Convert.ToInt32(row["TheraID"]),
                    TheraName = row["TheraName"].ToString(),
                    Price = Convert.ToDecimal(row["Price"]),
                    DoctorName = row["DoctorName"].ToString()
                };
            }
            return null;
        }
        public TherapyPack FindByName(string therapyName)
        {
            foreach (TherapyPack therapyPack in therapyPacks)
            {
                if (therapyPack.TheraName == therapyName)
                {
                    return therapyPack;
                }
            }
            return null;
        }

    }
}
