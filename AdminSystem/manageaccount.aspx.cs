using System;
using System.Web.UI;
using ClassLibrary;

public partial class ManageAccount : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Username"] != null)
            {
                string username = Session["Username"].ToString();
                LoadUserData(username);
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }
    }

    private void LoadUserData(string username)
    {
        UserCollection userCollection = new UserCollection();
        User user = userCollection.FindByUsername(username);

        if (user != null)
        {
            txtFullName.Text = user.Fullname;
            txtUsername.Text = user.Username;
            txtPassword.Text = user.Password;
            txtEmail.Text = user.Email;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Session["Username"] != null)
        {
            string username = Session["Username"].ToString();
            UserCollection userCollection = new UserCollection();
            User user = userCollection.FindByUsername(username);

            if (user != null)
            {
                user.Fullname = txtFullName.Text;
                user.Password = txtPassword.Text;
                user.Email = txtEmail.Text;

                userCollection.Update(user);
                lblMessage.Text = "Account updated successfully.";
            }
        }
        else
        {
            Response.Redirect("index.aspx");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (Session["Username"] != null)
        {
            string username = Session["Username"].ToString();
            UserCollection userCollection = new UserCollection();
            User user = userCollection.FindByUsername(username);

            if (user != null)
            {
                userCollection.Remove(user.UserId);
                Session.Clear();
                Response.Redirect("index.aspx");
            }
        }
        else
        {
            Response.Redirect("index.aspx");
        }
    }
}
