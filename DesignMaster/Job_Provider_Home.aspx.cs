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
    public partial class Job_Provider_Home : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["edit_Company"] != null && Session["edit_Company"].ToString() != "")
                {
                    edit_Company_record();
                    
                }
                
            }
        }

        public void edit_Company_record()
        {

            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_Company_register", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@operation_tbl_Company_register", "edit");
            cmd.Parameters.AddWithValue("@company_id", Session["edit_Company"]);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cnn.Close();
            txt_company_name.Text = dt.Rows[0]["Company_name"].ToString();
            txt_company_url.Text = dt.Rows[0]["Company_url"].ToString();
            txt_company_address.Text = dt.Rows[0]["Company_address"].ToString();
            txt_company_poc.Text = dt.Rows[0]["Company_POC"].ToString();
            txt_company_number.Text = dt.Rows[0]["Company_contact"].ToString();
            txt_company_email.Text = dt.Rows[0]["Company_email"].ToString();
            txt_company_password.Text = dt.Rows[0]["Company_password"].ToString();
            txt_company_comments.Text = dt.Rows[0]["Company_comments"].ToString();
            btn_company_save.Text = "Update";
        }


        public void clear()
        {
            txt_company_address.Text = "";
            txt_company_comments.Text = "";
            txt_company_email.Text = "";
            txt_company_name.Text="";
            txt_company_number.Text = "";
            txt_company_password.Text = "";
            txt_company_poc.Text = "";
            txt_company_url.Text = "";
        }

        protected void btn_company_save_Click(object sender, EventArgs e)
        {
            if (btn_company_save.Text == "Save")
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_tbl_Company_register", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation_tbl_Company_register", "insert");
                cmd.Parameters.AddWithValue("@Company_name", txt_company_name.Text);
                cmd.Parameters.AddWithValue("@Company_url", txt_company_url.Text);
                cmd.Parameters.AddWithValue("@Company_address", txt_company_address.Text);
                cmd.Parameters.AddWithValue("@Company_POC", txt_company_poc.Text);
                cmd.Parameters.AddWithValue("@Company_contact", txt_company_number.Text);
                cmd.Parameters.AddWithValue("@Company_email", txt_company_email.Text);
                cmd.Parameters.AddWithValue("@Company_password", txt_company_password.Text);
                cmd.Parameters.AddWithValue("@Company_comments", txt_company_comments.Text);
                cmd.ExecuteNonQuery();
                cnn.Close();
                clear();
               
            }

            else if (btn_company_save.Text == "Update")
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_tbl_Company_register", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation_tbl_Company_register", "update");
                cmd.Parameters.AddWithValue("@Company_name", txt_company_name.Text);
                cmd.Parameters.AddWithValue("@Company_url", txt_company_url.Text);
                cmd.Parameters.AddWithValue("@Company_address", txt_company_address.Text);
                cmd.Parameters.AddWithValue("@Company_POC", txt_company_poc.Text);
                cmd.Parameters.AddWithValue("@Company_contact", txt_company_number.Text);
                cmd.Parameters.AddWithValue("@Company_email", txt_company_email.Text);
                cmd.Parameters.AddWithValue("@Company_password", txt_company_password.Text);
                cmd.Parameters.AddWithValue("@Company_comments", txt_company_comments.Text);
                cmd.Parameters.AddWithValue("@company_id", Session["edit_Company"]);
                cmd.ExecuteNonQuery();
                cnn.Close();
                btn_company_save.Text = "Save";
                clear();
                Session["edit_Company"] = null;
            }

        }
    }
}