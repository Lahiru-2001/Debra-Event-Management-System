using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Debra
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        // Retrieve the connection string from the configuration file
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Admin Login Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            // Check if the username or password fields are empty
            if (string.IsNullOrWhiteSpace(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox2.Text))
            {

                Response.Write("<script>alert('Please fill in both username and password fields.');</script>");
                return;
            }
            // try block used for the catch any potential exceptions that may happen.
            try
            {
                // Create a new SqlConnection using the connection string
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    // Open the connection if it is not already open
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    // Use queries with parameters to avoid SQL injection.
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Admin_Login WHERE (Admin_username = @username AND Admin_password = @password)", con);

                    // parameters assigned with the textboxs
                    cmd.Parameters.AddWithValue("@username", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", TextBox2.Text.Trim());

                    // Execute the command and read the data from the database
                    SqlDataReader dr = cmd.ExecuteReader();

                    // Check if any rows were returned using odject "dr"
                    if (dr.HasRows)
                    {
                        // Process each row
                        while (dr.Read())
                        {
                            // Display a success message and stores the username and role in the session state.
                            Response.Write("<script>alert('Login successful. Welcome " + dr["Admin_username"].ToString() + "');</script>");
                            Session["Admin_username"] = dr.GetValue(0).ToString();
                            Session["role"] = "admin";
                        }
                        //redirect to the home page
                        Response.Redirect("homepage.aspx");
                    }
                    else
                    {
                        // Display an error message if the login credentials are invalid
                        Response.Write("<script>alert('Invalid username or password.');</script>");
                    }
                }

            }


            catch (Exception ex)
            {
                // Display a  error message in case of an exception
                Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
            }

        }
    }
}