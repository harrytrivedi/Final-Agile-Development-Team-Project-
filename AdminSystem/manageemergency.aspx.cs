using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class ManageEmergency : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindEmergencyRequests();
        }
    }

    protected void BindEmergencyRequests()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Medi2GoConnectionString"].ConnectionString;
        string query = "SELECT EmId, Username, Issues, Phone FROM Emergency";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridViewEmergency.DataSource = dt;
                GridViewEmergency.DataBind();
            }
        }
    }

    protected void GridViewEmergency_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int emId = Convert.ToInt32(GridViewEmergency.DataKeys[e.RowIndex].Value);
        string connectionString = ConfigurationManager.ConnectionStrings["Medi2GoConnectionString"].ConnectionString;
        string query = "DELETE FROM Emergency WHERE EmId = @EmId";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@EmId", emId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        BindEmergencyRequests();
    }
}
