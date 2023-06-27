using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class StateCountry : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCountries();
                BindStates();
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

        private void BindCountries()
        {
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString))
            {
                string query = "SELECT CountryID, CountryName FROM country_master";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();

                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    ddlSearchCountry.DataSource = dt;
                    ddlSearchCountry.DataTextField = "CountryName";
                    ddlSearchCountry.DataValueField = "CountryID";
                    ddlSearchCountry.DataBind();

                    ddlSearchCountry.Items.Insert(0, new ListItem("All Countries", "0"));
                }
            }
        }

        private void BindStates()
        {
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString))
            {
                string query = "SELECT StateID, StateName FROM state_master";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();

                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    ddlSearchState.DataSource = dt;
                    ddlSearchState.DataTextField = "StateName";
                    ddlSearchState.DataValueField = "StateID";
                    ddlSearchState.DataBind();

                    ddlSearchState.Items.Insert(0, new ListItem("All States", "0"));
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string countryId = ddlSearchCountry.SelectedValue;
            string stateId = ddlSearchState.SelectedValue;

            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString))
            {
                string query = "SELECT s.StateName, c.CountryName FROM state_master s INNER JOIN country_master c ON s.CountryID = c.CountryID WHERE 1=1";

                if (countryId != "0")
                {
                    query += " AND c.CountryID = @CountryID";
                }

                if (stateId != "0")
                {
                    query += " AND s.StateID = @StateID";
                }

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (countryId != "0")
                    {
                        cmd.Parameters.AddWithValue("@CountryID", countryId);
                    }

                    if (stateId != "0")
                    {
                        cmd.Parameters.AddWithValue("@StateID", stateId);
                    }

                    con.Open();

                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    gvStateCountry.DataSource = dt;
                    gvStateCountry.DataBind();
                }
            }
        }

        protected void btnAddnew_Click(object sender, EventArgs e)
        {
            pnlAdd.Visible = true;
            pnlShow.Visible = false;
            FnBindCountry();
            FnBindState();
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            FnBindState();
        }

        private void FnBindCountry()
        {
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString))
            {
                string query = "SELECT * FROM country_master";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();

                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    ddlCountry.DataSource = dt;
                    ddlCountry.DataTextField = "CountryName";
                    ddlCountry.DataValueField = "CountryID";
                    ddlCountry.DataBind();
                }
            }
        }

        private void FnBindState()
        {
            string selectedCountryID = ddlCountry.SelectedValue;

            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString))
            {
                string query = "SELECT * FROM state_master WHERE CountryID = @CountryID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CountryID", selectedCountryID);
                    con.Open();

                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);

                    ddlState.DataSource = dt;
                    ddlState.DataTextField = "StateName";
                    ddlState.DataValueField = "StateID";
                    ddlState.DataBind();
                }
            }
        }
    }
}
