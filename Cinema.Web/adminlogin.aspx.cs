using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Cinema.Web
{
    public partial class adminlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed) //verificam intai daca conexiunea este inchisa
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from[User] where AdminName = '" + TextBox1.Text.Trim() + "' AND Parola ='" + TextBox2.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader(); //datareader= citeste din bd
                if (dr.HasRows) // verificam daca exista sau nu in bd
                {
                    while (dr.Read()) //cat timp se citeste 
                    {
                        // Response.Write("<script>alert('" + dr.GetValue(8).ToString() + " ');</script>"); //verificam daca exista adminName; iar daca da, afisam un popup cu username-ul sau in momentul logarii

                        Session["Username"] = dr.GetValue(1).ToString(); //username-ul se va retine in session variable-ul numit Username
                  
                        Session["rol"] = "admin"; 
                        
                    }

                    Response.Redirect("homepage.aspx");
                }
                else Response.Write("<script>alert('User invalid ');</script>");

            }




            catch (Exception ex)
            {

            }
            //Response.Write("<script>alert('Button Click ');</script>");
        }
    }
}