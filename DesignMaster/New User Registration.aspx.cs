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
    public partial class New_User_Registration : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CSDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["edit"]!= null && Session["edit"].ToString()!="")
                { 
                    display_UserReg_country();
                    display_UserReg_state();
                    edit_user_record();
                }
                display_UserReg_gender();
                display_UserReg_country();

                //display_UserReg_gridview();
                ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
         
        public void edit_user_record()
        {

            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_UserReg_register", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@operation_tbl_UserReg_register", "edit");
            cmd.Parameters.AddWithValue("@user_id", Session["edit"]);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cnn.Close();
            txtname.Text = dt.Rows[0]["user_name"].ToString();
            txtemail.Text = dt.Rows[0]["user_email"].ToString();
            txtpassword.Text = dt.Rows[0]["user_password"].ToString();
            rblgender.SelectedValue = dt.Rows[0]["user_gender"].ToString();
            ddlcountry.SelectedValue = dt.Rows[0]["user_country"].ToString();
            display_UserReg_state();
            ddlstate.SelectedValue = dt.Rows[0]["user_state"].ToString();
            btnsave.Text = "Update";
            //ViewState["edit"] = Request.QueryString["CmdArg"];
        }

        public void clear()
        {
            txtname.Text = "";
            txtemail.Text = "";
            txtpassword.Text = "";
            rblgender.ClearSelection();
            ddlcountry.SelectedValue = "0";
            ddlstate.SelectedValue = "0";
        }

        public void display_UserReg_gender()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_UserReg_gender", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@operation_tbl_UserReg", "display");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cnn.Close();
            rblgender.DataSource = dt;
            rblgender.DataTextField = "gname";
            rblgender.DataValueField = "gid";
            rblgender.DataBind();
        }

        public void display_UserReg_country()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_UserReg_country", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@operation_tbl_UserReg", "display");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cnn.Close();
            ddlcountry.DataSource = dt;
            ddlcountry.DataTextField = "cname";
            ddlcountry.DataValueField = "cid";
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void display_UserReg_state()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_UserReg_State",cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@operation_tbl_UserReg_state","display");
            cmd.Parameters.AddWithValue("@ctr_id",ddlcountry.SelectedValue);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cnn.Close();
            ddlstate.DataSource = dt;
            ddlstate.DataTextField = "sname";
            ddlstate.DataValueField = "sid";
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));

        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            display_UserReg_state();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_tbl_UserReg_register",cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation_tbl_UserReg_register","insert");
                cmd.Parameters.AddWithValue("@user_name",txtname.Text);
                cmd.Parameters.AddWithValue("@user_email", txtemail.Text);
                cmd.Parameters.AddWithValue("@user_password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@user_gender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@user_country", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@user_state", ddlstate.SelectedValue);
                cmd.ExecuteNonQuery();
                cnn.Close();
                clear();
                //display_UserReg_gridview();
            }
            else if (btnsave.Text == "Update")
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("sp_tbl_UserReg_register", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@operation_tbl_UserReg_register", "update");
                cmd.Parameters.AddWithValue("@user_name", txtname.Text);
                cmd.Parameters.AddWithValue("@user_email", txtemail.Text);
                cmd.Parameters.AddWithValue("@user_password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@user_gender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@user_country", ddlcountry.SelectedValue);
                cmd.Parameters.AddWithValue("@user_state", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@user_id", Session["edit"]);
                cmd.ExecuteNonQuery();
                cnn.Close();
                clear();
                btnsave.Text = "Save";
                Session["edit"] = null;
                //display_UserReg_gridview();
            }
            
        }

        
    }
}