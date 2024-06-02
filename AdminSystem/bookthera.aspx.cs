using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class BookThera : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnBookTherapy_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Medi2GoConnectionString"].ConnectionString;
        string query = "INSERT INTO Therapies (Username, TheraName, TheraTime, TheraDate) VALUES (@Username, @TheraName, @TheraTime, @TheraDate)";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@TheraName", ddlTheraName.SelectedValue);
                cmd.Parameters.AddWithValue("@TheraTime", txtTime.Text);
                cmd.Parameters.AddWithValue("@TheraDate", txtDate.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        lblMessage.Text = "Therapy booked successfully!";
    }
}
