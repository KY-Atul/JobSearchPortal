<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DesignMaster.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Website_Forms" runat="server">
<center>
    <table cellspacing="5px" cellpadding="5px">
        <tr>
            <td>Login Type:</td>
            <td><asp:DropDownList ID="ddl_login_type" runat="server">
                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                <asp:ListItem Value="1" Text="User"></asp:ListItem>
                <asp:ListItem Value="2" Text="Admin"></asp:ListItem>
                <asp:ListItem Value="3" Text="Job Provider"></asp:ListItem>
                </asp:DropDownList></td>
        </tr>

        <tr>
            <td>Email:</td>
            <td><asp:TextBox ID="txtemail" runat="server" BorderStyle="Solid"></asp:TextBox></td>
        </tr>

        
        <tr>
            <td>Password:</td>
            <td><asp:TextBox Id="txtpassword" runat="server" BorderStyle ="Solid"></asp:TextBox></td>
        </tr>
    </table>
    <br />
    <br>
    <div>
        <center>
               </div>
    <asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click" />   <%--<a href="New User Registration.aspx">Sign Up</a>--%>

    <br />
    <br />
    <asp:Label ID="lblstatus" runat="server"></asp:Label>
        </center>
 


</asp:Content>
