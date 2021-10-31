using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DesignMaster
{
    public partial class Employee_3 : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display_gender();
                display_country();
                display_gridview();
                ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        public void clear()
        {
            txtname.Text = "";
            rblgender.ClearSelection();
            ddlcountry.SelectedValue = "0";
            ddlstate.SelectedValue = "0";
        }

        public void display_gender()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_gender", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@operation_tbl_gender", "display");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cnn.Close();
            rblgender.DataSource = dt;
            rblgender.DataTextField = "gname";
            rblgender.DataValueField = "gid";
            rblgender.DataBind();
        }

        public void display_country()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_country", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@operation_tbl_country", "display");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cnn.Close();
            ddlcountry.DataSource = dt;
            ddlcountry.DataTextField = "cname";
            ddlcountry.DataValueField = "cid";
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void display_dependent_ddl_state()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_state", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@operation_tbl_state", "display");
            cmd.Parameters.AddWithValue("@ctr_id", ddlcountry.SelectedValue);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cnn.Close();
            ddlstate.DataSource = dt;
            ddlstate.DataTextField = "sname";
            ddlstate.DataValueField = "sid";
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            display_dependent_ddl_state();
        }

        public void display_gridview()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_employee", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@operation_tbl_employee","display");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cnn.Close();
            grd.DataSource = dt;
            grd.DataBind();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_tbl_employee", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation_tbl_employee", "insert");
                cmd.Parameters.AddWithValue("@emp_name", txtname.Text);
                cmd.Parameters.AddWithValue("@emp_gender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@emp_country", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@emp_state", ddlstate.SelectedValue);
                cmd.ExecuteNonQuery();
                cnn.Close();
                clear();
                display_gridview();
            }

            else if (btnsave.Text == "Update")
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_tbl_employee", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation_tbl_employee", "update");
                cmd.Parameters.AddWithValue("@emp_name", txtname.Text);
                cmd.Parameters.AddWithValue("@emp_gender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@emp_country", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@emp_state", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@emp_id", ViewState["edit"]);
                cmd.ExecuteNonQuery();
                cnn.Close();
                display_gridview();
                clear();
                btnsave.Text = "Save";
            }
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "_delete_")
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_tbl_employee", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation_tbl_employee", "delete");
                cmd.Parameters.AddWithValue("@emp_id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                cnn.Close();
                display_gridview();
            }

            else if (e.CommandName == "_edit_")
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_tbl_employee", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation_tbl_employee", "edit");
                cmd.Parameters.AddWithValue("@emp_id", e.CommandArgument);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cnn.Close();
                txtname.Text = dt.Rows[0]["emp_name"].ToString();
                rblgender.SelectedValue = dt.Rows[0]["emp_gender"].ToString();
                ddlcountry.SelectedValue = dt.Rows[0]["emp_country"].ToString();
                display_dependent_ddl_state();
                ddlstate.SelectedValue = dt.Rows[0]["emp_state"].ToString();
                display_gridview();
                btnsave.Text = "Update";
                ViewState["edit"] = e.CommandArgument;
            }
        }
    }
}