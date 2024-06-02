using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class BookAppointment : System.Web.UI.Page
{
    protected void btnBookAppointment_Click(object sender, EventArgs e)
    {
        // Retrieve values from the form
        string username = txtUsername.Text;
        string appoTime = txtTime.Text;
        string appoDate = txtDate.Text;
        string doctorName = ddlDoctorName.SelectedValue;

        // Create connection string
        string connectionString = ConfigurationManager.ConnectionStrings["Medi2GoConnectionString"].ConnectionString;

        // Define query to insert appointment data into the database
        string query = "INSERT INTO appointments (Username, AppoTime, AppoDate, DoctorName) VALUES (@Username, @AppoTime, @AppoDate, @DoctorName)";

        // Create SqlConnection and SqlCommand objects
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Add parameters to the SqlCommand
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@AppoTime", appoTime);
                command.Parameters.AddWithValue("@AppoDate", appoDate);
                command.Parameters.AddWithValue("@DoctorName", doctorName);

                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if any rows were affected
                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "Appointment booked successfully!";
                    }
                    else
                    {
                        lblMessage.Text = "Failed to book appointment. Please try again.";
                    }
                }
                catch (Exception ex)
                {
                    // Display error message
                    lblMessage.Text = "An error occurred: " + ex.Message;
                }
            }
        }
    }

    protected void btnManageAppointments_Click(object sender, EventArgs e)
    {
            Response.Redirect("manageappos.aspx");
    }
}
