<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="New User Registration.aspx.cs" Inherits="DesignMaster.New_User_Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Website_Forms" runat="server">
<center>
    <table cellspacing="5px" cellpadding="5px">
      
        <tr>
            <td>Name:</td>
            <td><asp:Textbox ID="txtname" runat="server" BorderStyle="Solid"></asp:Textbox></td>          
        </tr>

        <tr>
            <td>Email:</td>
            <td><asp:Textbox ID="txtemail" runat="server" BorderStyle="Solid"></asp:Textbox></td>          
        </tr>

        <tr>
            <td>Password:</td>
            <td><asp:Textbox ID="txtpassword" runat="server" BorderStyle="Solid"></asp:Textbox></td>          
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
    <a href="Login.aspx">Login</a>
    <%--<a href="ManageUser.aspx">View List of Users</a>--%>
    <br />
</center>

</asp:Content>
