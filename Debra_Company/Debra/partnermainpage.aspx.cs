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
    public partial class partnermainpage : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {




        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            // Check if the username or password fields are empty
            if (string.IsNullOrWhiteSpace(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox2.Text))
            {
                Response.Write("<script>alert('Please fill in both username and password fields.');</script>");
                return;
            }
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

                    // Use parameterized queries to avoid SQL injection
                    SqlCommand cmd = new SqlCommand("SELECT * FROM partner_login WHERE (P_name = @usernameOrEmail OR P_email = @usernameOrEmail) AND P_password = @password", con);

                    // parameters assigned with the textboxs
                    cmd.Parameters.AddWithValue("@usernameOrEmail", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", TextBox2.Text.Trim());

                    // Execute the command and read the data from the database
                    SqlDataReader dr = cmd.ExecuteReader();

                    //  // Check if any rows were returned using odject "dr"
                    if (dr.HasRows)
                    {
                        // Process each row
                        while (dr.Read())
                        {
                            // Display a success message and stores the username and role in the session state.
                            Response.Write("<script>alert('Login successful. Welcome " + dr["P_name"].ToString() + "');</script>");
                            Session["P_name"] = dr.GetValue(0).ToString();
                            Session["role"] = "Partner";

                        }
                        Response.Redirect("homepage.aspx");
                    }
                    else
                    {
                        // Display an error message if the login credentials are invalid
                        Response.Write("<script>alert('Invalid username, email, or password.');</script>");
                    }
                }

            }


            catch (Exception ex)
            {
                // Display a generic error message in case of an exception
                Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
            }
        }
    }
}
    
