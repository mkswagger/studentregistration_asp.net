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

        protected void Page_Load(object sender, EventArgs e)
        {
            FnBindCourse();
        }

        void FnBindCourse()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            string query = "select * from coursedetails";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);

            ddlCourse.DataSource = dt;
            ddlCourse.DataTextField = "CourseName";
            ddlCourse.DataValueField = "CourseID";
            ddlCourse.DataBind();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
           string name=txtName.Text.ToString();
           string mobile=txtMobile.Text.ToString();
           string email=txtEmail.Text.ToString();
           string course=ddlCourse.SelectedItem.ToString();
       
           string date=txtDOB.Text.ToString().Trim();

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
                string filename=ImgUpload.FileName;
                ImgUpload.SaveAs(Server.MapPath("images//" + ImgUpload.FileName));
            }
           
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}