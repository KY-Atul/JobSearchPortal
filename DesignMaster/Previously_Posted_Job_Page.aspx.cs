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
    public partial class Previously_Posted_Job_Page : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display_previously_posted_jobs();
            }
        }

        public void display_previously_posted_jobs()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_Post_Job", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@operation_tbl_Post_Job", "display");
            cmd.Parameters.AddWithValue("@job_posted_by_id", Session["Logged_in_Company_ID"]);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cnn.Close();

            grd_Job_Postings.DataSource = dt;
            grd_Job_Postings.DataBind();
        }

        protected void grd_Job_Postings_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "_delete_")
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_tbl_Post_Job",cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation_tbl_Post_Job", "delete");

                cmd.Parameters.AddWithValue("@job_id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                cnn.Close();
                display_previously_posted_jobs();
            }

            else if(e.CommandName == "_edit_")
            {
                Session["id_for_job_posting"] = e.CommandArgument;
                Response.Redirect("Post_Job_Page.aspx");
            }
        }
    }
}