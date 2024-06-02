<%@ Page Title="" Language="C#" MasterPageFile="~/PatientMaster.master" AutoEventWireup="true" CodeFile="bookthera.aspx.cs" Inherits="BookThera" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Book Therapy - Medi2Go</title>
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
        <h2>Book Therapy</h2>

        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>

        <div class="input-group">
            <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        </div>

        <div class="input-group">
            <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
            <asp:TextBox ID="txtDate" runat="server" CssClass="datepicker"></asp:TextBox>
            <!-- Use jQuery UI datepicker for date input -->
        </div>

        <div class="input-group">
            <asp:Label ID="lblTime" runat="server" Text="Time"></asp:Label>
            <asp:TextBox ID="txtTime" runat="server" CssClass="timepicker"></asp:TextBox>
            <!-- Use jQuery UI timepicker for time input -->
        </div>

        <div class="input-group">
            <asp:Label ID="lblTheraName" runat="server" Text="Therapy Name"></asp:Label>
            <asp:DropDownList ID="ddlTheraName" runat="server">
                <asp:ListItem Text="Therapy 1" Value="Therapy 1"></asp:ListItem>
                <asp:ListItem Text="Therapy 2" Value="Therapy 2"></asp:ListItem>
                <asp:ListItem Text="Therapy 3" Value="Therapy 3"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="input-group">
            <asp:Button ID="btnBookTherapy" runat="server" Text="Book Therapy" OnClick="btnBookTherapy_Click" />
        </div>

        <div class="input-group">
            <asp:Button ID="btnManageTherapies" runat="server" Text="Manage Therapies" PostBackUrl="~/managethera.aspx" />
        </div>
    </div>
</asp:Content>
