using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Debra
{
    public partial class EventManagement : System.Web.UI.Page
    {
        // Database connection string
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        //check the page is loded
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView.DataBind();
            }
        }

        // Add new event button click
        protected void Button2_Click(object sender, EventArgs e)
        {
            //check the event id alrady exist or not and call the addNewEvent methode to add the event.
            if (ValidateInputFields())
            {
                if (checkIfEventIdExists())
                {
                    Response.Write("<script>alert('This ID already exists. Please provide another ID.');</script>");
                }
                else
                {
                    addNewEvent();
                }
            }
        }
        //Empty field validation checking error
        bool ValidateInputFields()
        {
            if (string.IsNullOrWhiteSpace(TextBox1.Text))
            {
                Response.Write("<script>alert('Event ID cannot be empty.');</script>");
                return false;
            }
            if (string.IsNullOrWhiteSpace(TextBox2.Text))
            {
                Response.Write("<script>alert('Event Name cannot be empty.');</script>");
                return false;
            }
            if (string.IsNullOrWhiteSpace(TextBox3.Text))
            {
                Response.Write("<script>alert('Event Date cannot be empty.');</script>");
                return false;
            }
            if (string.IsNullOrWhiteSpace(TextBox4.Text))
            {
                Response.Write("<script>alert('Event Time cannot be empty.');</script>");
                return false;
            }
            if (string.IsNullOrWhiteSpace(TextBox5.Text))
            {
                Response.Write("<script>alert('Event Place cannot be empty.');</script>");
                return false;
            }
            if (string.IsNullOrWhiteSpace(TextBox6.Text))
            {
                Response.Write("<script>alert('Event Price cannot be empty.');</script>");
                return false;
            }
            return true;
        }

        // Add new event method
        void addNewEvent()
        {
            try
            {
                //get the database connection
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    //insert data to the event details tables
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO event_details (event_id,event_name,evant_date,event_time,event_place,event_price) VALUES (@E_id, @E_name, @E_date, @E_time, @E_place, @E_price)", con))
                    {
                        // parameters assigned with the textboxs
                        cmd.Parameters.AddWithValue("@E_id", TextBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@E_name", TextBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@E_date", TextBox3.Text.Trim()); 
                        cmd.Parameters.AddWithValue("@E_time", TextBox4.Text.Trim()); 
                        cmd.Parameters.AddWithValue("@E_place", TextBox5.Text.Trim());
                        cmd.Parameters.AddWithValue("@E_price", TextBox6.Text.Trim());

                        // Execute the command and returns rows and deisplay successfully or error massage
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('Event added successfully.');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Event addition failed.');</script>");
                            
                        }
                        clearForm();
                        GridView.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        // Check if event ID already exists
        bool checkIfEventIdExists()
        {

            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    //select the event id and check that event id alrady in the database or not based on provided user id
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM event_details WHERE event_id = @E_id", con))
                    {
                        // parameters assigned with the textboxs
                        cmd.Parameters.AddWithValue("@E_id", TextBox1.Text.Trim());
                        // check and  retrieves the resul there is a  matching records and its conver to the int
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        //f the count is greater than 0, it means the event ID exists in the database.
                        return count > 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                //error message
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                return false;
            }
        }

        // Placeholder for update event
        protected void Button3_Click(object sender, EventArgs e)
        {
            //check the event id exists and call the updatevent methode
            if (checkIfEventIdExists())
            {
                updateEvent();
            }
            else
            {
                Response.Write("<script>alert('Event Id Does not exist');</script>");
            }
        }

        void updateEvent()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    //Sql command for the update the table data
                    string query = "UPDATE event_details SET event_name=@E_name, evant_date=@E_date, event_time=@E_time, event_place=@E_place, event_price=@E_price WHERE event_id=@E_id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@E_id", TextBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@E_name", TextBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@E_date", TextBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@E_time", TextBox4.Text.Trim());
                        cmd.Parameters.AddWithValue("@E_place", TextBox5.Text.Trim());
                        cmd.Parameters.AddWithValue("@E_price", TextBox6.Text.Trim());

                        //executing SQL commands
                        cmd.ExecuteNonQuery();
                    }
                }

                Response.Write("<script>alert('Event updated successfully.');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                
            }
            clearForm();
            GridView.DataBind();
        }


        // Placeholder for delete event
        protected void Button4_Click(object sender, EventArgs e)
        {
            //check the event id exists and call the deleteevent methode
            if (checkIfEventIdExists())
            {
                deleteEvent();
            }
            else
            {
                Response.Write("<script>alert('Event Id Does not exist');</script>");
            }
        }

        void deleteEvent()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
               if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
               //command for the delete data form the table
                SqlCommand cmd = new SqlCommand("DELETE from event_details WHERE event_id='"+ TextBox1.Text.Trim() +"'", con);
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Event Delete Event successfully.');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                
            }
            clearForm();
            GridView.DataBind();
        }

        //This method clears the form fields after an operation is completed.
        void clearForm()
        {
           TextBox1.Text ="";
            TextBox2.Text = "";
             TextBox3.Text = "";
             TextBox4.Text = "";
             TextBox5.Text = "";
             TextBox6.Text = "";
        }

        
        }
    }
  

