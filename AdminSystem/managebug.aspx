<%@ Page Title="" Language="C#" MasterPageFile="~/PatientMaster.master" AutoEventWireup="true" CodeFile="managebug.aspx.cs" Inherits="managebug" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Manage Bug Reports</h2>
    <div class="bug-reports-table">
        <asp:GridView ID="GridViewBugReports" runat="server" AutoGenerateColumns="False" CssClass="bug-reports-grid" OnRowDeleting="GridViewBugReports_RowDeleting">
            <Columns>
                <asp:BoundField DataField="BugId" HeaderText="BugId" />
                <asp:BoundField DataField="Username" HeaderText="Username" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText="Delete" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
