using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Debra
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //checking the current user
                string role = Session["role"] as string;

                if (string.IsNullOrEmpty(role))
                {
                    // Default case for users with no role 
                    LinkButton1.Visible = true; // user login
                    LinkButton2.Visible = true; // user register
                    LinkButton8.Visible = true; // partner

                    LinkButton3.Visible = false; // user logout
                    LinkButton7.Visible = false; // hello user
                    LinkButton4.Visible = false; // Add event
                    LinkButton5.Visible = false; // sells details
                    LinkButton6.Visible = false; // Buy tickets
                    LinkButton10.Visible = false; // partner register
                   
                }
                //user visibility button
                else if (role.Equals("user"))
                {
                    LinkButton1.Visible = false; // user login
                    LinkButton2.Visible = false; // user register
                    LinkButton4.Visible = false; // Add event
                    LinkButton5.Visible = false; // sells details
                    LinkButton8.Visible = false; // partner
                    LinkButton10.Visible = false; // partner register
                   

                    LinkButton3.Visible = true; // user logout
                    LinkButton6.Visible = true; // Buy tickets
                    LinkButton7.Visible = true; // hello user
                    LinkButton7.Text = "Hello:-" + Session["username"].ToString();
                }
                //admin visibility button 
                else if (role.Equals("admin"))
                {
                    LinkButton1.Visible = false; // user login
                    LinkButton2.Visible = false; // user register
                    LinkButton6.Visible = false; // Buy tickets
                    LinkButton8.Visible = false; // partner
                    LinkButton10.Visible = false; // partner register
                   

                    LinkButton4.Visible = true; // Add event
                    LinkButton5.Visible = true; // sells details
                    LinkButton3.Visible = true; // user logout
                    LinkButton7.Visible = true; // hello user
                    LinkButton7.Text = "Hello Admin";
                }
                //partner visibility button
                else if (role.Equals("Partner"))
                {
                    LinkButton1.Visible = false;//user login
                    LinkButton2.Visible = false;//user register
                    LinkButton6.Visible = false;//Buy teckets
                    LinkButton8.Visible = false;  //partner
                    LinkButton10.Visible = true;//partner register
                   

                    LinkButton4.Visible = false;// Add event
                    LinkButton5.Visible = false;// sells details
                    LinkButton3.Visible = true;//user logout
                    LinkButton7.Visible = true;// hello user 
                    LinkButton7.Text = "Hello Partner";
                }

            }
            catch (Exception ex)
            {
                // Handle the exception (logging, showing a message, etc.)
            }
        }


    

    //userlogin
    protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

       //register
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserSignup.aspx");
        }

        //logout
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["Admin_username"] = "";
            Session["role"] = "";
            Response.Redirect("homepage.aspx");
            LinkButton1.Visible = true;//user login
            LinkButton2.Visible = true;//user register

            LinkButton3.Visible = false;//user logout
            LinkButton6.Visible = false;//Buy teckets
            LinkButton7.Visible = false;// hello user 
            LinkButton4.Visible = false;// Add event
            LinkButton5.Visible = false;// sells details
            LinkButton8.Visible = true;  //partner
            LinkButton10.Visible = false;//partner register
           

        }

        //add event
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("EventManagement.aspx");
        }

        //sells report
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminSellsDetails.aspx");
        }

        //Buy teckets
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }
        //partner
        protected void LinkButton8_Click(object sender, EventArgs e)
        {
           

            // Redirect to the partner main page
            Response.Redirect("partnermainpage.aspx");
        }

        //partner register
        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("Partnerevent.aspx");
        }

    }
}