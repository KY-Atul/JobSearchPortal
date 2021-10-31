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
    public partial class ManageUser : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display_UserReg_gridview();
            }
        }

        public void display_UserReg_gridview()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_UserReg_register", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@operation_tbl_UserReg_register", "display");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cnn.Close();
            grd.DataSource = dt;
            grd.DataBind();
        }


        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "_delete_")
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_tbl_UserReg_register", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation_tbl_UserReg_register", "delete");
                cmd.Parameters.AddWithValue("@user_id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                cnn.Close();
                display_UserReg_gridview();
            }
            else if (e.CommandName == "_edit_")
            {
                Session["edit"] = e.CommandArgument;
                Response.Redirect("New User Registration.aspx");

            }

            else if (e.CommandName == "_Active_Suspend_")
            {
                Button btn = e.CommandSource as Button;
                string text = btn.Text;
                if (text == "Activate")
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("sp_tbl_UserReg_register", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@operation_tbl_UserReg_register", "activate");

                    cmd.Parameters.AddWithValue("@user_id", e.CommandArgument);
                    cmd.ExecuteNonQuery();
                    
                    cnn.Close();
                    btn.Text = "Deactivate";
                }
                else if (text == "Deactivate")
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("sp_tbl_UserReg_register", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@operation_tbl_UserReg_register", "deactivate");

                    cmd.Parameters.AddWithValue("@user_id", e.CommandArgument);
                    cmd.ExecuteNonQuery();

                    cnn.Close();
                    btn.Text = "Activate";
                }
            }
        }
    }
}