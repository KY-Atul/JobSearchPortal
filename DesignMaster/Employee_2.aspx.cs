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
    public partial class Employee_2 : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display_country();
                display_gender();
                display_gridview();

            }
        }

        public void clear()
        {
            txtname.Text = "";
            txtcode.Text = "";
            ddlcountry.SelectedValue = "0";
            rblgender.ClearSelection();
        }

        public void display_country()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_bind_country",cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@operation_tbl_Country", "display");
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


        public void display_gender()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_bind_gender", cnn);
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

        public void display_gridview()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_employee_2", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@operation_tbl_employee_2", "display");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            grd.DataSource = dt;
            grd.DataBind();
            cnn.Close();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (btnsubmit.Text == "Save")
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_tbl_employee_2", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation_tbl_employee_2", "insert");
                cmd.Parameters.AddWithValue("@emp_name", txtname.Text);
                cmd.Parameters.AddWithValue("@emp_code", txtcode.Text);
                cmd.Parameters.AddWithValue("@emp_country", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@emp_gender", rblgender.SelectedValue);
                cmd.ExecuteNonQuery();
                cnn.Close();
                clear();
                display_gridview();
            }

            else if (btnsubmit.Text == "Update")
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_tbl_employee_2",cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation_tbl_employee_2","update");
                cmd.Parameters.AddWithValue("@emp_name", txtname.Text);
                cmd.Parameters.AddWithValue("@emp_code", txtcode.Text);
                cmd.Parameters.AddWithValue("@emp_country", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@emp_gender",rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@emp_id",ViewState["edit"]);
                cmd.ExecuteNonQuery();
                cnn.Close();
                display_gridview();
                clear();
                btnsubmit.Text = "Save";
            }
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "_delete_")
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_tbl_employee_2", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation_tbl_employee_2", "delete");
                cmd.Parameters.AddWithValue("@emp_id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                cnn.Close();
                display_gridview();
            }

            else if (e.CommandName == "_edit_")
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_tbl_employee_2",cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation_tbl_employee_2", "edit");
                cmd.Parameters.AddWithValue("@emp_id", e.CommandArgument);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                txtname.Text = dt.Rows[0]["emp_name"].ToString();
                txtcode.Text = dt.Rows[0]["emp_code"].ToString();
                ddlcountry.SelectedValue = dt.Rows[0]["emp_country"].ToString();
                rblgender.SelectedValue = dt.Rows[0]["emp_gender"].ToString();
                cnn.Close();
                btnsubmit.Text = "Update";
                ViewState["edit"] = e.CommandArgument;
                display_gridview();
            }
            
        }
    }
}