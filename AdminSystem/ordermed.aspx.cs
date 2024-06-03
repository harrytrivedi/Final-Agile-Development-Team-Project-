using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class OrderMed : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindMedicineDropdown();
        }
    }

    protected void BindMedicineDropdown()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Medi2GoConnectionString"].ConnectionString;
        string query = "SELECT MedID, MedName FROM Medicine";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                ddlMedName.DataSource = reader;
                ddlMedName.DataTextField = "MedName";
                ddlMedName.DataValueField = "MedID";
                ddlMedName.DataBind();
            }
        }
    }

    protected void ddlMedName_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdatePrice();
    }

    protected void ddlQuantity_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateTotalPrice();
    }

    protected void UpdatePrice()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Medi2GoConnectionString"].ConnectionString;
        string query = "SELECT Price FROM Medicine WHERE MedID = @MedID";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@MedID", ddlMedName.SelectedValue);
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    decimal price = Convert.ToDecimal(result);
                    txtPrice.Text = price.ToString("F2");
                    UpdateTotalPrice();
                }
            }
        }
    }

    protected void UpdateTotalPrice()
    {
        decimal price;
        int quantity;

        if (decimal.TryParse(txtPrice.Text, out price) && int.TryParse(ddlQuantity.SelectedValue, out quantity))
        {
            decimal totalPrice = price * quantity;
            txtTotalPrice.Text = totalPrice.ToString("F2");
        }
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
                cmd.Parameters.AddWithValue("@MedName", ddlMedName.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Quantity", ddlQuantity.SelectedValue);
                cmd.Parameters.AddWithValue("@Price", txtTotalPrice.Text);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        lblMessage.Text = "Order placed successfully!";
    }
}
