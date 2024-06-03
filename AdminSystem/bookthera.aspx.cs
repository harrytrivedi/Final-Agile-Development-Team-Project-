using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class BookThera : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateTherapyDropDown();
        }
    }

    protected void btnBookTherapy_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text;
        string therapyName = ddlTheraName.SelectedValue;
        string therapyTime = txtTime.Text;
        string therapyDate = txtDate.Text;
        decimal price = GetTherapyPrice(therapyName);

        if (price > 0)
        {
            // Insert the booking into the database
            string connectionString = ConfigurationManager.ConnectionStrings["Medi2GoConnectionString"].ConnectionString;
            string query = "INSERT INTO Therapies (Username, TheraName, TheraTime, TheraDate, Price) " +
                           "VALUES (@Username, @TheraName, @TheraTime, @TheraDate, @Price)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@TheraName", therapyName);
                    cmd.Parameters.AddWithValue("@TheraTime", therapyTime);
                    cmd.Parameters.AddWithValue("@TheraDate", therapyDate);
                    cmd.Parameters.AddWithValue("@Price", price);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            lblMessage.Text = "Therapy booked successfully!";
        }
        else
        {
            lblMessage.Text = "Error: Failed to retrieve therapy price.";
        }
    }

    protected void ddlTheraName_SelectedIndexChanged(object sender, EventArgs e)
    {
        string therapyName = ddlTheraName.SelectedValue;
        decimal price = GetTherapyPrice(therapyName);
        txtPrice.Text = price.ToString();
    }

    private void PopulateTherapyDropDown()
    {
        // Retrieve therapy names from the database and populate the dropdown list
        string connectionString = ConfigurationManager.ConnectionStrings["Medi2GoConnectionString"].ConnectionString;
        string query = "SELECT TheraName FROM TherapyPack";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string therapyName = reader["TheraName"].ToString();
                        ddlTheraName.Items.Add(new ListItem(therapyName, therapyName));
                    }
                }
            }
        }
    }

    private decimal GetTherapyPrice(string therapyName)
    {
        decimal price = 0;
        string connectionString = ConfigurationManager.ConnectionStrings["Medi2GoConnectionString"].ConnectionString;
        string query = "SELECT Price FROM TherapyPack WHERE TheraName = @TherapyName";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@TherapyName", therapyName);
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    price = Convert.ToDecimal(result);
                }
            }
        }

        return price;
    }
}
