<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Job_Provider_Home.aspx.cs" Inherits="DesignMaster.Job_Provider_Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Website_Forms" runat="server">
<center>
    <table cellspacing="5px" cellpadding="5px">
          <tr>
            <td>Company Name:</td>
            <td><asp:Textbox ID="txt_company_name" runat="server" BorderStyle="Solid"></asp:Textbox></td>          
        </tr>

        <tr>
            <td>URL:</td>
            <td><asp:Textbox ID="txt_company_url" runat="server" BorderStyle="Solid"></asp:Textbox></td>          
        </tr>

        <tr>
            <td>Address:</td>
            <td><asp:Textbox ID="txt_company_address" runat="server" BorderStyle="Solid"></asp:Textbox></td>          
        </tr>

        <tr>
            <td>POC:</td>
            <td><asp:Textbox ID="txt_company_poc" runat="server" BorderStyle="Solid"></asp:Textbox></td>          
        </tr>

        <tr>
            <td>Contact Number:</td>
            <td><asp:Textbox ID="txt_company_number" runat="server" BorderStyle="Solid"></asp:Textbox></td>          
        </tr>

        <tr>
            <td>Email:</td>
            <td><asp:Textbox ID="txt_company_email" runat="server" BorderStyle="Solid"></asp:Textbox></td>          
        </tr>

        <tr>
            <td>Password:</td>
            <td><asp:Textbox ID="txt_company_password" runat="server" BorderStyle="Solid"></asp:Textbox></td>          
        </tr>

        <tr>
            <td>Comments:</td>
            <td><asp:Textbox ID="txt_company_comments" runat="server" BorderStyle="Solid" TextMode="MultiLine" Rows="6" Columns="40"></asp:Textbox></td>          
        </tr>

    </table>
    <br>
    <br>

    <asp:Button ID="btn_company_save" runat="server" OnClick="btn_company_save_Click" Text="Save" />
    <a href="Login.aspx">Login</a>
</center>
</asp:Content>
