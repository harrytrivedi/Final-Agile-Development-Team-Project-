using System;
using System.Data;

public partial class ManageStaff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Clear textboxes when the page loads for the first time
            ClearTextBoxes();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // Add button click event handler
        AddStaff();
        // Clear textboxes after adding a staff member
        ClearTextBoxes();
    }

    protected void Button2_Click1(object sender, EventArgs e)
    {
        // Delete button click event handler
        DeleteStaff();
        // Clear textboxes after deleting a staff member
        ClearTextBoxes();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        // Update button click event handler
        UpdateStaff();
        // Clear textboxes after updating a staff member
        ClearTextBoxes();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        // Find button click event handler
        FindStaffByID();
    }

    // Method to add a staff member
    private void AddStaff()
    {
        clsDataConnection db = new clsDataConnection();
        db.AddParameter("@Username", TextBox2.Text);
        db.AddParameter("@FullName", TextBox3.Text);
        db.AddParameter("@ContactNumber", TextBox4.Text);
        db.AddParameter("@Designation", TextBox5.Text);
        db.AddParameter("@Salary", TextBox6.Text);
        db.Execute("AddStaff");
    }

    // Method to delete a staff member
    private void DeleteStaff()
    {
        clsDataConnection db = new clsDataConnection();
        db.AddParameter("@Username", TextBox2.Text);
        db.Execute("DeleteStaff");
    }

    // Method to update a staff member
    // Method to update a staff member
    private void UpdateStaff()
    {
        clsDataConnection db = new clsDataConnection();
        db.AddParameter("@Username", TextBox2.Text);       // Username parameter
        db.AddParameter("@FullName", TextBox3.Text);       // FullName parameter
        db.AddParameter("@ContactNumber", TextBox4.Text);  // ContactNumber parameter
        db.AddParameter("@Designation", TextBox5.Text);    // Designation parameter
        db.AddParameter("@Salary", TextBox6.Text);         // Salary parameter
        db.Execute("UpdateStaff");
    }


    // Method to find a staff member by StaffID
    private void FindStaffByID()
    {
        clsDataConnection db = new clsDataConnection();
        db.AddParameter("@StaffID", TextBox1.Text);
        db.Execute("FindStaffByID");

        if (db.Count == 1)
        {
            DataRow row = db.DataTable.Rows[0];
            TextBox2.Text = row["Username"].ToString();
            TextBox3.Text = row["FullName"].ToString();
            TextBox4.Text = row["ContactNO"].ToString();
            TextBox5.Text = row["Designation"].ToString();
            TextBox6.Text = row["Salary"].ToString();
        }
        else
        {
            ClearTextBoxes();
        }
    }

    // Method to clear all textboxes
    private void ClearTextBoxes()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("StaffPanel.aspx");
    }
}
