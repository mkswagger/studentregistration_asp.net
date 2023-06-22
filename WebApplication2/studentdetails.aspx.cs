using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

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
              string name = txtSearchName.Text.Trim();
                string gender = rblSearchGender.SelectedItem?.Text;
                string course = ddlSearchCourse.SelectedItem?.Text;

                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString);
                SqlCommand cmd = con.CreateCommand();

                string query = "SELECT ID, Mobile,Name, Gender, Course,Email,DOB,Image,Password FROM [studentdetails].[dbo].[stud_details] WHERE 1=1";

                if (!string.IsNullOrEmpty(name))
                    query += " AND name LIKE @Name";
                if (!string.IsNullOrEmpty(gender) && gender != "All")
                    query += " AND gender = @Gender";
                if (!string.IsNullOrEmpty(course) && course != "All")
                    query += " AND course = @Course";

                cmd.CommandText = query; // Set the command text

                if (!string.IsNullOrEmpty(name))
                    cmd.Parameters.AddWithValue("@Name", name + "%");
                if (!string.IsNullOrEmpty(gender) && gender != "All")
                    cmd.Parameters.AddWithValue("@Gender", gender);
                if (!string.IsNullOrEmpty(course) && course != "All")
                    cmd.Parameters.AddWithValue("@Course", course);

                con.Open();

                DataTable studentDataTable = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(studentDataTable);

                con.Close();

                gvStudentDetails.DataSource = studentDataTable;
                gvStudentDetails.DataBind();
            








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
            int ID = 1;
            int Cmdtype = 1;

            if (btnRegister.Text == "Submit")
            {
                ID = 0;
                Cmdtype = 1;
            }
            if (ViewState["ID"] != null && int.TryParse(ViewState["ID"].ToString(), out int id))
            {
                ID = id;
                Cmdtype = 2;
            }
            else
            {
                // Handle the case when ViewState["ID"] is null or not a valid integer
                // You can set a default value or display an error message
                // For example:
                ID = 0;
                Cmdtype = 1;
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
            ListItem li = new ListItem("All","-1");
            ddlSearchCourse.Items.Insert(0, li);



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
            FnClearData();
            pnlShow.Visible = true;
            pnlAdd.Visible = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            FnGetStudentDetails();
        }

        protected void btnAddnew_Click(object sender, EventArgs e)
        {
            pnlAdd.Visible = true;
            pnlShow.Visible = false;
        }

        protected void gvStudentDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "upd")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                txtName.Text = gvStudentDetails.Rows[index].Cells[1].Text.ToString();
                txtMobile.Text = gvStudentDetails.Rows[index].Cells[2].Text.ToString();
                txtEmail.Text = gvStudentDetails.Rows[index].Cells[3].Text.ToString();

                string genderText = gvStudentDetails.Rows[index].Cells[4].Text.ToString();
                ListItem listItem = rblGgender.Items.FindByText(genderText);

                if (listItem != null)
                {
                    rblGgender.Text = listItem.Value;
                }
                else
                {
                    // Handle the case when no matching item is found
                    // You can set a default value or display an error message
                    rblGgender.SelectedIndex = -1; // Select no item
                }

                pnlShow.Visible = false;
                pnlAdd.Visible = true;
                ViewState["ID"] = gvStudentDetails.Rows[index].Cells[1].Text.ToString();
                btnRegister.Text = "Update";
            }
        }

        protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Code logic to handle the selected index change event of the ddlCourse dropdown
            // Add your desired functionality here
        }
    }
}
