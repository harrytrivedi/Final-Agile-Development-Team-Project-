using ClassLibrary;
using Medi2GoLibrary.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        // Capture user inputs
        string fullName = txtFullName.Text;
        string username = txtUsername.Text;
        string password = txtPassword.Text;
        string email = txtEmail.Text;

        // Validate inputs
        if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
        {
            lblMessage.Text = "All fields are required.";
            return;
        }

        try
        {
            // Create a new user object
            User newUser = new User
            {
                Fullname = fullName,
                Username = username,
                Password = password,
                Email = email,
                Level = 0 // Default level for new users
            };

            // Add the user to the database
            UserCollection userCollection = new UserCollection();
            userCollection.Add(newUser);

            // Redirect to login page
            Response.Redirect("index.aspx");
        }
        catch (Exception ex)
        {
            // Handle any errors that may occur
            lblMessage.Text = "An error occurred: " + ex.Message;
        }
    }
}

