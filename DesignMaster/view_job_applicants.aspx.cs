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
    public partial class view_job_applicants : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display_applicants();
            }
        }

        public void display_applicants()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_Post_Job", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@operation_tbl_Post_Job", "display_applicants");


            cmd.Parameters.AddWithValue("@job_posted_by_id", Session["Logged_in_Company_ID"]);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cnn.Close();
            grd.DataSource = dt;
            grd.DataBind();
        }
    }
}