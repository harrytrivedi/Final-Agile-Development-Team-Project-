<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StaffPanel.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Staff Panel - Medi2Go</title>
    <link rel="stylesheet" href="../css/stylesheet.css">
    <script src="https://kit.fontawesome.com/83ff50e3a5.js" crossorigin="anonymous"></script>
</head>
<body class="admin-body">
    <form id="form1" runat="server">
        <nav class="navbar">
            <div class="logo">
                <img src="../images/Medi2GoStaff.png" alt="Medi2Go Staff Logo" />
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
                <a href="managestaff.aspx">
                    <div class="icon">
                        <asp:Image ID="AddStaff" runat="server" ImageUrl="../images/menuclips/addstaff.png" AlternateText="Add Staff" />
                    </div>
                </a>
            </div>

            <div class="admin-option">
                <a href="vieworders.aspx">
                    <div class="icon">
                        <asp:Image ID="Image1" runat="server" ImageUrl="../images/menuclips/vieworderstaff.png" AlternateText="View Orders" />
                    </div>
                </a>
            </div>

            <div class="admin-option">
                <a href="viewthera.aspx">
                    <div class="icon">
                        <asp:Image ID="Image2" runat="server" ImageUrl="../images/menuclips/viewtherabookstaff.png" AlternateText="View Therapies" />
                    </div>
                </a>
            </div>

            <div class="admin-option">
                <a href="viewappointments.aspx">
                    <div class="icon">
                        <asp:Image ID="Image3" runat="server" ImageUrl="../images/menuclips/viewapposstaff.png" AlternateText="View Appointments" />
                    </div>
                </a>
            </div>
        </asp:Panel>
    </form>
    <script src="script.js"></script>
</body>
</html>
