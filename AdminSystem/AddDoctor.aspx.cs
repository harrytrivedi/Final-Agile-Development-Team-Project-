using ClassLibrary;
using System;
using System.Web.UI;

public partial class AddDoctor : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        clsDoctor newDoctor = GetNewDoctor();

        DoctorCollection doctorCollection = new DoctorCollection();
        doctorCollection.AddDoctor(newDoctor);

        // Optionally clear the text boxes after adding the doctor
        ClearForm();
    }

    private clsDoctor GetNewDoctor()
    {
        return new clsDoctor
        {
            DocId = int.Parse(TextBox1.Text),
            DocName = TextBox2.Text,
            FirstName = TextBox3.Text,
            LastName = TextBox4.Text,
            Designation = TextBox5.Text,
            Username = TextBox6.Text,
            Address = TextBox7.Text,
            ContactNO = int.Parse(TextBox8.Text)
        };
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        clsDoctor updatedDoctor = new clsDoctor
        {
            DocId = int.Parse(TextBox1.Text),
            DocName = TextBox2.Text,
            FirstName = TextBox3.Text,
            LastName = TextBox4.Text,
            Designation = TextBox5.Text,
            Username = TextBox6.Text,
            Address = TextBox7.Text,
            ContactNO = int.Parse(TextBox8.Text)
        };

        DoctorCollection doctorCollection = new DoctorCollection();
        doctorCollection.UpdateDoctor(updatedDoctor);

        // Optionally clear the text boxes after updating the doctor
        ClearForm();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        int docId = int.Parse(TextBox1.Text);
        DoctorCollection doctorCollection = new DoctorCollection();
        doctorCollection.DeleteDoctor(docId);

        // Optionally clear the text boxes after deleting the doctor
        ClearForm();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {

    }

    private void ClearForm()
    {
        TextBox1.Text = string.Empty;
        TextBox2.Text = string.Empty;
        TextBox3.Text = string.Empty;
        TextBox4.Text = string.Empty;
        TextBox5.Text = string.Empty;
        TextBox6.Text = string.Empty;
        TextBox7.Text = string.Empty;
        TextBox8.Text = string.Empty;
    }

    protected void Button4_Click1(object sender, EventArgs e)
    {
        int docId = int.Parse(TextBox1.Text);
        DoctorCollection doctorCollection = new DoctorCollection();
        clsDoctor foundDoctor = doctorCollection.GetDoctorById(docId);

        if (foundDoctor != null)
        {
            TextBox2.Text = foundDoctor.DocName;
            TextBox3.Text = foundDoctor.FirstName;
            TextBox4.Text = foundDoctor.LastName;
            TextBox5.Text = foundDoctor.Designation;
            TextBox6.Text = foundDoctor.Username;
            TextBox7.Text = foundDoctor.Address;
            TextBox8.Text = foundDoctor.ContactNO.ToString();
        }
        else
        {
            // Doctor not found, clear the textboxes
            ClearForm();
        }
    }

    protected void Button3_Click1(object sender, EventArgs e)
    {
        int docId = int.Parse(TextBox1.Text);
        DoctorCollection doctorCollection = new DoctorCollection();
        doctorCollection.DeleteDoctor(docId);

        // Optionally clear the text boxes after deleting the doctor
        ClearForm();
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("DoctorPanel.aspx");
    }
}