<%@ Page Title="" Language="C#" MasterPageFile="~/PatientMaster.master" AutoEventWireup="true" CodeFile="emergencyform.aspx.cs" Inherits="EmergencyForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form-container">
        <h2>Emergency Request Form</h2>

        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>

        <div class="input-group">
            <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        </div>

        <div class="input-group">
            <asp:Label ID="lblIssues" runat="server" Text="Issues"></asp:Label>
            <asp:TextBox ID="txtIssues" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
        </div>

        <div class="input-group">
            <asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        </div>

        <div class="input-group">
            <asp:Button ID="btnSubmitEmergency" runat="server" Text="Submit Emergency Request" OnClick="btnSubmitEmergency_Click" />
        </div>
    </div>
</asp:Content>
