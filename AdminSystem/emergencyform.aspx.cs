using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class EmergencyForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnSubmitEmergency_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Medi2GoConnectionString"].ConnectionString;
        string query = "INSERT INTO Emergency (Username, Issues, Phone) VALUES (@Username, @Issues, @Phone)";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Issues", txtIssues.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        lblMessage.Text = "Emergency request submitted successfully!";
    }
}
