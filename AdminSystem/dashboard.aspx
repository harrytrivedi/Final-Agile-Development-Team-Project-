<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="dashboard" MasterPageFile="~/PatientMaster.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Dashboard - Medi2Go</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlOptions" runat="server" CssClass="admin-options">
        <div class="admin-option">
            <a href="BookAppointment.aspx">
                <div class="icon">
                    <asp:Image ID="imgBookAppointment" runat="server" ImageUrl="../images/menuclips/bookappointment.jpg" AlternateText="Book Appointment" />
                </div>
            </a>
        </div>

        <div class="admin-option">
            <a href="bookthera.aspx">
                <div class="icon">
                    <asp:Image ID="Image2" runat="server" ImageUrl="../images/menuclips/booktherapies.jpg" AlternateText="Book Therapies" />
                </div>
            </a>
        </div>

        <div class="admin-option">
            <a href="manageaccount.aspx">
                <div class="icon">
                    <asp:Image ID="Image3" runat="server" ImageUrl="../images/menuclips/manageaccount.jpg" AlternateText="Manage Account" />
                </div>
            </a>
        </div>

        <div class="admin-option">
            <a href="ordermed.aspx">
                <div class="icon">
                    <asp:Image ID="Image5" runat="server" ImageUrl="../images/menuclips/ordermedicine.jpg" AlternateText="Order Medicine" />
                </div>
            </a>
        </div>

        <div class="admin-option">
            <a href="viewmedicine.aspx">
                <div class="icon">
                    <asp:Image ID="Image7" runat="server" ImageUrl="../images/menuclips/viewmedicine.png" AlternateText="View Medicine" />
                </div>
            </a>
        </div>
    </asp:Panel>
</asp:Content>
