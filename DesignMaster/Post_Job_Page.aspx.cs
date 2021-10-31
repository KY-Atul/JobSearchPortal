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
    public partial class Post_Job_Page : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
             
                if(Session["id_for_job_posting"] != null    &&  Session["id_for_job_posting"].ToString() != "")
                {
                    edit_Posted_Job_record();
                }

            }
        }

        public void edit_Posted_Job_record()
        {

            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_Post_Job", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@operation_tbl_Post_Job", "edit");


            cmd.Parameters.AddWithValue("@job_id", Session["id_for_job_posting"]);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cnn.Close();

            txt_job_profile_name.Text = dt.Rows[0]["job_profile"].ToString();
            txt_min_experience.Text = dt.Rows[0]["min_experience"].ToString();
            txt_max_experience.Text = dt.Rows[0]["max_experience"].ToString();

            txt_min_salary.Text = dt.Rows[0]["min_salary"].ToString();
            txt_max_salary.Text = dt.Rows[0]["max_salary"].ToString();
            txt_no_of_vacancies.Text = dt.Rows[0]["no_of_vacancy"].ToString();

            txt_comments.Text = dt.Rows[0]["comments"].ToString();
            
            btn_job_details_save.Text = "Update";
        }



        public void clear()
        {
            txt_job_profile_name.Text = "";
            txt_min_experience.Text = "";
            txt_max_experience.Text = "";
            txt_min_salary.Text = "";
            txt_max_salary.Text = "";
            txt_no_of_vacancies.Text = "";
            txt_comments.Text = "";
            
        }




        protected void btn_job_details_save_Click(object sender, EventArgs e)
        {
            if (btn_job_details_save.Text == "Save")
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_tbl_Post_Job", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation_tbl_Post_Job", "insert");

                cmd.Parameters.AddWithValue("@job_profile", txt_job_profile_name.Text);
                cmd.Parameters.AddWithValue("@min_experience", txt_min_experience.Text);
                cmd.Parameters.AddWithValue("@max_experience", txt_max_experience.Text);
                cmd.Parameters.AddWithValue("@min_salary", txt_min_salary.Text);
                cmd.Parameters.AddWithValue("@max_salary", txt_max_salary.Text);
                cmd.Parameters.AddWithValue("@no_of_vacancy", txt_no_of_vacancies.Text);
                cmd.Parameters.AddWithValue("@comments", txt_comments.Text);
                cmd.Parameters.AddWithValue("@job_posted_by_id", Session["Logged_in_Company_ID"]);

                cmd.ExecuteNonQuery();
                cnn.Close();
                clear();

            }

            else if (btn_job_details_save.Text == "Update")
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_tbl_Post_Job", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation_tbl_Post_Job", "update");
                //
                cmd.Parameters.AddWithValue("@job_profile", txt_job_profile_name.Text);
                cmd.Parameters.AddWithValue("@min_experience", txt_min_experience.Text);
                cmd.Parameters.AddWithValue("@max_experience", txt_max_experience.Text);
                cmd.Parameters.AddWithValue("@min_salary", txt_min_salary.Text);
                //
                cmd.Parameters.AddWithValue("@max_salary", txt_max_salary.Text);
                cmd.Parameters.AddWithValue("@no_of_vacancy", txt_no_of_vacancies.Text);
                cmd.Parameters.AddWithValue("@comments", txt_comments.Text);
                //
                cmd.Parameters.AddWithValue("@job_id", Session["id_for_job_posting"]);
                //
                cmd.ExecuteNonQuery();
                cnn.Close();
                btn_job_details_save.Text = "Save";
                clear();
                Session["id_for_job_posting"] = null;
            }
        }
    }
}