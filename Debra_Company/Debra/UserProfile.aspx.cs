using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Debra
{
    public partial class UserProfile : System.Web.UI.Page
    {
        // Connection string from Web.config file
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Bind the GridView with event data on the initial page load
                BindEventGrid();
            }
        }

        private void BindEventGrid()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    // SQL query to select event details
                    string query = "SELECT [event_name], [evant_date], [event_time], [event_place], [event_price] FROM [event_details]";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    // Bind the DataTable to the GridView
                    EventsGridView.DataSource = dt;
                    EventsGridView.DataBind();
                }
            }
            catch (Exception ex)
            {
               
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void EventsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "BuyTicket")
            {
                try
                {
                    // Retrieve the row index stored in the CommandArgument property
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    // Retrieve the row that contains the button clicked by the user
                    GridViewRow row = EventsGridView.Rows[rowIndex];

                    // Extract event details from the row cells
                    string eventName = row.Cells[0].Text; 
                    string eventDate = row.Cells[1].Text; 
                    string eventTime = row.Cells[2].Text; 
                    string eventPlace = row.Cells[3].Text; 
                    string eventPrice = row.Cells[4].Text; 

                    // Save the extracted details into the database
                    SaveTicketDetails(eventName, eventDate, eventTime, eventPlace, eventPrice);
                }
                catch (Exception ex)
                {
                    // Log and display the error message
                    Response.Write("Error: " + ex.Message);
                }
            }
        }

        private void SaveTicketDetails(string eventName, string eventDate, string eventTime, string eventPlace, string eventPrice)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    // SQL query to insert event details into the sells_details_ table
                    string query = "INSERT INTO sells_details_ (sevent_name, sevent_date, sevent_time, sevent_place, sevent_price) VALUES (@EventName, @EventDate, @EventTime, @EventPlace, @EventPrice)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    // Add parameters to the SQL command
                    cmd.Parameters.AddWithValue("@EventName", eventName);
                    cmd.Parameters.AddWithValue("@EventDate", eventDate);
                    cmd.Parameters.AddWithValue("@EventTime", eventTime);
                    cmd.Parameters.AddWithValue("@EventPlace", eventPlace);
                    cmd.Parameters.AddWithValue("@EventPrice", eventPrice);

                    // Open the connection, execute the command and close the connection
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    // Display a success message
                    Response.Write("<script>alert('Ticket purchase successful.');</script>");
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
