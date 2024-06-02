<%@ Page Title="" Language="C#" MasterPageFile="~/PatientMaster.master" AutoEventWireup="true" CodeFile="manageappos.aspx.cs" Inherits="manageappos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Manage Appointments</h2>
    <div class="appointment-table">
        <asp:GridView ID="GridViewAppointments" runat="server" AutoGenerateColumns="False" CssClass="appointment-grid" OnRowCommand="GridViewAppointments_RowCommand">
            <Columns>
                <asp:BoundField DataField="AppId" HeaderText="AppId" />
                <asp:BoundField DataField="Username" HeaderText="Username" />
                <asp:BoundField DataField="AppoTime" HeaderText="Appointment Time" />
                <asp:BoundField DataField="AppoDate" HeaderText="Appointment Date" />
                <asp:BoundField DataField="DoctorName" HeaderText="Doctor Name" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" CommandName="DeleteAppointment" CommandArgument='<%# Eval("AppId") %>' Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this appointment?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
