<%@ Page Title="" Language="C#" MasterPageFile="~/Master_for_other_pages.Master" AutoEventWireup="true" CodeBehind="Employee_1.aspx.cs" Inherits="DesignMaster.Employee_1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Website_Forms" runat="server">
<center>
    <table>

        <tr>
            <td>Name:</td>
            <td><asp:TextBox ID="txtname" runat="server" BorderStyle="Solid" OnTextChanged="txtname_TextChanged"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Employee Code:</td>
            <td><asp:TextBox ID="txtcode" runat="server" BorderStyle="Solid"></asp:TextBox></td>
        </tr>

          <tr>
            <td></td>
            <td><asp:Button ID="btnsubmit" runat="server" Text="Save" OnClick="btnsubmit_Click" /></td>
        </tr>

    </table>
    <table>
        <tr>
            <td>
                <asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <%#Eval("emp_name") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                    <Columns>
                        <asp:TemplateField HeaderText="Employee Code">
                            <ItemTemplate>
                                <%#Eval("emp_code") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="_delete_" CommandArgument='<%#Eval("emp_id") %>' />
                             </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="_edit_" CommandArgument='<%#Eval("emp_id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </td>
        </tr>
    </table>

</center>

</asp:Content>
