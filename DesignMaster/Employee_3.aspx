<%@ Page Title="" Language="C#" MasterPageFile="~/Master_for_other_pages.Master" AutoEventWireup="true" CodeBehind="Employee_3.aspx.cs" Inherits="DesignMaster.Employee_3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Website_Forms" runat="server">
    <center>
    <table>
      
        <tr>
            <td>Name:</td>
            <td><asp:Textbox ID="txtname" runat="server" BorderStyle="Solid"></asp:Textbox></td>          
        </tr>

        <tr>
            <td>Gender:</td>
            <td><asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3"></asp:RadioButtonList></td>
        </tr>

        <tr>
            <td>Country:</td>
            <td><asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true" Width="100px"></asp:DropDownList></td>                 
        </tr>

        <tr>
            <td>State:</td>
            <td><asp:DropDownList ID="ddlstate" runat="server" Width="100px"></asp:DropDownList></td>
        </tr>
    </table>
        <br>
    <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" />
    <br />
    
        <br>
        <asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <%# Eval("emp_name") %>
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
                        <asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="_delete_" CommandArgument='<%#Eval("emp_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
            <Columns>
                <asp:TemplateField >
                    <ItemTemplate>
                        <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="_edit_" CommandArgument='<%#Eval("emp_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </br>
</center>
&nbsp;&nbsp;&nbsp; 
</asp:Content>
