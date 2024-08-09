using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;

namespace Debra
{
    public partial class Partnerevent : System.Web.UI.Page
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
                    string query = "SELECT [event_id], [event_name], [evant_date], [event_time], [event_place], [event_price] FROM [event_details]";

                    //give the da object to the SqlDataAdapter and store the data in the DataTable
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Bind the DataTable to the GridView
                    GridViewEvents.DataSource = dt;
                    GridViewEvents.DataBind();
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
