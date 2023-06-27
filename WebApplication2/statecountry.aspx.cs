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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string countryName = txtNewCountry.Text;
            string stateName = txtNewState.Text;

            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString))
            {
                con.Open();

                // Insert the new country into the country_master table
                string countryInsertQuery = "INSERT INTO country_master (CountryName) VALUES (@CountryName)";
                using (SqlCommand countryInsertCmd = new SqlCommand(countryInsertQuery, con))
                {
                    countryInsertCmd.Parameters.AddWithValue("@CountryName", countryName);
                    countryInsertCmd.ExecuteNonQuery();
                }

                // Retrieve the newly inserted country ID
                string countryIdQuery = "SELECT SCOPE_IDENTITY()";
                using (SqlCommand countryIdCmd = new SqlCommand(countryIdQuery, con))
                {
                    int countryId = Convert.ToInt32(countryIdCmd.ExecuteScalar());

                    // Insert the new state into the state_master table
                    string stateInsertQuery = "INSERT INTO state_master (StateName, CountryID) VALUES (@StateName, @CountryID)";
                    using (SqlCommand stateInsertCmd = new SqlCommand(stateInsertQuery, con))
                    {
                        stateInsertCmd.Parameters.AddWithValue("@StateName", stateName);
                        stateInsertCmd.Parameters.AddWithValue("@CountryID", countryId);
                        stateInsertCmd.ExecuteNonQuery();
                    }
                }
            }

            // Reset the form and rebind the data
            pnlAdd.Visible = false;
            pnlShow.Visible = true;
            //pnlSearch.Visible = true;
            //txtNewCountry.Text = string.Empty;
            //txtNewState.Text = string.Empty;

            BindStateCountry();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlAdd.Visible = false;
            pnlShow.Visible = true;
           
            //txtNewCountry.Text = string.Empty;
            //txtNewState.Text = string.Empty;
        }
    }
}
