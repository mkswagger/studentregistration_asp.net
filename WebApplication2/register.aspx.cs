using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private object lblMessage;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
           string name=txtName.Text.ToString();
           string mobile=txtMobile.Text.ToString();
           string email=txtEmail.Text.ToString();
           string course=ddlCourse.SelectedItem.ToString();
       
           string date=txtDOB.Text.ToString();
           if(txtDOB.Text.Trim().ToString()!= "")
            {
                DateTime dob = DateTime.Parse(txtDOB.Text.ToString());
            }


            if (ImgUpload.HasFiles)
            {
                string filename=ImgUpload.FileName;
                ImgUpload.SaveAs(Server.MapPath("images//" + ImgUpload.FileName));
            }
           
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}