using ClassLibrary;
using Medi2GoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class viewthera : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadTherapies();
        }
    }

    private void LoadTherapies()
    {
        TherapyCollection therapyCollection = new TherapyCollection();
        therapyCollection.LoadTherapies();
        GridViewTherapies.DataSource = therapyCollection.Therapies;
        GridViewTherapies.DataBind();
    }

    protected void GridViewTherapies_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int TEId = Convert.ToInt32(GridViewTherapies.DataKeys[e.RowIndex].Value);
        TherapyCollection therapyCollection = new TherapyCollection();
        therapyCollection.Remove(TEId);
        LoadTherapies();
    }

    protected void GridViewTherapies_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewTherapies.EditIndex = e.NewEditIndex;
        LoadTherapies();
    }

    protected void GridViewTherapies_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewTherapies.EditIndex = -1;
        LoadTherapies();
    }

    protected void GridViewTherapies_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int TEId = Convert.ToInt32(GridViewTherapies.DataKeys[e.RowIndex].Value);
        string username = ((TextBox)GridViewTherapies.Rows[e.RowIndex].FindControl("txtUsername")).Text;
        string therapyName = ((TextBox)GridViewTherapies.Rows[e.RowIndex].FindControl("txtTheraName")).Text;
        string therapyTime = ((TextBox)GridViewTherapies.Rows[e.RowIndex].FindControl("txtTheraTime")).Text;
        string therapyDate = ((TextBox)GridViewTherapies.Rows[e.RowIndex].FindControl("txtTheraDate")).Text;
        decimal price = Convert.ToDecimal(((TextBox)GridViewTherapies.Rows[e.RowIndex].FindControl("txtPrice")).Text);

        Therapy therapy = new Therapy
        {
            TEId = TEId,
            Username = username,
            TheraName = therapyName,
            TheraTime = therapyTime,
            TheraDate = therapyDate,
            Price = price
        };

        TherapyCollection therapyCollection = new TherapyCollection();
        therapyCollection.Update(therapy);
        GridViewTherapies.EditIndex = -1;
        LoadTherapies();
    }

    protected void GridViewTherapies_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
        {
            Therapy therapy = (Therapy)e.Row.DataItem;

            TextBox txtUsername = (TextBox)e.Row.FindControl("txtUsername");
            TextBox txtTheraName = (TextBox)e.Row.FindControl("txtTheraName");
            TextBox txtTheraTime = (TextBox)e.Row.FindControl("txtTheraTime");
            TextBox txtTheraDate = (TextBox)e.Row.FindControl("txtTheraDate");
            TextBox txtPrice = (TextBox)e.Row.FindControl("txtPrice");

            txtUsername.Text = therapy.Username;
            txtTheraName.Text = therapy.TheraName;
            txtTheraTime.Text = therapy.TheraTime;
            txtTheraDate.Text = therapy.TheraDate;
            txtPrice.Text = therapy.Price.ToString("F2");
        }
    }
}
