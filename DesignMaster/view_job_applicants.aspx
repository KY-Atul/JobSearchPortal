<%@ Page Title="" Language="C#" MasterPageFile="~/Job_Provider_Master_Page.Master" AutoEventWireup="true" CodeBehind="view_job_applicants.aspx.cs" Inherits="DesignMaster.view_job_applicants" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Website_Forms" runat="server">
    <center>

        <asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" CellSpacing="10" CellPadding="10">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <%# Eval("user_name") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <%# Eval("user_email") %>
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
                <asp:TemplateField HeaderText="Job Profile Applied">
                    <ItemTemplate>
                        <%# Eval("job_profile") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            
        </asp:GridView>
        <br/>
    </center>
</asp:Content>

