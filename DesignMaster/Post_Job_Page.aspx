<%@ Page Title="" Language="C#" MasterPageFile="~/Job_Provider_Master_Page.Master" AutoEventWireup="true" CodeBehind="Post_Job_Page.aspx.cs" Inherits="DesignMaster.Post_Job_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Website_Forms" runat="server">
    <center>
    <table cellspacing="5px" cellpadding="5px">
        <tr>
            <td colspan="2" style="text-align:center"><h3>Job Details</h3></td>
        </tr>
        <tr>
            <td>Job Profile Name:</td>
            <td><asp:Textbox ID="txt_job_profile_name" runat="server" BorderStyle="Solid"></asp:Textbox></td>          
        </tr>

        <tr>
            <td>Minimum Experience:</td>
            <td><asp:Textbox ID="txt_min_experience" runat="server" BorderStyle="Solid"></asp:Textbox></td>          
        </tr>

        <tr>
            <td>Maximum Experience:</td>
            <td><asp:Textbox ID="txt_max_experience" runat="server" BorderStyle="Solid"></asp:Textbox></td>          
        </tr>

        <tr>
            <td>Minimum Salary:</td>
            <td><asp:Textbox ID="txt_min_salary" runat="server" BorderStyle="Solid"></asp:Textbox></td>          
        </tr>

        <tr>
            <td>Maximum Salary:</td>
            <td><asp:Textbox ID="txt_max_salary" runat="server" BorderStyle="Solid"></asp:Textbox></td>          
        </tr>

        <tr>
            <td>Number of Vacancies:</td>
            <td><asp:Textbox ID="txt_no_of_vacancies" runat="server" BorderStyle="Solid"></asp:Textbox></td>          
        </tr>

        <tr>
            <td>Comments/Extra Requirements:</td>
            <td><asp:Textbox ID="txt_comments" runat="server" BorderStyle="Solid" TextMode="MultiLine" Rows="6" Columns="40"></asp:Textbox></td>          
        </tr>

    </table>
    <br>
    <br>

    <asp:Button ID="btn_job_details_save" runat="server" OnClick="btn_job_details_save_Click" Text="Save" />
    <%--<a href="Login.aspx">Login</a>--%>
</center>

</asp:Content>
