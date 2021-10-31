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
    public partial class Manage_Posted_Jobs_by_Admin : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display_Posted_Jobs_gridview();
            }
        }

        public void display_Posted_Jobs_gridview()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_Post_Job", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@operation_tbl_Post_Job", "display_job_to_admin");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cnn.Close();
            grd_Job_Manager.DataSource = dt;
            grd_Job_Manager.DataBind();
        }


        protected void grd_Job_Manager_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "_Active_Suspend_")
            {
                Button btn = e.CommandSource as Button;
                string text = btn.Text;
                if (text == "Activate")
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("sp_tbl_Post_Job", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@operation_tbl_Post_Job", "activate");

                    cmd.Parameters.AddWithValue("@job_id", e.CommandArgument);
                    cmd.ExecuteNonQuery();

                    cnn.Close();
                    btn.Text = "Deactivate";
                }
                else if (text == "Deactivate")
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("sp_tbl_Post_Job", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@operation_tbl_Post_Job", "deactivate");

                    cmd.Parameters.AddWithValue("@job_id", e.CommandArgument);
                    cmd.ExecuteNonQuery();

                    cnn.Close();
                    btn.Text = "Activate";
                }
            }
        }
    }
}