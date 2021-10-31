<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Master.Master" AutoEventWireup="true" CodeBehind="Admin_Change_password.aspx.cs" Inherits="DesignMaster.Admin_Change_password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Website_Forms" runat="server">
<center>
    <table cellspacing="5px" cellpadding="5px">
        <tr>
            <td colspan="2" style="text-align:center"><h3>Admin Change Password</h3></td>
        </tr>
        <tr>
            <td>Old Password:</td>
            <td><asp:TextBox ID="txt_old_password" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>New Password:</td>
            <td><asp:TextBox ID="txt_new_password" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Confirm Password:</td>
            <td><asp:TextBox ID="txt_confirm_password" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td colspan="2" style="text-align:center"><asp:Label ID="lbl_change_password_status" runat="server"></asp:Label></td>
        </tr>
    </table>

    <br>
    <br>

    <asp:Button ID="btn_change_password" runat="server" Text="Change" OnClick="btn_change_password_Click"/>

    <asp:Button ID="btn_reset_pass_change" runat="server" Text="Cancel" OnClick="btn_reset_pass_change_Click" />
</center>

</asp:Content>
