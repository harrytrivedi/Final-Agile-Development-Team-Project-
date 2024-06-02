<%@ Page Title="" Language="C#" MasterPageFile="~/PatientMaster.master" AutoEventWireup="true" CodeFile="manageemergency.aspx.cs" Inherits="ManageEmergency" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Manage Emergency Requests</h2>
    <div class="appointment-table">
        <asp:GridView ID="GridViewEmergency" runat="server" AutoGenerateColumns="False" CssClass="appointment-grid" OnRowDeleting="GridViewEmergency_RowDeleting" DataKeyNames="EmId">
            <Columns>
                <asp:BoundField DataField="EmId" HeaderText="EmId" ReadOnly="True" />
                <asp:BoundField DataField="Username" HeaderText="Username" />
                <asp:BoundField DataField="Issues" HeaderText="Issues" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" />
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText="Delete" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
