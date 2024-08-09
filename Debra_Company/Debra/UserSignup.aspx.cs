using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;

namespace Debra
{
    public partial class UserSignup : System.Web.UI.Page
    {
        // Database connection string
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // User registration click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsValidInput())
            {
                RegisterUser();
            }
        }

        private bool IsValidInput()
        {
            if (string.IsNullOrWhiteSpace(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox2.Text) || string.IsNullOrWhiteSpace(TextBox3.Text))
            {
                Response.Write("<script>alert('All fields are required');</script>");
                return false;
            }
            return true;
        }

        private void RegisterUser()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon)) //connection
                {
                    con.Open();

                    if (UserExists(TextBox1.Text.Trim(), TextBox3.Text.Trim(), con)) //check user existst
                    {
                        Response.Write("<script>alert('Username or Email already exists. Please try a different one.');</script>");
                    }
                    else
                    {       //insert user data in to the table
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO User_L (username, email, password) VALUES (@username, @email, @password)", con))
                        {
                            cmd.Parameters.AddWithValue("@username", TextBox1.Text.Trim());
                            cmd.Parameters.AddWithValue("@password", TextBox2.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", TextBox3.Text.Trim());

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
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM User_L WHERE username = @username OR email = @Email", con))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@Email", email);

                int userCount = (int)cmd.ExecuteScalar();
                return userCount > 0;
            }
        }
      
    }
}
