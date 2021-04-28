using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cinema.Web
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty((string)Session["rol"]))//verificam daca e cineva logat
                {
                    //cand nimeni nu e logat, butoanele de login si sign up sunt vizibile

                    LinkButton1.Visible = true; //user login link button
                    LinkButton2.Visible = true; //signup link button

                    LinkButton3.Visible = false; //logout -> nu se vede cand nimeni nu e logat
                    LinkButton7.Visible = false; //helo user 

                    LinkButton6.Visible = true; //admin login
                    LinkButton11.Visible = false; //reservation management
                    LinkButton12.Visible = false; //ticket management
                    LinkButton8.Visible = false; //movie list
                  //  LinkButton9.Visible = false; //movie managemenet
                    LinkButton13.Visible = false; //member management

                }
                else if(Session["rol"].Equals("user"))
                {

                    LinkButton1.Visible = false; //user login link button
                    LinkButton2.Visible = false; //signup link button

                    LinkButton3.Visible = true; //logout -> nu se vede cand nimeni nu e logat
                    LinkButton7.Visible = true; //helo user 
                    LinkButton7.Text = "Hello " + Session["Username"].ToString(); 

                    LinkButton6.Visible = true; //admin login
                    LinkButton11.Visible = false; //reservation management
                    LinkButton12.Visible = false; //ticket management
                    LinkButton8.Visible = false; //movie list
                  //  LinkButton9.Visible = false; //movie managemenet
                    LinkButton13.Visible = false; //member management
                }

                else if (Session["rol"].Equals("admin"))
                {

                    LinkButton1.Visible = false; //user login link button
                    LinkButton2.Visible = false; //signup link button

                    LinkButton3.Visible = true; //logout -> nu se vede cand nimeni nu e logat
                    LinkButton7.Visible = true; //helo user 
                    LinkButton7.Text = "Hello Admin";

                    LinkButton6.Visible = false; //admin login
                    LinkButton11.Visible = true; //reservation management
                    LinkButton12.Visible = true;  //ticket management
                    LinkButton8.Visible = true;  //movie list
                  //  LinkButton9.Visible = true;  //movie managemenet
                    LinkButton13.Visible = true;  //member management
                }
            }
            catch(Exception ex)
            {

            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminRezervationManagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminTicketManagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmoviedetails.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminMovieManagement.aspx");
        }

        protected void LinkButton13_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminMemberManagement.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewmovies.aspx");
        }
        
//logout button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["Username"] = ""; //Label logout, toate devin blank
            Session["Nume"] = "";
            Session["Prenume"] = "";
            Session["rol"] = "";
            Session["status"] = "";

            LinkButton1.Visible = true; //user login link button
            LinkButton2.Visible = true; //signup link button

            LinkButton3.Visible = false; //logout -> nu se vede cand nimeni nu e logat
            LinkButton7.Visible = false; //helo user 

            LinkButton6.Visible = true; //admin login
            LinkButton11.Visible = false; //reservation management
            LinkButton12.Visible = false; //ticket management
            LinkButton8.Visible = false; //movie list
            //LinkButton9.Visible = false; //movie managemenet
            LinkButton13.Visible = false; //member management

            Response.Redirect("homepage.aspx"); //cand dam pe logout- ne duce la homepage
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfile.aspx");
        }
    }
}