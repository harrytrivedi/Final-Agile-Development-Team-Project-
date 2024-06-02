using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class ManageOrders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindOrders();
        }
    }

    protected void BindOrders()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Medi2GoConnectionString"].ConnectionString;
        string query = "SELECT OrderId, Username, MedName, Quantity, Price FROM Orders";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridViewOrders.DataSource = dt;
                GridViewOrders.DataBind();
            }
        }
    }

    protected void GridViewOrders_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int orderId = Convert.ToInt32(GridViewOrders.DataKeys[e.RowIndex].Value);
        string connectionString = ConfigurationManager.ConnectionStrings["Medi2GoConnectionString"].ConnectionString;
        string query = "DELETE FROM Orders WHERE OrderId = @OrderId";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@OrderId", orderId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        BindOrders();
    }
}
