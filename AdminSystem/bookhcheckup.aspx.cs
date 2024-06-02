using System;
using System.Data.SqlClient;
using System.Web.UI;

public partial class BookHealthCheckup : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnBookCheckup_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text;
        string packName = ddlPackName.SelectedValue;
        string date = txtDate.Text;
        string time = txtTime.Text;

        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Medi2GoConnectionString"].ConnectionString;
        string query = "INSERT INTO HealthCheckups (Username, PackName, BDate, BTime) VALUES (@Username, @PackName, @BDate, @BTime)";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@PackName", packName);
                cmd.Parameters.AddWithValue("@BDate", date);
                cmd.Parameters.AddWithValue("@BTime", time);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        lblMessage.Text = "Health checkup booked successfully!";
    }

    protected void btnManageCheckups_Click(object sender, EventArgs e)
    {
        Response.Redirect("managecheckups.aspx");
    }
}
