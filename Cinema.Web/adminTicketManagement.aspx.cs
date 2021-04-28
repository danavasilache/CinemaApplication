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
    public partial class adminTicketManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlDataAdapter da = new SqlDataAdapter("SELECT  F.TitluFilm as 'Film',  SUM(R.NumarBilete) as 'Total Bilete', COUNT(R.RezervareID) as 'Total Rezervari' FROM  Bilet B LEFT JOIN Rezervare R ON B.RezervareID = R.RezervareID LEFT JOIN Film F  ON B.FilmID = F.FilmID  GROUP BY F.TitluFilm ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                SqlDataAdapter da1 = new SqlDataAdapter("SELECT DISTINCT COUNT(R.RezervareID) as Rezervari, U.Username FROM[User] U INNER JOIN Rezervare R ON R.UserID = U.UserID GROUP BY U.Username HAVING COUNT(R.RezervareID) = (SELECT MAX(C.Suma) FROM(SELECT(COUNT(RR.RezervareID)) AS Suma, UU.Username FROM[User] UU INNER JOIN Rezervare RR ON RR.UserID = UU.UserID GROUP BY UU.Username) C); ", con);
                DataTable dt1 = new DataTable();
                
                da1.Fill(dt1);
                GridView2.DataSource = dt1;
                GridView2.DataBind();

                SqlDataAdapter da2 = new SqlDataAdapter("SELECT DISTINCT P.Platit,COUNT(R.RezervareID) as 'Numar rezervari', U.Username FROM [User] U INNER JOIN Rezervare R ON U.UserID = R.UserID INNER JOIN Plata P ON R.RezervareID = P.RezervareID WHERE P.Platit = 'NU' GROUP BY U.Username, Platit HAVING COUNT(R.RezervareID) IN (SELECT (COUNT(RR.RezervareID))  FROM [User] UU INNER JOIN Rezervare RR ON RR.UserID = UU.UserID GROUP BY UU.Username	HAVING COUNT(RR.RezervareID) > 1) ", con);
                DataTable dt2 = new DataTable();

                da2.Fill(dt2);
                GridView3.DataSource = dt2;
                GridView3.DataBind();

                SqlDataAdapter da3 = new SqlDataAdapter("SELECT DISTINCT F.TitluFilm as 'Titlu Film', S.NumeSala as 'Nume Sala' FROM Film F LEFT JOIN Bilet B ON B.FilmID = F.FilmID left join Sala S on S.SalaID = F.SalaID  WHERE  F.FilmID NOT IN (SELECT FilmID FROM Bilet)", con);
                DataTable dt3 = new DataTable();

                da3.Fill(dt3);
                GridView4.DataSource = dt3;
                GridView4.DataBind();

                SqlDataAdapter da4 = new SqlDataAdapter(" SELECT F.TitluFilm as 'Titlu Film' FROM Film F ORDER BY (SELECT Sum(R.NumarBilete)  FROM Rezervare R inner join Bilet B ON R.RezervareID  = B.RezervareID INNER JOIN [User] U ON U.UserID = R.UserID INNER JOIN Film FF ON B.FilmID = FF.FilmID where ff.filmid = f.filmid group by ff.filmid) desc ", con);
                DataTable dt4 = new DataTable();

                da4.Fill(dt4);
                GridView5.DataSource = dt4;
                GridView5.DataBind();

                SqlDataAdapter da5 = new SqlDataAdapter("SELECT R.NumarRezervare, R.NumarBilete, U.Username FROM Rezervare R INNER JOIN [User] U ON U.UserID = R.UserID WHERE U.Username ='" + TextBox1.Text.Trim() + "'", con);
                DataTable dt5 = new DataTable();

                da5.Fill(dt5);
                GridView6.DataSource = dt5;
                GridView6.DataBind();


                SqlDataAdapter da6 = new SqlDataAdapter("SELECT R.NumarRezervare, P.Platit FROM Rezervare R INNER JOIN Plata P ON P.RezervareID = r.RezervareID", con);
                DataTable dt6 = new DataTable();

                da6.Fill(dt6);
                GridView7.DataSource = dt6;
                GridView7.DataBind();

                SqlDataAdapter da7 = new SqlDataAdapter("SELECT * FROM [USER] U INNER JOIN Rezervare R ON U.UserID = R.UserID",   con);
                DataTable dt7 = new DataTable();

                da7.Fill(dt7);
                GridView8.DataSource = dt7;
                GridView8.DataBind();

                SqlDataAdapter da8 = new SqlDataAdapter("SELECT R.NumarRezervare, P.Platit FROM Plata P INNER JOIN Rezervare R ON P.RezervareID = R.RezervareID WHERE P.Platit = 'DA' ", con);
                DataTable dt8 = new DataTable();

                da8.Fill(dt8);
                GridView9.DataSource = dt8;
                GridView9.DataBind();

                con.Close();
                //      Response.Write("<script>alert('Total Bilete');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

    

    

    }
}
    


