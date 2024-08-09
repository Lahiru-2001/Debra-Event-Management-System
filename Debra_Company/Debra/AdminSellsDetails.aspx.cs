using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Debra
{
    public partial class AdminSellsDetails : System.Web.UI.Page
    {
        // give the database connection string, retrieved from the configuration file
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Bind the GridView with event data on the initial page load
                BindEventGrid();
            }
        }
        //To load data from the database into the GridView, use the BindEventGrid methode.
        private void BindEventGrid()
        {
            try
            {
                //give the connection and using statement use for the close the connection after useing.
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    // SQL query to select event details
                    string query = "SELECT  [sevent_name], [sevent_date], [sevent_time], [sevent_place], [sevent_price] FROM [sells_details_]";

                    //give the da object to the SqlDataAdapter and store the data in the DataTable
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Bind the DataTable to the GridView
                    GridViewEventsSells.DataSource = dt;
                    GridViewEventsSells.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Log and display the error message
                Response.Write("Error: " + ex.Message);
            }
        }
    }
}