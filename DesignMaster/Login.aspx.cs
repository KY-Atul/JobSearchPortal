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
    public partial class Login : System.Web.UI.Page
    {
        //public static int status=0;
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }
        public void clear()
        {
            txtemail.Text = "";
            txtpassword.Text = "";
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (ddl_login_type.SelectedValue == "1")//user
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_tbl_UserReg_register", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation_tbl_UserReg_register", "login");
                cmd.Parameters.AddWithValue("@user_email", txtemail.Text);
                cmd.Parameters.AddWithValue("@user_password", txtpassword.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cnn.Close();
                if ((dt.Rows).Count > 0 && dt.Rows[0]["user_status"].ToString() == "1")
                {
                    lblstatus.Text = "Login Success!";
                    lblstatus.ForeColor = System.Drawing.Color.Green;
                    Session["Logged_in_user_ID"] = dt.Rows[0]["user_id"].ToString();
                    Response.Redirect("User_Home.aspx");
                }
                else if(dt.Rows.Count > 0 && dt.Rows[0]["user_status"].ToString() == "0")
                {
                    lblstatus.Text = "Login Failure...! Not Approved by Admin yet.";
                    lblstatus.ForeColor = System.Drawing.Color.Red;
                }

                else 
                {
                    lblstatus.Text = "Login Failure...! User does not exist.";
                    lblstatus.ForeColor = System.Drawing.Color.Red;
                }

                clear();
            }

            else if (ddl_login_type.SelectedValue == "2")//admin
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_tblAdmin_register", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation_tblAdmin_register", "login");
                cmd.Parameters.AddWithValue("@Admin_email", txtemail.Text);
                cmd.Parameters.AddWithValue("@Admin_password", txtpassword.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cnn.Close();
                if ((dt.Rows).Count > 0)
                {
                    lblstatus.Text = "Login Success!";
                    lblstatus.ForeColor = System.Drawing.Color.Green;
                    Session["Logged_in_Admin_ID"] = dt.Rows[0]["Admin_id"].ToString();
                    Response.Redirect("Admin_Home.aspx");
                }
                else
                {
                    lblstatus.Text = "Login Failure...!";
                    lblstatus.ForeColor = System.Drawing.Color.Red;
                }
                clear();
            }

            else if (ddl_login_type.SelectedValue == "3")//jobprovider
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_tbl_Company_register", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation_tbl_Company_register", "login");
                cmd.Parameters.AddWithValue("@Company_email", txtemail.Text);
                cmd.Parameters.AddWithValue("@Company_password", txtpassword.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cnn.Close();
                if ((dt.Rows).Count > 0 && dt.Rows[0]["company_status"].ToString() == "1")
                {
                    lblstatus.Text = "Login Success!";
                    lblstatus.ForeColor = System.Drawing.Color.Green;
                    Session["Logged_in_Company_ID"] = dt.Rows[0]["Company_id"].ToString();
                    Response.Redirect("Company_Home_2.aspx");
                }
                else if (dt.Rows.Count > 0 && dt.Rows[0]["company_status"].ToString() == "0")
                {
                    lblstatus.Text = "Login Failure...! Not Approved by Admin yet.";
                    lblstatus.ForeColor = System.Drawing.Color.Red;
                }

                else
                {
                    lblstatus.Text = "Login Failure...! Account does not exist.";
                    lblstatus.ForeColor = System.Drawing.Color.Red;
                }
                clear();
            }
        }
    }
}