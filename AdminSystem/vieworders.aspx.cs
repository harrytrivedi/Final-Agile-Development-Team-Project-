using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class vieworders : System.Web.UI.Page
{
    private OrderCollection orderCollection = new OrderCollection();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindOrders();
        }
    }

    protected void BindOrders()
    {
        orderCollection.LoadOrders();
        GridViewOrders.DataSource = orderCollection.Orders;
        GridViewOrders.DataBind();
    }

    protected void GridViewOrders_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int orderId = Convert.ToInt32(GridViewOrders.DataKeys[e.RowIndex].Value);
        orderCollection.Remove(orderId);
        BindOrders();
    }
}