<%@ Page Title="" Language="C#" MasterPageFile="~/Job_Provider_Master_Page.Master" AutoEventWireup="true" CodeBehind="Previously_Posted_Job_Page.aspx.cs" Inherits="DesignMaster.Previously_Posted_Job_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Website_Forms" runat="server">

<center>
        <table>
            <tr>
                <td><a href="Post_Job_Page.aspx">Add New Job</a></td>
               
            </tr>
        </table>

        <br>
        <asp:GridView ID="grd_Job_Postings" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_Job_Postings_RowCommand" CellSpacing="10" CellPadding="10">
            <Columns>
                <asp:TemplateField HeaderText="Job Profile">
                    <ItemTemplate>
                        <%# Eval("job_profile") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Minimum Experience">
                    <ItemTemplate>
                        <%# Eval("min_experience") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Maximum Experience">
                    <ItemTemplate>
                        <%# Eval("max_experience") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Minimum Salary">
                    <ItemTemplate>
                        <%# Eval("min_salary") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Maximum Salary">
                    <ItemTemplate>
                        <%# Eval("max_salary") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Vacancy">
                    <ItemTemplate>
                        <%# Eval("no_of_vacancy") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
            
            <Columns>
                <asp:TemplateField HeaderText="Remarks">
                    <ItemTemplate>
                        <%# Eval("comments") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField >
                    <ItemTemplate>
                        <asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="_delete_" CommandArgument='<%#Eval("job_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
            <Columns>
                <asp:TemplateField >
                    <ItemTemplate>
                        <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="_edit_" CommandArgument='<%#Eval("job_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </br>
    </center>
</asp:Content>
