using System;
using ClassLibrary;
using Medi2GoLibrary.Models;

public partial class BookAppointment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    protected void btnBookAppointment_Click(object sender, EventArgs e)
    {
        try
        {
            // Create a new instance of the Appointment class
            Appointment appointment = new Appointment
            {
                Username = txtUsername.Text,
                AppoTime = txtTime.Text, // Assigning the time as a string
                AppoDate = DateTime.Parse(txtDate.Text).ToString("yyyy-MM-dd"), // Parsing and formatting the date
                DoctorName = ddlDoctorName.SelectedValue
            };

            // Create an instance of the AppointmentCollection class
            AppointmentCollection appointmentCollection = new AppointmentCollection();

            // Add the appointment to the collection, which will save it to the database
            appointmentCollection.Add(appointment);

            // Display success message
            lblMessage.Text = "Appointment booked successfully!";
            lblMessage.ForeColor = System.Drawing.Color.Green;

            // Clear the form fields after successful booking
            ClearFields();
        }
        catch (Exception ex)
        {
            // Display error message
            lblMessage.Text = "Error booking appointment: " + ex.Message;
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void btnManageAppointments_Click(object sender, EventArgs e)
    {
        // Redirect to the ManageAppointments page
        Response.Redirect("manageappos.aspx");
    }

    private void ClearFields()
    {
        txtUsername.Text = string.Empty;
        txtDate.Text = string.Empty;
        txtTime.Text = string.Empty;
        ddlDoctorName.SelectedIndex = 0;
    }
}