using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class OrderMed : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnOrderMedicine_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Medi2GoConnectionString"].ConnectionString;
        string query = "INSERT INTO Orders (Username, MedName, Quantity, Price) VALUES (@Username, @MedName, @Quantity, @Price)";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@MedName", ddlMedName.SelectedValue);
                cmd.Parameters.AddWithValue("@Quantity", ddlQuantity.SelectedValue);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        lblMessage.Text = "Medicine ordered successfully!";
    }
}
