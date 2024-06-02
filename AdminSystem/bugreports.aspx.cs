using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class bugreports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string description = txtDescription.Text.Trim();

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(description))
        {
            lblMessage.Text = "Please fill in all fields.";
            return;
        }

        string connectionString = ConfigurationManager.ConnectionStrings["Medi2GoConnectionString"].ConnectionString;
        string query = "INSERT INTO BugReports (Username, Description) VALUES (@Username, @Description)";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Description", description);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    lblMessage.Text = "Bug report submitted successfully.";
                    txtUsername.Text = "";
                    txtDescription.Text = "";
                }
                else
                {
                    lblMessage.Text = "Failed to submit bug report. Please try again.";
                }
            }
        }
    }
}
