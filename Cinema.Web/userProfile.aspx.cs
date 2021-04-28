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
    public partial class userProfile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
              if (string.IsNullOrEmpty((string)Session["Username"])) //verificam daca exista(daca mai este valabil)
                {
                    Response.Write("<script>alert('Session expired. Login again.');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                    getMemberInfo();
              if(!Page.IsPostBack) //cand apasam pe un buton, frontendul este trimis in backend(aici verificam ca nu se intampla asta in momentul respectiv)
                {
                    getUserPersonalDetails();
                }
            }
            catch
            {
                Response.Write("<script>alert('Session expired. Login again.');</script>");
                Response.Redirect("userlogin.aspx");
            }
        }


        //UPDATE BUTTON
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((string)Session["Username"])) //verificam daca exista(daca mai este valabil)
            {
                Response.Write("<script>alert('Session expired. Login again.');</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
                updateUserPersonalDetails();
            if (!Page.IsPostBack) //cand apasam pe un buton, frontendul este trimis in backend(aici verificam ca nu se intampla asta in momentul respectiv)
            {
                getUserPersonalDetails();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void updateUserPersonalDetails()
        {
            string parola = "";
            if (TextBox7.Text.Trim() == "")
            {
                parola = TextBox2.Text.Trim();
            }
            else
            {
                parola = TextBox7.Text.Trim();
            }
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE  [User]  SET Nume = @Nume, Prenume = @Prenume, Parola = @Parola, Email = @Email, Telefon = @Telefon, StatusCont = @StatusCont WHERE Username = '" + Session["Username"].ToString() + "' ", con);

                cmd.Parameters.AddWithValue("@Nume", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@Prenume", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@Parola", parola);
                cmd.Parameters.AddWithValue("@Email", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@Telefon", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@StatusCont", "pending");


                int result = cmd.ExecuteNonQuery(); //fire the query
                con.Close();
                if (result > 0)
                {

                    Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                    getUserPersonalDetails();
                    getMemberInfo();
                }
                else
                {
                    Response.Write("<script>alert('Invaid entry');</script>");
                }
               
                GridView1.DataBind();
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
       


        void getMemberInfo()
        {
            try
            {
                //cream un obiect con , cu parametrul strcon

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //Trim = removes blankspaces
                SqlCommand cmd = new SqlCommand("SELECT U.Username, R.NumarRezervare, B.NumarScaun, F.TitluFilm, P.Platit, U.StatusCont FROM Rezervare R LEFT JOIN [User] U  ON U.UserID = R.UserID  LEFT JOIN Plata P ON P.RezervareID = R.RezervareID LEFT JOIN Bilet B ON B.RezervareID = R.RezervareID LEFT JOIN Film F ON B.FilmID = F.FilmID WHERE U.Username = '" + Session["Username"].ToString() + "' ", con); //verificam daca exista rezervarea
                SqlDataAdapter da = new SqlDataAdapter(cmd); //pasam cmd de la query
                DataTable dt = new DataTable();
                da.Fill(dt); // umplem tabela =temporara dt cu orice primeste din SELECT
                             //fetch and fills the datatable

                GridView1.DataSource = dt;
                GridView1.DataBind();


            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void getUserPersonalDetails()
        {
            try
            {
                //cream un obiect con , cu parametrul strcon

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //Trim = removes blankspaces
                SqlCommand cmd = new SqlCommand("SELECT * FROM [User] WHERE Username = '" + Session["Username"].ToString() + "' ", con); //verificam daca exista rezervarea
                SqlDataAdapter da = new SqlDataAdapter(cmd); //pasam cmd de la query
                DataTable dt = new DataTable();
                da.Fill(dt); // umplem tabela =temporara dt cu orice primeste din SELECT
                             //fetch and fills the datatable

                TextBox3.Text = dt.Rows[0]["Nume"].ToString();
                TextBox4.Text = dt.Rows[0]["Prenume"].ToString();
                TextBox5.Text = dt.Rows[0]["Email"].ToString();
                TextBox6.Text = dt.Rows[0]["Telefon"].ToString();
                TextBox1.Text = dt.Rows[0]["Username"].ToString();
                TextBox2.Text = dt.Rows[0]["Parola"].ToString();

                Label1.Text = dt.Rows[0]["StatusCont"].ToString().Trim();

                if (dt.Rows[0]["StatusCont"].ToString().Trim() == "active")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-success");
                }
                else if (dt.Rows[0]["StatusCont"].ToString().Trim() == "pending")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                else if (dt.Rows[0]["StatusCont"].ToString().Trim() == "deactive")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-info");
                }

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)// fire for every row created, count of the rows = count of the function called. Daca Plata nu e facuta, facem tot randul rosu
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    string text = e.Row.Cells[4].Text;

                    if (text.Equals("NU"))
                    {
                        e.Row.BackColor = System.Drawing.Color.Red;


                    }
                    if (text.Equals("NU"))
                    {
                        e.Row.BackColor = System.Drawing.Color.Green;
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }



    }
 

}
