<%@ Page Title="" Language="C#" MasterPageFile="~/PatientMaster.master" AutoEventWireup="true" CodeFile="bugreports.aspx.cs" Inherits="bugreports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Report a Bug</h2>
    <div class="bug-report-form">
        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
        
        <div class="input-group">
            <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        </div>

        <div class="input-group">
            <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
        </div>

        <div class="input-group">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
    </div>
</asp:Content>
