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
    public partial class Apply_to_jobs : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display_job_grd();
            }
        }

        public void display_job_grd()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_Post_Job", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@operation_tbl_Post_Job", "display_job_to_user");

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cnn.Close();

            grd_Job_Apply.DataSource = dt;
            grd_Job_Apply.DataBind();

        }

        public void apply_to_job()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_Post_Job", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@operation_tbl_Post_Job", "enter_id_of_candidate_who_applied");

            cmd.Parameters.AddWithValue("@job_id", ViewState["unique_job_id"]);
            cmd.Parameters.AddWithValue("@id_of_candidate_who_applied_to_job", Session["Logged_in_user_ID"]);


            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);

            //SqlCommand cmd2 = new SqlCommand("sp_job_application_by_user", cnn);
            //cmd2.CommandType = CommandType.StoredProcedure;
            //cmd2.Parameters.AddWithValue("@ops", "applied");

            //cmd2.Parameters.AddWithValue("@id_of_applicant", Session["Logged_in_user_ID"]);
            //cmd2.Parameters.AddWithValue("@id_of_job_applied_to", ViewState["unique_job_id"]);
            //cmd2.Parameters.AddWithValue("@id_of_company_applied_to", dt.Rows[0]["job_posted_by_id"]);

            cmd.ExecuteNonQuery();

            cnn.Close();
            display_job_grd();

        }

        protected void grd_Job_Apply_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName.ToString() == "_apply_")
            {
                Button btn = e.CommandSource as Button;

                if (btn.Text != "Applied")
                {
                    ViewState["unique_job_id"] = e.CommandArgument;
                    apply_to_job();
                    
                }

                else if (btn.Text == "Applied")
                {
                    btn.Enabled = false;
                }
            }
            display_job_grd();
        }

        protected void search_button_Click(object sender, EventArgs e)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_Post_Job", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@operation_tbl_Post_Job", "search");

            cmd.Parameters.AddWithValue("@search_job_profile", txt_job_profile_search.Text);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cnn.Close();

            grd_Job_Apply.DataSource = dt;
            grd_Job_Apply.DataBind();
        }
    }
}