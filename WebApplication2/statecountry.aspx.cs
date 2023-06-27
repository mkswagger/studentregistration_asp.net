using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace WebApplication2
{
    public partial class StateCountry : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStateCountry();
            }
        }

        private void BindStateCountry()
        {
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString))
            {
                string query = "SELECT s.StateName, c.CountryName FROM state_master s INNER JOIN country_master c ON s.CountryID = c.CountryID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();

                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    gvStateCountry.DataSource = dt;
                    gvStateCountry.DataBind();
                }
            }
        }
    }
}
