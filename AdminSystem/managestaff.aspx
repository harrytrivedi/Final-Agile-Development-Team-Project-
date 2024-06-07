<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manageStaff.aspx.cs" Inherits="ManageStaff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Staff</title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: center;
            font-size: xx-large;
        }
        .spacer {
            display: block;
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p class="auto-style2">
            <strong>Manage Staff</strong>
        </p>
        <div class="auto-style1">
            <asp:Label ID="Label1" runat="server" Text="StaffID"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br class="spacer" />

            <asp:Label ID="Label2" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br class="spacer" />

            <asp:Label ID="Label3" runat="server" Text="Full Name"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br class="spacer" />

            <asp:Label ID="Label4" runat="server" Text="Contact"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br class="spacer" />

            <asp:Label ID="Label5" runat="server" Text="Designation"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br class="spacer" />

            <asp:Label ID="Label6" runat="server" Text="Salary"></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br class="spacer" />

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Text="Delete" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Update" />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Find" />
        </div>
    </form>
</body>
</html>
