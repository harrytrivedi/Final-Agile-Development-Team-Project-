﻿using ClassLibrary;
using Medi2GoLibrary.Models;
using System;
using System.Web.UI.WebControls;

public partial class manageappos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindAppointments();
        }
    }

    protected void BindAppointments()
    {
        AppointmentCollection appointmentCollection = new AppointmentCollection();
        string username = Session["Username"] as string;
        if (!string.IsNullOrEmpty(username))
        {
            appointmentCollection.LoadAppointmentsByUsername(username);
            GridViewAppointments.DataSource = appointmentCollection.Appointments;
            GridViewAppointments.DataBind();
        }
        else
        {
            Response.Redirect("~/login.aspx");
        }
    }

    protected void GridViewAppointments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteAppointment")
        {
            int appId = Convert.ToInt32(e.CommandArgument);
            DeleteAppointment(appId);
        }
    }

    private void DeleteAppointment(int appId)
    {
        AppointmentCollection appointmentCollection = new AppointmentCollection();
        appointmentCollection.Remove(appId);

        BindAppointments();
    }
}