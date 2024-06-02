using System;
using System.Data.SqlClient;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text.Trim();

        if (ValidateUser(username, password))
        {
            Response.Redirect("Dashboard.aspx");
        }
        else
        {
            lblMessage.Text = "Invalid username or password.";
        }
    }

    private bool ValidateUser(string username, string password)
    {
        bool isValid = false;
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Medi2Go;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "SELECT COUNT(1) FROM users WHERE username=@Username AND password=@Password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            con.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            isValid = count == 1;
        }
        return isValid;
    }
}
