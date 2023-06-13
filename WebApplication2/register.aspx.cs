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
            lblMessage.Text = "Invalid Username or password";
            lblMessage.ForeColor = Color.Red;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }
    }
}