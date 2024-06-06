using System;
using System.Web.UI.WebControls;
using Medi2GoLibrary.Models;
using ClassLibrary;

public partial class OrderMed : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindMedicineDropdown();
        }
    }

    protected void BindMedicineDropdown()
    {
        MedicineCollection medicineCollection = new MedicineCollection();
        medicineCollection.LoadMedicines();

        ddlMedName.DataSource = medicineCollection.Medicines;
        ddlMedName.DataTextField = "MedName";
        ddlMedName.DataValueField = "MedID";
        ddlMedName.DataBind();
    }

    protected void ddlMedName_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdatePrice();
    }

    protected void ddlQuantity_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateTotalPrice();
    }

    protected void UpdatePrice()
    {
        int medId = int.Parse(ddlMedName.SelectedValue);
        MedicineCollection medicineCollection = new MedicineCollection();
        Medicine selectedMedicine = medicineCollection.FindById(medId);

        if (selectedMedicine != null)
        {
            txtPrice.Text = selectedMedicine.Price.ToString("F2");
            UpdateTotalPrice();
        }
    }

    protected void UpdateTotalPrice()
    {
        decimal price;
        int quantity;

        if (decimal.TryParse(txtPrice.Text, out price) && int.TryParse(ddlQuantity.SelectedValue, out quantity))
        {
            decimal totalPrice = price * quantity;
            txtTotalPrice.Text = totalPrice.ToString("F2");
        }
    }

    protected void btnOrderMedicine_Click(object sender, EventArgs e)
    {
        // Create a new order
        Order order = new Order
        {
            Username = txtUsername.Text,
            MedName = ddlMedName.SelectedItem.Text,
            Quantity = int.Parse(ddlQuantity.SelectedValue),
            Price = decimal.Parse(txtTotalPrice.Text)
        };

        // Add the order using OrderCollection
        OrderCollection orderCollection = new OrderCollection();
        orderCollection.Add(order);

        lblMessage.Text = "Order placed successfully!";
    }
}
