<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manageaccount.aspx.cs" Inherits="ManageAccount" MasterPageFile="~/PatientMaster.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="right-section">
        <h2>Manage Account</h2>
        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
        <div class="input-group">
            <asp:Label ID="lblFullName" runat="server" Text="Full Name"></asp:Label>
            <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
        </div>
        <div class="input-group">
            <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="input-group">
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div class="input-group">
            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </div>
        <div class="input-group">
            <asp:Button ID="btnUpdate" runat="server" Text="Update Account" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete Account" OnClick="btnDelete_Click" />
        </div>
    </div>
</asp:Content>
