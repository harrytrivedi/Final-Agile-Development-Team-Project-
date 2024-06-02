using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class ManageThera : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindTherapies();
        }
    }

    protected void BindTherapies()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Medi2GoConnectionString"].ConnectionString;
        string query = "SELECT TEId, Username, TheraName, TheraTime, TheraDate FROM Therapies";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridViewTherapies.DataSource = dt;
                GridViewTherapies.DataBind();
            }
        }
    }

    protected void GridViewTherapies_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int teId = Convert.ToInt32(GridViewTherapies.DataKeys[e.RowIndex].Value);
        string connectionString = ConfigurationManager.ConnectionStrings["Medi2GoConnectionString"].ConnectionString;
        string query = "DELETE FROM Therapies WHERE TEId = @TEId";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@TEId", teId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        BindTherapies();
    }
}
