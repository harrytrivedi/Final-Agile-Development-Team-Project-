<%@ Page Title="" Language="C#" MasterPageFile="~/PatientMaster.master" AutoEventWireup="true" CodeFile="managethera.aspx.cs" Inherits="ManageThera" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Manage Therapies</h2>
    <div class="appointment-table">
        <asp:GridView ID="GridViewTherapies" runat="server" AutoGenerateColumns="False" CssClass="appointment-grid" OnRowDeleting="GridViewTherapies_RowDeleting" OnRowEditing="GridViewTherapies_RowEditing" OnRowUpdating="GridViewTherapies_RowUpdating" OnRowCancelingEdit="GridViewTherapies_RowCancelingEdit" OnRowDataBound="GridViewTherapies_RowDataBound" DataKeyNames="TEId">
            <Columns>
                <asp:BoundField DataField="TEId" HeaderText="TEId" ReadOnly="True" />
                <asp:TemplateField HeaderText="Username">
                    <ItemTemplate>
                        <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtUsername" runat="server" Text='<%# Eval("Username") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Therapy Name">
                    <ItemTemplate>
                        <asp:Label ID="lblTheraName" runat="server" Text='<%# Eval("TheraName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtTheraName" runat="server" Text='<%# Eval("TheraName") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Therapy Time">
                    <ItemTemplate>
                        <asp:Label ID="lblTheraTime" runat="server" Text='<%# Eval("TheraTime") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtTheraTime" runat="server" Text='<%# Eval("TheraTime") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Therapy Date">
                    <ItemTemplate>
                        <asp:Label ID="lblTheraDate" runat="server" Text='<%# Eval("TheraDate") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtTheraDate" runat="server" Text='<%# Eval("TheraDate") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price">
                    <ItemTemplate>
                        <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price", "{0:F2}") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPrice" runat="server" Text='<%# Eval("Price", "{0:F2}") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" ButtonType="Button" EditText="Edit" />
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText="Delete" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
