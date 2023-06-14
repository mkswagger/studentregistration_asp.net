using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
           string name=txtName.Text.ToString();
           string mobile=txtMobile.Text.ToString();
           string email=txtEmail.Text.ToString();
           string course=ddlCourse.SelectedItem.ToString(); 
           string date=Calender.Text.ToString();
           DateTime dob= DateTime.Parse(date);
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