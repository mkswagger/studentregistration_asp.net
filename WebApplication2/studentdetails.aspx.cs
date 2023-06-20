using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace WebApplication2
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FnBindCourse();
                FnGetStudentDetails();
            }
        }

        void FnGetStudentDetails()
        {
            string name = txtName.Text.ToString();
            string gender = rblGgender.SelectedItem.Text.ToString();
            string courses = ddlCourse.SelectedItem.Text.ToString();

            string connectionString = WebConfigurationManager.ConnectionStrings["conString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT      [Name]   ,[Mobile]     ,[Gender]    ,[Course] FROM [studentdetails].[dbo].[stud_details] WHERE 1=1";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt);
                    con.Close();

                    gvStudentDetails.DataSource = dt;
                    gvStudentDetails.DataBind();
                }
            }
        }

        void SaveStudentDetails()
        {
            string name = txtName.Text.ToString();
            string mobile = txtMobile.Text.ToString();
            string email = txtEmail.Text.ToString();
            string courses = ddlCourse.SelectedItem.Text.ToString();
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
                filename = ImgUpload.FileName;
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
            cmd.Parameters.AddWithValue("@Course", courses);
            cmd.Parameters.AddWithValue("@Image", filename);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.ExecuteNonQuery();
            con.Close(); // Close the SqlConnection object
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

            ddlSearchCourse.DataSource = dt;
            ddlSearchCourse.DataTextField = "CourseName";
            ddlSearchCourse.DataValueField = "CourseID";
            ddlSearchCourse.DataBind();


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
            string script = "alert('Registered Successfully');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "success", script, true);
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlShow.Visible = true;
            pnlAdd.Visible = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddnew_Click(object sender, EventArgs e)
        {
            pnlAdd.Visible = true;
            pnlShow.Visible = false;
        }
    }
}
