<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="dashboard" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Patient Panel - Medi2Go</title>
    <link rel="stylesheet" href="../css/stylesheet.css">
    <script src="https://kit.fontawesome.com/83ff50e3a5.js" crossorigin="anonymous"></script>
</head>
<body class="admin-body">
    <form id="form1" runat="server">
        <nav class="navbar">
            <div class="logo">
                <img src="../images/Medi2GoPatient.png" alt="Medi2Go Logo" />
            </div>
            <ul class="nav-links">
                <li><a href="../dashboard.aspx">Home</a></li>              
                <li><a href="../bookhcheckup.aspx">Checkups</a></li>
                <li><a href="../BookAppointment.aspx">Appointments</a></li>
                <li><a href="../bookthera.aspx">Therapies</a></li>
                <li><a href="../ordermed.aspx">Medicine</a></li>
            </ul>
        </nav>

        <asp:Panel ID="pnlOptions" runat="server" CssClass="admin-options">
            <div class="admin-option">
                <a href="BookAppointment.aspx">
                    <div class="icon">
                        <asp:Image ID="imgBookAppointment" runat="server" ImageUrl="../images/menuclips/bookappointment.jpg" AlternateText="Book Appointment" />
                    </div>
                </a>
            </div>

            <div class="admin-option">
                <a href="bookhcheckup.aspx">
                    <div class="icon">
                        <asp:Image ID="Image1" runat="server" ImageUrl="../images/menuclips/bookhcheckup.jpg" AlternateText="Book Health Checkups" />
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
                <a href="admin_settings.aspx">
                    <div class="icon">
                        <asp:Image ID="Image3" runat="server" ImageUrl="../images/menuclips/manageaccount.jpg" AlternateText="Manage Account" />
                    </div>
                </a>
            </div>

            <div class="admin-option">
                <a href="admin_settings.aspx">
                    <div class="icon">
                        <asp:Image ID="Image4" runat="server" ImageUrl="../images/menuclips/monthlyreports.jpg" AlternateText="Monthly Reports" />
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
                <a href="admin_settings.aspx">
                    <div class="icon">
                        <asp:Image ID="Image6" runat="server" ImageUrl="../images/menuclips/reportbug.jpg" AlternateText="Report a Bug" />
                    </div>
                </a>
            </div>

            <div class="admin-option">
                <a href="admin_settings.aspx">
                    <div class="icon">
                        <asp:Image ID="Image7" runat="server" ImageUrl="../images/menuclips/reportemergency.jpg" AlternateText="Report Emergency" />
                    </div>
                </a>
            </div>

        </asp:Panel>
    </form>
    <script src="script.js"></script>
</body>
</html>
