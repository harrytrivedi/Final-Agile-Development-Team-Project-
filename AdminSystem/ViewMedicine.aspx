<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewMedicine.aspx.cs" Inherits="ViewMedicine" MasterPageFile="~/PatientMaster.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>View Medicines</title>
    <link rel="stylesheet" type="text/css" href="../css/stylesheet.css" />
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400;700&display=swap');

        body {
            font-family: 'Poppins', sans-serif;
            font-weight: 700;
            font-style: normal;
            background-color: #000;
            color: #fff;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        .container {
            display: flex;
            flex-direction: column;
            width: 80%;
            height: auto;
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
            padding: 20px;
        }

        .search-box {
            margin-bottom: 20px;
            display: flex;
            width: 100%;
        }

            .search-box input {
                flex-grow: 1;
                padding: 10px;
                font-size: 16px;
                background: linear-gradient(90deg, #ff3131, #ffbd59);
                color: white;
                border: 1px solid #ccc;
                border-radius: 4px;
                box-sizing: border-box;
            }

            .search-box button {
                padding: 10px 20px;
                font-size: 16px;
                background: linear-gradient(90deg, #ff3131, #ffbd59);
                border: none;
                border-radius: 4px;
                color: white;
                cursor: pointer;
                margin-left: 10px;
                font-weight: 700;
            }

                .search-box button:hover {
                    background-color: #ff8c00;
                }

        table {
            width: 100%;
            border-collapse: collapse;
        }

        table, th, td {
            border: 1px solid #ddd;
        }

        th {
            background-color: #ffbd59;
            color: #000;
            padding: 10px;
            text-align: left;
        }

        td {
            background-color: #000;
            color: #fff;
            padding: 10px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Medicines List</h2>
        <div class="search-box">
            <asp:TextBox ID="txtSearch" runat="server" placeholder="Search for medicines..."></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        </div>
        <asp:GridView ID="GridViewMedicines" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="MedName" HeaderText="Medicine Name" />
                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Supplier" HeaderText="Supplier" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>