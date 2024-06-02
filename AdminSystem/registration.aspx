<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="Registration" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Registration Page</title>
    <link rel="stylesheet" type="text/css" href="../css/stylesheet.css" />
    <script src="../js/script.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="left-section">
                <div class="logo">
                    <img src="../images/Medi2Go.png" alt="Logo" />
                </div>
                <div class="tagline">
                    <h2>Medical Gateway Between Patients & Doctors</h2>
                </div>
            </div>
            <div class="right-section">
                <h2>Registration</h2>
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                <div class="input-group">
                    <asp:Label ID="lblFullName" runat="server" Text="Full Name"></asp:Label>
                    <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
                </div>
                <div class="input-group">
                    <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
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
                    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
                </div>
                <div class="input-group">
                    <asp:HyperLink ID="lnkLogin" runat="server" Text="Already a user? Login now" NavigateUrl="index.aspx"></asp:HyperLink>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
