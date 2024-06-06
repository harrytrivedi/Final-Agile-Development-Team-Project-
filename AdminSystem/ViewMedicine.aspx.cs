using System;
using System.Web.UI.WebControls;
using ClassLibrary;
using Medi2GoLibrary.Models;
using System.Data;
using System.Collections.Generic;

public partial class ViewMedicine : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridViewMedicines.PageSize = 10;
            LoadMedicines();
        }
    }

    protected void LoadMedicines()
    {
        MedicineCollection medicineCollection = new MedicineCollection();
        medicineCollection.LoadMedicines();
        var topMedicines = medicineCollection.Medicines.Count > 20 ? medicineCollection.Medicines.GetRange(0, 20) : medicineCollection.Medicines;

        GridViewMedicines.DataSource = topMedicines;
        GridViewMedicines.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string searchTerm = txtSearch.Text.Trim();
        if (!string.IsNullOrEmpty(searchTerm))
        {
            SearchMedicines(searchTerm);
        }
        else
        {
            LoadMedicines();
        }
    }

    private void SearchMedicines(string searchTerm)
    {
        clsDataConnection db = new clsDataConnection();
        db.AddParameter("@MedName", "%" + searchTerm + "%");
        db.Execute("spSearchMedicinesByName");

        List<Medicine> medicines = new List<Medicine>();

        foreach (DataRow row in db.DataTable.Rows)
        {
            Medicine medicine = new Medicine
            {
                MedID = Convert.ToInt32(row["MedID"]),
                MedName = row["MedName"].ToString(),
                Price = Convert.ToDecimal(row["Price"]),
                Supplier = row["Supplier"].ToString()
            };
            medicines.Add(medicine);
        }

        GridViewMedicines.DataSource = medicines;
        GridViewMedicines.DataBind();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/dashboard.aspx");
    }

}
