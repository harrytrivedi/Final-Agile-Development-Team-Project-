using System;
using System.Collections.Generic;
using System.Data;

namespace ClassLibrary
{
    public class UserCollection
    {
        private List<User> users = new List<User>();

        public List<User> Users
        {
            get { return users; }
            set { users = value; }
        }

        public int Count
        {
            get { return users.Count; }
        }

        public User this[int index]
        {
            get { return users[index]; }
            set { users[index] = value; }
        }

        public void Add(User user)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@Username", user.Username);
            db.AddParameter("@Password", user.Password);
            db.AddParameter("@Fullname", user.Fullname);
            db.AddParameter("@Email", user.Email);
            db.AddParameter("@Level", user.Level);
            db.Execute("spAddUser");
        }

        public void Remove(int userId)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@UserId", userId);
            db.Execute("spDeleteUser");
        }

        public void Update(User user)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@UserId", user.UserId);
            db.AddParameter("@Username", user.Username);
            db.AddParameter("@Password", user.Password);
            db.AddParameter("@Fullname", user.Fullname);
            db.AddParameter("@Email", user.Email);
            db.AddParameter("@Level", user.Level);
            db.Execute("spUpdateUser");
        }

        public void LoadUsers()
        {
            clsDataConnection db = new clsDataConnection();
            db.Execute("spGetAllUsers");
            DataTable dt = db.DataTable;

            foreach (DataRow row in dt.Rows)
            {
                User user = new User
                {
                    UserId = Convert.ToInt32(row["UserId"]),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    Fullname = row["Fullname"].ToString(),
                    Email = row["Email"].ToString(),
                    Level = row["Level"] != DBNull.Value ? Convert.ToInt32(row["Level"]) : 0
                };
                users.Add(user);
            }
        }

        public User FindById(int userId)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@UserId", userId);
            db.Execute("spGetUser");

            if (db.Count == 1)
            {
                DataRow row = db.DataTable.Rows[0];
                return new User
                {
                    UserId = Convert.ToInt32(row["UserId"]),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    Fullname = row["Fullname"].ToString(),
                    Email = row["Email"].ToString(),
                    Level = row["Level"] != DBNull.Value ? Convert.ToInt32(row["Level"]) : 0
                };
            }
            return null;
        }

        public User FindByUsername(string username)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@Username", username);
            db.Execute("spGetUserByUsername");

            if (db.Count == 1)
            {
                DataRow row = db.DataTable.Rows[0];
                return new User
                {
                    UserId = Convert.ToInt32(row["UserId"]),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    Fullname = row["Fullname"].ToString(),
                    Email = row["Email"].ToString(),
                    Level = row["Level"] != DBNull.Value ? Convert.ToInt32(row["Level"]) : 0
                };
            }
            return null;
        }

        public User ValidateLogin(string username, string password)
        {
            clsDataConnection db = new clsDataConnection();
            db.AddParameter("@Username", username);
            db.AddParameter("@Password", password);
            db.Execute("spValidateUser");

            if (db.Count == 1)
            {
                DataRow row = db.DataTable.Rows[0];
                return new User
                {
                    UserId = Convert.ToInt32(row["UserId"]),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    Fullname = row["Fullname"].ToString(),
                    Email = row["Email"].ToString(),
                    Level = row["Level"] != DBNull.Value ? Convert.ToInt32(row["Level"]) : 0
                };
            }
            return null;
        }
    }
}
