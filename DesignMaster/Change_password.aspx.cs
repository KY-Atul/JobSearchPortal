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
    public partial class Change_password : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_change_password_status.Text = "";
                
            }
        }

        public void clear()
        {

            txt_confirm_password.Text = "";
            txt_new_password.Text = "";
            txt_old_password.Text = "";
        }

    public void change_password()
        {
            if (txt_confirm_password.Text == txt_new_password.Text && txt_confirm_password.Text!="" && txt_new_password.Text!="" && txt_old_password.Text!="")
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_tbl_UserReg_register", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation_tbl_UserReg_register", "change_password");
                cmd.Parameters.AddWithValue("@new_user_password", txt_new_password.Text);
                cmd.Parameters.AddWithValue("@old_user_password", txt_old_password.Text);
                cmd.Parameters.AddWithValue("@user_id", Session["Logged_in_user_ID"]);
                cmd.ExecuteNonQuery();
                cnn.Close();
                lbl_change_password_status.Text = "Success. Password Changed";
                lbl_change_password_status.ForeColor = System.Drawing.Color.Green;

            }
            else if(txt_confirm_password.Text != txt_new_password.Text && txt_confirm_password.Text != "" && txt_new_password.Text != "" && txt_old_password.Text != "")
            {
                lbl_change_password_status.Text = "Failure...! New password and Confirm password do not match.";
                lbl_change_password_status.ForeColor = System.Drawing.Color.Red;
            }
            else if(txt_confirm_password.Text=="" || txt_new_password.Text=="" || txt_old_password.Text=="")
            {
                lbl_change_password_status.Text = "Please fill all fields.....";
                lbl_change_password_status.ForeColor = System.Drawing.Color.Red;
            }
            clear();
        }

        protected void btn_change_password_Click(object sender, EventArgs e)
        {
            change_password();
        }

        protected void btn_reset_pass_change_Click(object sender, EventArgs e)
        {
            clear();
            lbl_change_password_status.Text = "";
        }
    }


}