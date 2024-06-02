<%@ Page Title="" Language="C#" MasterPageFile="~/PatientMaster.master" AutoEventWireup="true" CodeFile="OrderMed.aspx.cs" Inherits="OrderMed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Order Medicine - Medi2Go</title>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.3/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-3.7.1.js"></script>
    <script src="https://code.jquery.com/ui/1.13.3/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#datepicker").datepicker();
        });

        function updateTotalPrice() {
            var quantity = parseInt(document.getElementById('<%= ddlQuantity.ClientID %>').value);
            var price = parseFloat(document.getElementById('<%= txtPrice.ClientID %>').value);
            var total = quantity * price;
            document.getElementById('<%= txtTotalPrice.ClientID %>').value = total.toFixed(2);
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form-container">
        <h2>Order Medicine</h2>

        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>

        <div class="input-group">
            <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        </div>

        <div class="input-group">
            <asp:Label ID="lblMedName" runat="server" Text="Medicine Name"></asp:Label>
            <asp:DropDownList ID="ddlMedName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMedName_SelectedIndexChanged">
            </asp:DropDownList>
        </div>

        <div class="input-group">
            <asp:Label ID="lblQuantity" runat="server" Text="Quantity"></asp:Label>
            <asp:DropDownList ID="ddlQuantity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlQuantity_SelectedIndexChanged">
                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                <asp:ListItem Text="9" Value="9"></asp:ListItem>
                <asp:ListItem Text="10" Value="10"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="input-group">
            <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="txtPrice" runat="server" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="input-group">
            <asp:Label ID="lblTotalPrice" runat="server" Text="Total Price"></asp:Label>
            <asp:TextBox ID="txtTotalPrice" runat="server" ReadOnly="true"></asp:TextBox>
        </div>

        <div class="input-group">
            <asp:Button ID="btnOrderMedicine" runat="server" Text="Order Medicine" OnClick="btnOrderMedicine_Click" />
        </div>

        <div class="input-group">
            <asp:Button ID="btnManageOrders" runat="server" Text="Manage Orders" PostBackUrl="~/ManageOrders.aspx" />
        </div>
    </div>
</asp:Content>
