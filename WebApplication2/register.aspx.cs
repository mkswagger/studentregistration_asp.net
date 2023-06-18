using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private object lblMessage;
        private object rblGender;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FnBindCourse();
            }
           
        }

        void FnBindCourse()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString);
     
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "CatCourse";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);

            ddlCourse.DataSource = dt;
            ddlCourse.DataTextField = "CourseName";
            ddlCourse.DataValueField = "CourseID";
            ddlCourse.DataBind();
        }

        void SaveStudentDetails()
        {
            string name = txtName.Text.ToString();
            string mobile = txtMobile.Text.ToString();
            string email = txtEmail.Text.ToString();
            string course = ddlCourse.SelectedItem.ToString();
            string gender = rblGgender.SelectedItem.Text.ToString();
            string date = txtDOB.Text.ToString().Trim();
            string password = txtPassword.Text.ToString();
            string filename = "";

            if (ImgUpload.HasFiles)
            {
                DateTime dob;

                if (!string.IsNullOrEmpty(date) && DateTime.TryParse(date, out dob))
                {
                    // Date parsing successful
                    string formattedDate = dob.ToString("yyyy-MM-dd");
                    //lblMessage.Text = "Date of Birth: " + formattedDate;
                }
                else
                {
                    // Date parsing failed
                    //lblMessage.Text = "Invalid Date of Birth";
                }
                string filename = ImgUpload.FileName;
                ImgUpload.SaveAs(Server.MapPath("images//" + filename));
            }

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Save_Student_Details";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Mobile", mobile);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@DOB", date);
            cmd.Parameters.AddWithValue("@Course", course);
            cmd.Parameters.AddWithValue("@Image", filename);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.ExecuteNonQuery();
            cmd.Close();
        }
        void FnClearData()
        {
            txtDOB.Text = "";
            txtEmail.Text = "";
            txtMobile.Text = "";
            ddlCourse.SelectedIndex = 0;
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            SaveStudentDetails();
            FnClearData();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Registered Successfully");
        }

        

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}