<%@ Page Title="" Language="C#" MasterPageFile="~/PatientMaster.master" AutoEventWireup="true" CodeFile="bookhcheckup.aspx.cs" Inherits="BookHealthCheckup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Book Health Checkup - Medi2Go</title>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.3/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-3.7.1.js"></script>
    <script src="https://code.jquery.com/ui/1.13.3/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#datepicker").datepicker();
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form-container">
        <h2>Book Health Checkup</h2>

        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>

        <div class="input-group">
            <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        </div>

        <div class="input-group">
            <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
            <asp:TextBox ID="txtDate" runat="server" CssClass="datepicker"></asp:TextBox>
        </div>

        <div class="input-group">
            <asp:Label ID="lblTime" runat="server" Text="Time"></asp:Label>
            <asp:TextBox ID="txtTime" runat="server" CssClass="timepicker"></asp:TextBox>
        </div>

        <div class="input-group">
            <asp:Label ID="lblPackName" runat="server" Text="Package Name"></asp:Label>
            <asp:DropDownList ID="ddlPackName" runat="server">
                <asp:ListItem Text="Pack 1" Value="Pack 1"></asp:ListItem>
                <asp:ListItem Text="Pack 2" Value="Pack 2"></asp:ListItem>
                <asp:ListItem Text="Pack 3" Value="Pack 3"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="input-group">
            <asp:Button ID="btnBookCheckup" runat="server" Text="Book Health Checkup" OnClick="btnBookCheckup_Click" />
        </div>
        
        <div class="input-group">
            <asp:Button ID="btnManageCheckups" runat="server" Text="Manage Health Checkups" OnClick="btnManageCheckups_Click" />
        </div>
    </div>
</asp:Content>
