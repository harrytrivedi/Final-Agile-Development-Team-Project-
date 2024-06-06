using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PatientMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Username"] != null)
            {
                lblUsername.Text = "Logged in as: " + Session["Username"].ToString();
            }
            else
            {
                lblUsername.Text = "Not logged in";
            }
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/index.aspx");
    }

}