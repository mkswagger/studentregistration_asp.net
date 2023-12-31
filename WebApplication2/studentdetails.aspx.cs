﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
                FnBindCountry();
                FnBindState();
                FnGetStudentDetails();
               
               
            }
            ddlCountry.SelectedIndexChanged += new EventHandler(ddlCountry_SelectedIndexChanged);
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
                int index = Convert.ToInt32(e.CommandArgument);
                ViewState["ID"] = gvStudentDetails.Rows[index].Cells[0].Text.ToString();
                // GridViewRow row = gvStudentDetails.Rows[index];
                ViewState["Cmdtype"] = 2;

                txtName.Text = gvStudentDetails.Rows[index].Cells[1].Text;
                txtMobile.Text = gvStudentDetails.Rows[index].Cells[2].Text;
                txtEmail.Text = gvStudentDetails.Rows[index].Cells[3].Text;

                string genderText = gvStudentDetails.Rows[index].Cells[4].Text;
                ListItem genderItem = rblGgender.Items.FindByText(genderText);
                if (genderItem != null)
                {
                    rblGgender.SelectedValue = genderItem.Value;
                }

                string courseText = gvStudentDetails.Rows[index].Cells[5].Text;
                ListItem courseItem = ddlCourse.Items.FindByText(courseText);
                if (courseItem != null)
                {
                    ddlCourse.SelectedValue = courseItem.Value;
                }


                /* RadioButtonList rblGgender = row.FindControl("rblGgender") as RadioButtonList;

                 if (rblGgender != null)
                 {
                     string gender = rblGgender.SelectedItem?.Text;

                     if (gender != null)
                     {
                         txtName.Text = name;
                         txtMobile.Text = mobile;
                         txtEmail.Text = email;

                         ListItem listItem = rblGgender.Items.FindByText(gender);
                         if (listItem != null)
                         {
                             rblGgender.SelectedValue = listItem.Value;
                         }
                     }
                 }*/

                pnlShow.Visible = false;
                pnlAdd.Visible = true;
               // ViewState["ID"] = row.Cells[1].Text;
                btnRegister.Text = "Update";
            }
            else if (e.CommandName == "dlt")
            {
                int index = Convert.ToInt32(e.CommandArgument);
               // GridViewRow row = gvStudentDetails.Rows[rowIndex];
                //string name = row.Cells[1].Text; // Get the name from the row
                ViewState["ID"] = gvStudentDetails.Rows[index].Cells[0].Text.ToString();
                ViewState["Cmdtype"] = 3;
                // Show the confirmation popup
                pnlPopup.Visible = true;
                mpeConfirmation.Show();
                btnRegister.Text = "Delete";
            }
        }

        protected void ddlSearchCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            FnGetStudentDetails();
        }

        protected void rblSearchGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            FnGetStudentDetails();
        }
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            FnBindState();
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            
            SaveStudentDetails();
            FnGetStudentDetails();
        }



        protected void gvStudentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                string gender = e.Row.Cells[4].Text;

                if (gender == "Male")
                {
                    e.Row.Cells[4].ForeColor = Color.Blue;
                    e.Row.Cells[4].Font.Bold = true;
                    e.Row.BackColor = Color.LightBlue;
                }
                else
                {
                    e.Row.Cells[4].ForeColor = Color.Red;
                    e.Row.Cells[4].Font.Bold = true;
                    e.Row.BackColor = Color.LightPink;
                }
            }
            //if(e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType== DataControlRowType.Header)
            //{
            //    e.Row.Cells[0].Visible = false;
            //}
        }

        private void FnGetStudentDetails()
        {
            string name = txtSearchName.Text.Trim();
            string gender = rblSearchGender.SelectedItem?.Text;
            string course = ddlSearchCourse.SelectedItem?.Text;

            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    string query = "SELECT ID, Mobile, Name, Gender, Course, Email, DOB, Image, Password FROM [studentdetails].[dbo].[stud_details] WHERE 1=1";

                    if (!string.IsNullOrEmpty(name))
                        query += " AND name LIKE @Name";
                    if (!string.IsNullOrEmpty(gender) && gender != "All")
                        query += " AND gender = @Gender";
                    if (!string.IsNullOrEmpty(course) && course != "All")
                        query += " AND course = @Course";

                    cmd.CommandText = query;

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
            }
        }

        private void SaveStudentDetails()
        {
            string name = txtName.Text.Trim();
            string mobile = txtMobile.Text.Trim();
            string email = txtEmail.Text.Trim();
            string course = ddlCourse.SelectedItem?.Text;
            string gender = rblGgender.SelectedItem?.Text;
            string date = txtDOB.Text.Trim();
            string password = txtPassword.Text.Trim();
            string filename = "";

            if (ImgUpload.HasFiles)
            {
                DateTime dob;

                if (!string.IsNullOrEmpty(date) && DateTime.TryParse(date, out dob))
                {
                    string formattedDate = dob.ToString("yyyy-MM-dd");
                }
                else
                {
                    // Handle invalid date format
                }

                filename = ImgUpload.FileName;
                ImgUpload.SaveAs(Server.MapPath("images//" + filename));
            }

            //int id = 1;
            //int cmdtype = 1;


            string ID = "";
            string cmdType = "";
            if (btnRegister.Text == "Submit")
            {
                ID = "0";
                cmdType = "1";
            }
            else if (btnRegister.Text == "Update")
            {
                ID = ViewState["ID"].ToString();
                cmdType = "2";
            }
            else
            {
                ID = ViewState["ID"].ToString();
                cmdType = "3";
            }

            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("Save_Student_Details", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Cmdtype", cmdType);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Mobile", mobile);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@DOB", date);
                    cmd.Parameters.AddWithValue("@Course", course);
                    cmd.Parameters.AddWithValue("@Image", filename);
                    cmd.Parameters.AddWithValue("@Password", password);

                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        private void FnBindCourse()
        {
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("CatCourse", con))
                {
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

                    ddlSearchCourse.Items.Insert(0, new ListItem("All", "-1"));
                }
            }
        }

        private void FnBindCountry()
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString);
            string query = "select * from country_master";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            ddlCountry.DataSource = dt;
            ddlCountry.DataTextField = "CountryName"; // Replace "CountryName" with the actual column name for displaying the country name
            ddlCountry.DataValueField = "CountryID"; // Replace "CountryID" with the actual column name for storing the country ID
            ddlCountry.DataBind();
        }

        private void FnBindState()
        {
            string selectedCountryID = ddlCountry.SelectedValue;

            // Retrieve the states from the database based on the selected country
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString))
            {
                string query = "SELECT * FROM state_master WHERE CountryID = @CountryID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CountryID", selectedCountryID);
                    con.Open();

                    DataTable dt = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt);

                    ddlState.DataSource = dt;
                    ddlState.DataTextField = "StateName";
                    ddlState.DataValueField = "StateID";
                    ddlState.DataBind();
                }
            }
        }
        private void FnClearData()
        {
            txtName.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtPassword.Text = string.Empty;
            rblGgender.ClearSelection();
            ddlCourse.SelectedIndex = 0;
            ImgUpload.Attributes.Clear();
            ViewState["ID"] = null;
            ViewState["Cmdtype"] = null;
            btnRegister.Text = "Register";
        }
    }
}
