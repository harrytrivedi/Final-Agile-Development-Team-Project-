using Medi2GoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ClassLibrary
{
    public class TherapyCollection
    {
        private List<Therapy> therapies = new List<Therapy>();

        public List<Therapy> Therapies
        {
            get { return therapies; }
            set { therapies = value; }
        }

        public int Count
        {
            get { return therapies.Count; }
        }

        public Therapy this[int index]
        {
            get { return therapies[index]; }
            set { therapies[index] = value; }
        }

        public void Add(Therapy therapy)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@Username", therapy.Username);
            db.AddParameter("@TheraName", therapy.TheraName);
            db.AddParameter("@TheraTime", therapy.TheraTime);
            db.AddParameter("@TheraDate", therapy.TheraDate);
            db.AddParameter("@Price", therapy.Price);
            db.Execute("spAddTherapy");
        }

        public void Remove(int TEId)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@TEId", TEId);
            db.Execute("spDeleteTherapy");
        }

        public void Update(Therapy therapy)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@TEId", therapy.TEId);
            db.AddParameter("@Username", therapy.Username);
            db.AddParameter("@TheraName", therapy.TheraName);
            db.AddParameter("@TheraTime", therapy.TheraTime);
            db.AddParameter("@TheraDate", therapy.TheraDate);
            db.AddParameter("@Price", therapy.Price);
            db.Execute("spUpdateTherapy");
        }

        public void LoadTherapies()
        {
            clsDataConnection db = new clsDataConnection();
            db.Execute("spGetAllTherapies");
            DataTable dt = db.DataTable;

            foreach (DataRow row in dt.Rows)
            {
                Therapy therapy = new Therapy
                {
                    TEId = Convert.ToInt32(row["TEId"]),
                    Username = row["Username"].ToString(),
                    TheraName = row["TheraName"].ToString(),
                    TheraTime = row["TheraTime"].ToString(),
                    TheraDate = ((DateTime)row["TheraDate"]).ToString("yyyy-MM-dd"),
                    Price = row["Price"] != DBNull.Value ? Convert.ToDecimal(row["Price"]) : 0m // Handle DBNull for Price
                };
                therapies.Add(therapy);
            }
        }

        public Therapy FindById(int TEId)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@TEId", TEId);
            db.Execute("spGetTherapy");

            if (db.Count == 1)
            {
                DataRow row = db.DataTable.Rows[0];
                return new Therapy
                {
                    TEId = Convert.ToInt32(row["TEId"]),
                    Username = row["Username"].ToString(),
                    TheraName = row["TheraName"].ToString(),
                    TheraTime = row["TheraTime"].ToString(),
                    TheraDate = ((DateTime)row["TheraDate"]).ToString("yyyy-MM-dd"),
                    Price = row["Price"] != DBNull.Value ? Convert.ToDecimal(row["Price"]) : 0m // Handle DBNull for Price
                };
            }
            return null;
        }
    }
}
