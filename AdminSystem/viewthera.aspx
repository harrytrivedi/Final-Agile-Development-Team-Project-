<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewthera.aspx.cs" Inherits="viewthera" MasterPageFile="~/PatientMaster.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Manage Therapies</h2>
    <div class="appointment-table">
        <asp:GridView ID="GridViewTherapies" runat="server" AutoGenerateColumns="False" CssClass="appointment-grid" OnRowDeleting="GridViewTherapies_RowDeleting" DataKeyNames="TEId">
            <Columns>
                <asp:BoundField DataField="TEId" HeaderText="TEId" ReadOnly="True" />
                <asp:BoundField DataField="Username" HeaderText="Username" />
                <asp:BoundField DataField="TheraName" HeaderText="Therapy Name" />
                <asp:BoundField DataField="TheraTime" HeaderText="Therapy Time" />
                <asp:BoundField DataField="TheraDate" HeaderText="Therapy Date" />
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText="Delete" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
