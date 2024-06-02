using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class manageappos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindAppointments();
        }
    }

    protected void BindAppointments()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Medi2GoConnectionString"].ConnectionString;
        string query = "SELECT AppId, Username, AppoTime, AppoDate, DoctorName FROM appointments";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridViewAppointments.DataSource = dt;
                GridViewAppointments.DataBind();
            }
        }
    }

    protected void GridViewAppointments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteAppointment")
        {
            int appId = Convert.ToInt32(e.CommandArgument);
            DeleteAppointment(appId);
        }
    }

    private void DeleteAppointment(int appId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Medi2GoConnectionString"].ConnectionString;
        string query = "DELETE FROM appointments WHERE AppId = @AppId";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@AppId", appId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        BindAppointments(); // Rebind the grid to reflect changes
    }
}
