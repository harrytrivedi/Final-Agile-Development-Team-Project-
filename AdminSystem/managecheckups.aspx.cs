using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class ManageCheckups : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCheckups();
        }
    }

    protected void BindCheckups()
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Medi2GoConnectionString"].ConnectionString;
        string query = "SELECT hcid, Username, PackName, BTime, BDate FROM HealthCheckups";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridViewCheckups.DataSource = dt;
                GridViewCheckups.DataBind();
            }
        }
    }

    protected void GridViewCheckups_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int hcid = Convert.ToInt32(GridViewCheckups.DataKeys[e.RowIndex].Value);
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Medi2GoConnectionString"].ConnectionString;
        string query = "DELETE FROM HealthCheckups WHERE hcid = @hcid";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@hcid", hcid);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        BindCheckups();
    }
}
