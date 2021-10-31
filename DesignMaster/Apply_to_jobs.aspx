<%@ Page Title="" Language="C#" MasterPageFile="~/Master_for_other_pages.Master" AutoEventWireup="true" CodeBehind="Apply_to_jobs.aspx.cs" Inherits="DesignMaster.Apply_to_jobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Website_Forms" runat="server">
<center>
        <table>
            <tr>
               <td>Job Profile</td>
               <td><asp:TextBox ID="txt_job_profile_search" runat="server"></asp:TextBox></td>
                <td><asp:Button ID="search_button" runat="server" Text="Search" OnClick="search_button_Click"/></td>
            </tr>
        </table>

        <br>
        <asp:GridView ID="grd_Job_Apply" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_Job_Apply_RowCommand" CellSpacing="10" CellPadding="10">
            <Columns>
                <asp:TemplateField HeaderText="Job Profile">
                    <ItemTemplate>
                        <%# Eval("job_profile") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Experience">
                    <ItemTemplate>
                        <%# Eval("min_experience") %> to <%# Eval("max_experience") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

    <%--        <Columns>
                <asp:TemplateField HeaderText="Maximum Experience">
                    <ItemTemplate>
                        <%# Eval("max_experience") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>--%>

            <Columns>
                <asp:TemplateField HeaderText="Salary">
                    <ItemTemplate>
                        <%# Eval("min_salary")%> to <%#Eval("max_salary") %> 
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

          <%--  <Columns>
                <asp:TemplateField HeaderText="Maximum Salary">
                    <ItemTemplate>
                        <%# Eval("max_salary") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>--%>

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
                <asp:TemplateField HeaderText="Posted By">
                    <ItemTemplate>
                        <%# Eval("Company_name") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField >
                    <ItemTemplate>
                        <asp:Button ID="btn_apply_to_job" runat="server" Text='<%#Eval("id_of_candidate_who_applied_to_job").ToString() == "0"? "Apply": Eval("id_of_candidate_who_applied_to_job").ToString() == Session["Logged_in_user_ID"].ToString() ? "Applied" : "Apply" %>' CommandName="_apply_" CommandArgument='<%#Eval("job_id") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
  <%--          <Columns>
                <asp:TemplateField >
                    <ItemTemplate>
                        <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="_edit_" CommandArgument='<%#Eval("job_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>--%>
        </asp:GridView>
        <br/>
    </center>

</asp:Content>
