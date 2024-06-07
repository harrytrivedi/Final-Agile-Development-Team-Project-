using ClassLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class StaffCollectionClass
{
    private string connectionString; // Connection string for your database

    public StaffCollectionClass(string connectionString)
    {
        this.connectionString = connectionString;
    }

    // Create a new staff member
    public void AddStaff(Staff staff)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO StaffTable (username, fullName, contactNO, designation, salary) " +
                           "VALUES (@Username, @FullName, @ContactNumber, @Designation, @Salary)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", staff.Username);
            command.Parameters.AddWithValue("@FullName", staff.FullName);
            command.Parameters.AddWithValue("@ContactNumber", staff.ContactNumber);
            command.Parameters.AddWithValue("@Designation", staff.Designation);
            command.Parameters.AddWithValue("@Salary", staff.Salary);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    // Read all staff members
    public List<Staff> GetAllStaff()
    {
        List<Staff> staffList = new List<Staff>();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM StaffTable";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Staff staff = new Staff
                    {
                        Username = reader["username"].ToString(),
                        FullName = reader["fullName"].ToString(),
                        ContactNumber = Convert.ToInt32(reader["contactNO"]),
                        Designation = reader["designation"].ToString(),
                        Salary = Convert.ToInt32(reader["salary"])
                    };
                    staffList.Add(staff);
                }
            }
        }
        return staffList;
    }

    // Update an existing staff member
    public void UpdateStaff(Staff staff)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE StaffTable SET fullName = @FullName, contactNO = @ContactNumber, " +
                           "designation = @Designation, salary = @Salary WHERE username = @Username";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", staff.Username);
            command.Parameters.AddWithValue("@FullName", staff.FullName);
            command.Parameters.AddWithValue("@ContactNumber", staff.ContactNumber);
            command.Parameters.AddWithValue("@Designation", staff.Designation);
            command.Parameters.AddWithValue("@Salary", staff.Salary);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    // Delete a staff member
    public void DeleteStaff(string username)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM StaffTable WHERE username = @Username";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", username);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
