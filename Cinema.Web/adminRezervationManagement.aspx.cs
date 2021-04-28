using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Cinema.Web
{

    public partial class adminRezervationManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           // fillSalaValues();
            GridView1.DataBind(); // se da refresh automat la tabel
        }

        //butonul de ADD
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkRezervationExists())
            {
                Response.Write("<script>alert('Rezervarea cu acest numar exista deja. Incercati alt numar.');</script>");
            }
            else
            if (checkUserExists())
            {
                if (checkMovieExists())
                {
                    addNewRezervation();
                }
                else
                {
                    Response.Write("<script>alert('Filmul nu este disponibil');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Userul nu exista.');</script>");

            }

        }

        //butonul de UPDATE 
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkRezervationExists()) //update doar in cazul in care rezervarea deja exista
            {

                updateRezervation();
            }
            else
            {
                Response.Write("<script>alert('Rezervarea nu exista.');</script>");

            }

        }

        //butonul de DELETE
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkRezervationExists()) //update doar in cazul in care rezervarea deja exista
            {

                deleteRezervation();
                
            }
            else
            {
                Response.Write("<script>alert('Rezervarea nu exista.');</script>");

            }
        }

        //buton de GO
        protected void Button1_Click(object sender, EventArgs e)
        {
            getRezervationByNumber();
        }


        //user defined function

        void deleteRezervation()
        {
            try
            {
                //cream un obiect con , cu parametrul strcon

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                // pentru update se poate updata doar numarul de bilete cumparat de un user

               ;
                SqlCommand cmd1 = new SqlCommand("DELETE B  FROM Bilet B INNER JOIN Rezervare R ON B.RezervareID = R.RezervareID WHERE R.NumarRezervare = '" + TextBox1.Text.Trim() + "' ", con);
                SqlCommand cmd2 = new SqlCommand("DELETE P FROM Plata P INNER JOIN Rezervare R ON P.RezervareID = R.RezervareID WHERE R.NumarRezervare =  '" + TextBox1.Text.Trim() + "' ", con);
                SqlCommand cmd = new SqlCommand("DELETE  FROM Rezervare WHERE NumarRezervare =  '" + TextBox1.Text.Trim() + "' ", con);
               

                cmd1.ExecuteNonQuery(); //fire the query
                cmd2.ExecuteNonQuery(); //fire the query
                cmd.ExecuteNonQuery(); //fire the query
                con.Close();
                Response.Write("<script>alert('Rezervarea a fost stearsa');</script>");
                clearForm();
                GridView1.DataBind(); // se da refresh automat la tabel
               // GridView2.DataBind(); // se da refresh automat la tabel


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }



        //user defined function
        //adaugam o noua rezervare

        void addNewRezervation()
        {

            try
            {
                //cream un obiect con , cu parametrul strcon

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string Scaun = " ";
                int count = 0;
                foreach (int i in ListBox1.GetSelectedIndices()) //doar indicii selectati sunt retinuri
                {
                    count = count + 1;
                    Scaun = Scaun + ListBox1.Items[i] + ",";
                }

                Scaun = Scaun.Remove(Scaun.Length - 1); //remove comma from end


                SqlCommand cmd = new SqlCommand("INSERT INTO Rezervare (UserID, Username, NumarRezervare,  NumarBilete) SELECT UserID, @Username,  @NumarRezervare,  @NumarBilete FROM [User]  WHERE Username =  @Username ", con);

                SqlCommand cmd1 = new SqlCommand("INSERT INTO Bilet(FilmID, RezervareID, NumarScaun) VALUES((SELECT FilmID FROM Film  WHERE TitluFilm = '" + TextBox4.Text.Trim() + "') , (SELECT RezervareID FROM Rezervare WHERE NumarRezervare =  '" + TextBox1.Text.Trim() + "'), @NumarScaun)", con);
              

                cmd.Parameters.AddWithValue("@Username", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@NumarRezervare", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@NumarBilete", count);
                cmd1.Parameters.AddWithValue("@NumarScaun", Scaun);

                cmd.ExecuteNonQuery(); //fire the query
                cmd1.ExecuteNonQuery(); //fire the query
             ;

                if (CheckBox1.Checked)
                {
                    SqlCommand cmd3 = new SqlCommand("INSERT INTO Plata(RezervareID, Platit) VALUES((SELECT RezervareID FROM Rezervare WHERE NumarRezervare =  '" + TextBox1.Text.Trim() + "'), 'DA')", con);
                    cmd3.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmd3 = new SqlCommand("INSERT INTO Plata(RezervareID, Platit) VALUES((SELECT RezervareID FROM Rezervare WHERE NumarRezervare =  '" + TextBox1.Text.Trim() + "'), 'NU')", con);
                    cmd3.ExecuteNonQuery();
                }


                con.Close();
                Response.Write("<script>alert('Rezervare adaugata. ');</script>");
                clearForm();
                GridView1.DataBind(); // se da refresh automat la tabel
              //  GridView2.DataBind(); // se da refresh automat la tabel



            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

      



        //user defined function for update

        void updateRezervation()
        {

            try
            {
                //cream un obiect con , cu parametrul strcon

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string Scaun = " ";
                int count = 0;
                foreach (int i in ListBox1.GetSelectedIndices()) //doar indicii selectati sunt retinuri
                {
                    count = count + 1;
                    Scaun = Scaun + ListBox1.Items[i] + ",";
                }

                Scaun = Scaun.Remove(Scaun.Length - 1); //remove comma from end

                SqlCommand cmd = new SqlCommand("UPDATE R SET R.NumarBilete = @NumarBilete FROM Rezervare R INNER JOIN [User] U ON U.UserID = R.UserID WHERE U.Username = @Username AND R.NumarRezervare =   '" + TextBox1.Text.Trim() + "' ", con);
               
                SqlCommand cmd2 = new SqlCommand("UPDATE  B  SET B.NumarScaun = @NumarScaun FROM Bilet B INNER JOIN Rezervare R ON R.RezervareID = B.RezervareID WHERE R.NumarRezervare =   '" + TextBox1.Text.Trim() + "' ", con);


                cmd.Parameters.AddWithValue("@Username", TextBox3.Text.Trim());
               // cmd3.Parameters.AddWithValue("@Platit", "DA");
                cmd.Parameters.AddWithValue("@NumarBilete", count);
                cmd2.Parameters.AddWithValue("@NumarScaun", Scaun);

                cmd.ExecuteNonQuery(); //fire the query
                cmd2.ExecuteNonQuery();

                if (CheckBox1.Checked)
                {
                    SqlCommand cmd3 = new SqlCommand("UPDATE P SET  Platit = 'DA' FROM  Plata  P INNER JOIN Rezervare R ON R.RezervareID = P.RezervareID WHERE R.NumarRezervare =   '" + TextBox1.Text.Trim() + "' ", con);
                    cmd3.ExecuteNonQuery();
                    
                }
                else
                {
                    SqlCommand cmd3 = new SqlCommand("UPDATE P SET  Platit = 'NU' FROM  Plata  P INNER JOIN Rezervare R ON R.RezervareID = P.RezervareID WHERE R.NumarRezervare =   '" + TextBox1.Text.Trim() + "' ", con);
                    cmd3.ExecuteNonQuery();
                }

                con.Close();
                Response.Write("<script>alert('Rezervare modificata');</script>");
                clearForm();
                GridView1.DataBind(); // se da refresh automat la tabel



            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        bool checkUserExists()
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM [User] WHERE Username ='" + TextBox3.Text.Trim() + "' ", con); //verificam daca mai exista acelasi username
                SqlDataAdapter da = new SqlDataAdapter(cmd); //pasam cmd de la query
                DataTable dt = new DataTable();
                da.Fill(dt); // umplem tabela =temporara dt cu orice primeste din SELECT
                             //fetch and fills the datatable
                if (dt.Rows.Count >= 1) // exista un username deja existent 
                {
                    return true;
                }
                else
                {
                    return false;
                }

                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }

        }

        bool checkMovieExists()
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM Film WHERE TitluFilm ='" + TextBox4.Text.Trim() + "' ", con); //verificam daca mai exista acelasi username
                SqlDataAdapter da = new SqlDataAdapter(cmd); //pasam cmd de la query
                DataTable dt = new DataTable();
                da.Fill(dt); // umplem tabela =temporara dt cu orice primeste din SELECT
                             //fetch and fills the datatable
                if (dt.Rows.Count >= 1)  
                {
                    return true;
                }
                else
                {
                    return false;
                }

                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }

        }

        bool checkRezervationExists()
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM Rezervare WHERE NumarRezervare ='" + TextBox1.Text.Trim() + "' ", con); //verificam daca exista rezervarea
                SqlDataAdapter da = new SqlDataAdapter(cmd); //pasam cmd de la query
                DataTable dt = new DataTable();
                da.Fill(dt); // umplem tabela =temporara dt cu orice primeste din SELECT
                             //fetch and fills the datatable
                if (dt.Rows.Count >= 1) // exista un username deja existent 
                {
                    return true;
                }
                else
                {
                    return false;
                }

                con.Close();
                Response.Write("<script>alert('Ati creat rezervarea cu succes.');</script>");
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void clearForm()
        {
            TextBox1.Text = "";
          
            TextBox3.Text = "";
            TextBox4.Text = "";
        }

        void getRezervationByNumber()
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM Rezervare R FULL JOIN Plata P ON P.RezervareID = R.RezervareID FULL JOIN Bilet B ON  B.RezervareID = R.RezervareID LEFT JOIN Film F ON F.FilmID = B.FilmID WHERE R.NumarRezervare ='" + TextBox1.Text.Trim() + "' ", con); //verificam daca exista rezervarea
                SqlDataAdapter da = new SqlDataAdapter(cmd); //pasam cmd de la query
                DataTable dt = new DataTable();
                da.Fill(dt); // umplem tabela =temporara dt cu orice primeste din SELECT
                             //fetch and fills the datatable
                if (dt.Rows.Count >= 1) // exista o rezervare deja
                {
                    TextBox3.Text = dt.Rows[0][2].ToString();
                    TextBox4.Text = dt.Rows[0]["TitluFilm"].ToString();

                    ListBox1.ClearSelection();
                    string[] Scaun = dt.Rows[0]["NumarScaun"].ToString().Trim().Split(',');
                    for (int i = 0; i < Scaun.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == Scaun[i])
                            {
                                ListBox1.Items[j].Selected = true;

                            }
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('Rezervare invalida');</script>");
                }


            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }




        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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