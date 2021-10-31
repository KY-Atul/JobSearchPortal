<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Master.Master" AutoEventWireup="true" CodeBehind="Manage_Job_Provider.aspx.cs" Inherits="DesignMaster.Manage_Job_Provider" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Website_Forms" runat="server">
    <center>
        <table>
            <tr>
                <td><a href="Job_Provider_Home.aspx">Add New Company</a></td>
              
            </tr>
        </table>

        <br>
        <asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_RowCommand" CellSpacing="10" CellPadding="10">
            <Columns>
                <asp:TemplateField HeaderText="Company Name">
                    <ItemTemplate>
                        <%# Eval("Company_name") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <%# Eval("Company_url") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Password">
                    <ItemTemplate>
                        <%# Eval("Company_address") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="HR">
                    <ItemTemplate>
                        <%# Eval("Company_POC") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Contact">
                    <ItemTemplate>
                        <%# Eval("Company_contact") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <%# Eval("Company_email") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            
            <Columns>
                <asp:TemplateField HeaderText="Password">
                    <ItemTemplate>
                        <%# Eval("Company_password") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            
            <Columns>
                <asp:TemplateField HeaderText="Comments">
                    <ItemTemplate>
                        <%# Eval("Company_comments") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
            <Columns>
                <asp:TemplateField >
                    <ItemTemplate>
                        <asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="_delete_" CommandArgument='<%#Eval("company_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
            <Columns>
                <asp:TemplateField >
                    <ItemTemplate>
                        <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="_edit_" CommandArgument='<%#Eval("company_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            
            <Columns>
                <asp:TemplateField >
                    <ItemTemplate>
                        <asp:Button ID="btn_edit_status" runat="server" Text=<%# Eval("company_status").ToString() == "0" ? "Activate" : "Deactivate"%> CommandName="_Active_Suspend_" CommandArgument='<%#Eval("company_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
        </br>
    </center>

</asp:Content>
