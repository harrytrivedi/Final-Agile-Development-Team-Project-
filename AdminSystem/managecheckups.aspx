<%@ Page Title="" Language="C#" MasterPageFile="~/PatientMaster.master" AutoEventWireup="true" CodeFile="managecheckups.aspx.cs" Inherits="ManageCheckups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Manage Health Checkups</h2>
    <div class="appointment-table">
        <asp:GridView ID="GridViewCheckups" runat="server" AutoGenerateColumns="False" CssClass="appointment-grid" OnRowDeleting="GridViewCheckups_RowDeleting" DataKeyNames="hcid">
            <Columns>
                <asp:BoundField DataField="hcid" HeaderText="HCID" ReadOnly="True" />
                <asp:BoundField DataField="Username" HeaderText="Username" />
                <asp:BoundField DataField="PackName" HeaderText="Package Name" />
                <asp:BoundField DataField="BTime" HeaderText="Booking Time" />
                <asp:BoundField DataField="BDate" HeaderText="Booking Date" />
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText="Delete" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
