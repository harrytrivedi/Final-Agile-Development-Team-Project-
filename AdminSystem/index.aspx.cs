using ClassLibrary;
using Medi2GoLibrary.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Clear any previous session
        Session.Clear();
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text.Trim();

        // Validate user credentials
        UserCollection userCollection = new UserCollection();
        User user = userCollection.ValidateLogin(username, password);

        if (user != null)
        {
            // Store user details in session
            Session["UserId"] = user.UserId;
            Session["Username"] = user.Username;
            Session["Fullname"] = user.Fullname;
            Session["Email"] = user.Email;
            Session["Level"] = user.Level;

            // Redirect based on user level
            switch (user.Level)
            {
                case 0:
                    Response.Redirect("dashboard.aspx");
                    break;
                case 1:
                    Response.Redirect("DoctorPanel.aspx");
                    break;
                case 2:
                    Response.Redirect("StaffPanel.aspx");
                    break;
                default:
                    lblMessage.Text = "Invalid user level.";
                    break;
            }
        }
        else
        {
            lblMessage.Text = "Invalid username or password.";
        }
    }
}