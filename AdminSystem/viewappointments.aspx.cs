using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class viewappointments : System.Web.UI.Page
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
        appointmentCollection.LoadAppointments();

        GridViewAppointments.DataSource = appointmentCollection.Appointments;
        GridViewAppointments.DataBind();
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
