<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Master.Master" AutoEventWireup="true" CodeBehind="ManageUser.aspx.cs" Inherits="DesignMaster.ManageUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Website_Forms" runat="server">
    <center>
        <table>
            <tr>
                <td><a href="New User Registration.aspx">Add New User</a></td>
               
            </tr>
        </table>

        <br/>
        <asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_RowCommand" CellSpacing="10" CellPadding="10">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <%# Eval("user_name") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <%# Eval("user_email") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Password">
                    <ItemTemplate>
                        <%# Eval("user_password") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Gender">
                    <ItemTemplate>
                        <%# Eval("gname") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Country">
                    <ItemTemplate>
                        <%# Eval("cname") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="State">
                    <ItemTemplate>
                        <%# Eval("sname") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
            <Columns>
                <asp:TemplateField >
                    <ItemTemplate>
                        <asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="_delete_" CommandArgument='<%#Eval("user_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
            <Columns>
                <asp:TemplateField >
                    <ItemTemplate>
                        <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="_edit_" CommandArgument='<%#Eval("user_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField >
                    <ItemTemplate>
                        <asp:Button ID="btn_edit_status" runat="server" Text=<%# Eval("user_status").ToString() == "0" ? "Activate" : "Deactivate"%> CommandName="_Active_Suspend_" CommandArgument='<%#Eval("user_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>


        </asp:GridView>
        <br/>
    </center>
</asp:Content>
