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
    public partial class Employee_1 : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSDB"].ConnectionString);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display_gridview();
            }

        }

        public void clear()
        {
            txtcode.Text = "";
            txtname.Text = "";
        }

        public void display_gridview()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Operations_employee_1_details", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@operations_tbl_employee_1", "display_gridview");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            grd.DataSource = dt;
            grd.DataBind();
            cnn.Close();
        }

        protected void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (btnsubmit.Text == "Save")
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Operations_employee_1_details", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@emp_name", txtname.Text);
                cmd.Parameters.AddWithValue("@emp_code", txtcode.Text);
                cmd.Parameters.AddWithValue("@operations_tbl_employee_1", "insert");
                cmd.ExecuteNonQuery();
                cnn.Close();
                display_gridview();
                clear();
            }
            else if (btnsubmit.Text == "Update")
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Operations_employee_1_details", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operations_tbl_employee_1", "update");
                cmd.Parameters.AddWithValue("@emp_name", txtname.Text);
                cmd.Parameters.AddWithValue("@emp_code", txtcode.Text);
                cmd.Parameters.AddWithValue("@emp_id", ViewState["edit"]);
                cmd.ExecuteNonQuery();
                cnn.Close();
                clear();
                display_gridview();
                btnsubmit.Text = "Save";
            }
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "_delete_")
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Operations_employee_1_details", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@emp_id", e.CommandArgument);
                cmd.Parameters.AddWithValue("@operations_tbl_employee_1", "delete");
                cmd.ExecuteNonQuery();
                cnn.Close();
                display_gridview();
            }

            else if (e.CommandName == "_edit_")
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Operations_employee_1_details", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operations_tbl_employee_1", "edit");
                cmd.Parameters.AddWithValue("@emp_id",e.CommandArgument);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                txtname.Text = dt.Rows[0]["emp_name"].ToString();
                txtcode.Text = dt.Rows[0]["emp_code"].ToString();
                cnn.Close();
                btnsubmit.Text = "Update";
                ViewState["edit"] = e.CommandArgument;
                
            }
        }
    }
}