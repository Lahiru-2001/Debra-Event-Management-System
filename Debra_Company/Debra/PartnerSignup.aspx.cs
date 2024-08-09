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
    public partial class PartnerSignup : System.Web.UI.Page
    {
        // Retrieve the connection string from the configuration file
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Partner signup Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            // Check if the username or password fields are empty and call the registeruser methode
            if (IsValidInput())
            {
                RegisterUser();
            }
        }

        //check the empty filed
        private bool IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox2.Text) || string.IsNullOrWhiteSpace(TextBox3.Text))
            {
                Response.Write("<script>alert('All fields are required');</script>");
                return false;
            }
            return true;
        }

        //partner signup methode
        private void RegisterUser()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon)) //get the connection
                {
                    con.Open();
                    //check user existst and show the error message
                    if (UserExists(TextBox1.Text.Trim(), TextBox3.Text.Trim(), con)) 
                    {
                        Response.Write("<script>alert('Username or Email already exists. Please try a different one.');</script>");
                    }
                    else
                    {       //insert provied user data in to the table
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO  partner_login (P_name, P_email, P_password ) VALUES (@username, @email, @password)", con))
                        {
                            // parameters assigned with the textboxs
                            cmd.Parameters.AddWithValue("@username", TextBox1.Text.Trim());
                            cmd.Parameters.AddWithValue("@password", TextBox2.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", TextBox3.Text.Trim());

                            // Execute the command and returns rows and deisplay successfully or error massage
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                Response.Write("<script>alert('Registration successful. Go to the login page to log in.');</script>");
                            }
                            else
                            {
                                Response.Write("<script>alert('Registration failed. Please try again.');</script>");
                            }
                            con.Close();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");

            }

        }
        //check the username or email alrady existed in the database and give the error massage
        private bool UserExists(string username, string email, SqlConnection con)
        {
            //select the username or email and check thatusername or email alrady in the database or not based on provided user data
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM partner_login WHERE P_name = @username OR P_email = @Email", con))
            {
                // parameters assigned with the textboxs
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@Email", email);

                int userCount = (int)cmd.ExecuteScalar();
                return userCount > 0;
            }
        }

    }
    }
