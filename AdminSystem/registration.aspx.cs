using System;
using System.Data.SqlClient;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        string fullName = txtFullName.Text.Trim();
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text.Trim();
        string email = txtEmail.Text.Trim();

        if (RegisterUser(fullName, username, password, email))
        {
            // Redirect to login page or another page upon successful registration
            Response.Redirect("index.aspx");
        }
        else
        {
            lblMessage.Text = "Registration failed. Please try again.";
        }
    }

    private bool RegisterUser(string fullName, string username, string password, string email)
    {
        bool isSuccess = false;

        // Modify the connection string accordingly
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Medi2Go;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO users (fullname, username, password, email, level) VALUES (@FullName, @Username, @Password, @Email, 0)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@FullName", fullName);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@Email", email);

            try
            {
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                isSuccess = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Handle the exception or log it
                // For simplicity, let's set isSuccess to false
                isSuccess = false;
            }
        }

        return isSuccess;
    }
}
