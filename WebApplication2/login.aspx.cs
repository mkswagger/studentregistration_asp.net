using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLoginPage.Text= ConfigurationManager.AppSettings["LoginPage"].ToString();
        }


        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            lblMessage.Visible = true;
            if(txtUsername.Text=="admin" && txtPassword.Text=="admin")
            {
                lblMessage.Text = "Login Success";
                lblMessage.ForeColor = Color.Green;
            }
            else
            {
                lblMessage.Text = "Invalid Username or password";
                lblMessage.ForeColor = Color.Red;
            }
        }

       
    }
}