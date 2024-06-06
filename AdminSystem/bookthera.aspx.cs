using ClassLibrary;
using Medi2GoLibrary.Models;
using System;
using System.Configuration;
using System.Data;
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
            TherapyCollection therapyCollection = new TherapyCollection();
            Therapy therapy = new Therapy
            {
                Username = username,
                TheraName = therapyName,
                TheraTime = therapyTime,
                TheraDate = therapyDate,
                Price = price
            };
            therapyCollection.Add(therapy);

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
        TherapyPackCollection therapyPackCollection = new TherapyPackCollection();
        therapyPackCollection.LoadTherapyPacks();

        foreach (TherapyPack therapyPack in therapyPackCollection.TherapyPacks)
        {
            ddlTheraName.Items.Add(new ListItem(therapyPack.TheraName, therapyPack.TheraName));
        }
    }

    private decimal GetTherapyPrice(string therapyName)
    {
        decimal price = 0;
        TherapyPackCollection therapyPackCollection = new TherapyPackCollection();
        therapyPackCollection.LoadTherapyPacks();

        foreach (TherapyPack therapyPack in therapyPackCollection.TherapyPacks)
        {
            if (therapyPack.TheraName == therapyName)
            {
                return therapyPack.Price;
            }
        }

        return price;
    }

}
