<%@ Page Title="" Language="C#" MasterPageFile="~/PatientMaster.master" AutoEventWireup="true" CodeFile="manageorders.aspx.cs" Inherits="ManageOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Manage Orders</h2>
    <div class="appointment-table">
        <asp:GridView ID="GridViewOrders" runat="server" AutoGenerateColumns="False" CssClass="appointment-grid" OnRowDeleting="GridViewOrders_RowDeleting" DataKeyNames="OrderId">
            <Columns>
                <asp:BoundField DataField="OrderId" HeaderText="OrderId" ReadOnly="True" />
                <asp:BoundField DataField="Username" HeaderText="Username" />
                <asp:BoundField DataField="MedName" HeaderText="Medicine Name" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText="Delete" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
