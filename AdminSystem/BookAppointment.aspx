<%@ Page Title="" Language="C#" MasterPageFile="~/PatientMaster.master" AutoEventWireup="true" CodeFile="BookAppointment.aspx.cs" Inherits="BookAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Book Appointment - Medi2Go</title>
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
        <h2>Book Appointment</h2>

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
            <asp:Label ID="lblDoctorName" runat="server" Text="Doctor Name"></asp:Label>
            <asp:DropDownList ID="ddlDoctorName" runat="server">
                <asp:ListItem Text="Doctor 1" Value="Doctor 1"></asp:ListItem>
                <asp:ListItem Text="Doctor 2" Value="Doctor 2"></asp:ListItem>
                <asp:ListItem Text="Doctor 3" Value="Doctor 3"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="input-group">
            <asp:Button ID="btnBookAppointment" runat="server" Text="Book Appointment" OnClick="btnBookAppointment_Click" />
        </div>

        <div class="input-group">
            <asp:Button ID="btnManageAppointments" runat="server" Text="Manage Appointments" OnClick="btnManageAppointments_Click" />
        </div>
    </div>
</asp:Content>
