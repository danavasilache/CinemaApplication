using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cinema.Web
{
    public partial class adminmoviedetails : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        protected void Page_Load(object sender, EventArgs e)
        {
         
            GridView1.DataBind();
        }

        //ADD BUTTON
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(checkMovieExists())
            {
                Response.Write("<script>alert(' Filmul deja exista. Incercati alt film. ');</script>");

            }
            else
            {
                addNewMovie();

            }
        }

        //UPDATE BUTTON
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateMovie();
        }
        //DELETE BUTTON
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkMovieExists()) //update doar in cazul in care rezervarea deja exista
            {

                deleteMovie();

            }
            else
            {
                Response.Write("<script>alert('Rezervarea nu exista.');</script>");

            }
        }

       

        

        void updateMovie() //by title.
        {
            if (checkMovieExists()){
                try
                {
                    string Gen = " ";
                    foreach (int i in ListBox1.GetSelectedIndices()) //doar indicii selectati sunt retinuri
                    {
                        Gen = Gen + ListBox1.Items[i] + ",";
                    }
                    
                    Gen = Gen.Remove(Gen.Length - 1); //remove comma from end

                    string filepath = "~/movie_inventory/cienamdan.png";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("movie_inventory/" + filename));
                        filepath = "~/movie_inventory/" + filename;
                    }


                 
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                   

                    SqlCommand cmd = new SqlCommand("UPDATE Film SET DescriereFilm = @DescriereFilm, Gen = @Gen,Limba = @Limba, film_img = @film_img , SalaID = (SELECT S.SalaID FROM Sala S FULL join Film F on S.SalaID = F.SalaID WHERE S.NumeSala = '" + DropDownList1.SelectedItem.Value + "') FROM Film WHERE TitluFilm = '" + TextBox1.Text.Trim() + "'", con);


                   cmd.Parameters.AddWithValue("@NumeSala", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@DescriereFilm", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gen", Gen );
                    cmd.Parameters.AddWithValue("@Limba", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@film_img", filepath);


                    cmd.ExecuteNonQuery(); //fire the query
                    con.Close();
                    Response.Write("<script>alert('Detalii film modificate');</script>");
                    clearForm();
                    GridView1.DataBind(); // se da refresh automat la tabel



                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else 
                {
                    Response.Write("<script>alert('Film Invalid');</script>");
                }
           
        }

        void GetMovieByTitle()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM Film where TitluFilm = '"+TextBox1.Text.Trim()+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd); //cream un data table, il umplem, deci adapterul adapteaza outputul lui cmd.
                DataTable dt = new DataTable();
                da.Fill(dt); // avem aici toate datele din film

                if(dt.Rows.Count >= 1)
                {
                    TextBox6.Text = dt.Rows[0]["DescriereFilm"].ToString();
                    DropDownList2.SelectedValue = dt.Rows[0]["Limba"].ToString().Trim();
                    DropDownList1.SelectedValue = dt.Rows[0]["NumeSala"].ToString().Trim();

                    ListBox1.ClearSelection();
                    string[] Gen = dt.Rows[0]["Gen"].ToString().Trim().Split(',');
                    for (int i = 0; i < Gen.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == Gen[i])
                            {
                                ListBox1.Items[j].Selected = true;

                            }
                        }
                    }

                    global_filepath = dt.Rows[0]["film_img"].ToString();
                }
                else
                {

                    Response.Write("<script>alert('Titlul nu este valabil');</script>");
                }


            }
            catch (Exception ex)
            {

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
                SqlCommand cmd = new SqlCommand("SELECT * FROM Film WHERE TitluFilm ='" + TextBox1.Text.Trim() + "' ", con); //verificam daca mai exista acelasi username
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

        void deleteMovie()
        {
            try
            {
                //cream un obiect con , cu parametrul strcon

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                

                SqlCommand cmd2 = new SqlCommand("DELETE P FROM Plata P LEFT JOIN Rezervare R ON P.RezervareID = R.RezervareID LEFT JOIN Bilet B ON R.RezervareID = B.RezervareID LEFT JOIN Film F ON B.FilmID = F.FilmID WHERE F.TitluFilm = '" + TextBox1.Text.Trim() + "' ", con);
                SqlCommand cmd1 = new SqlCommand("DELETE R FROM Rezervare R LEFT JOIN Bilet B ON R.RezervareID = B.RezervareID LEFT JOIN Film F  ON B.FilmID = F.FilmID WHERE F.TitluFilm = '" + TextBox1.Text.Trim() + "'", con);
                SqlCommand cmd = new SqlCommand("Delete FROM Film WHERE TitluFilm =  '" + TextBox1.Text.Trim() + "' ", con);

                cmd2.ExecuteNonQuery(); //fire the query
                cmd1.ExecuteNonQuery(); //fire the query
                cmd.ExecuteNonQuery(); //fire the query
                con.Close();
                Response.Write("<script>alert('Filmul a fost sters.');</script>");
                clearForm();
                GridView1.DataBind(); // se da refresh automat la tabel
           

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

        void addNewMovie()
        {
            try
            {
                string Gen = " ";
                foreach (int i in ListBox1.GetSelectedIndices()) //doar indicii selectati sunt retinuri
                {
                    Gen = Gen + ListBox1.Items[i] + ",";
                }
                // genres = Adventure,Self Help,
                    Gen = Gen.Remove(Gen.Length - 1);

                string filepath = "~/movie_inventory/cienamdan.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("movie_inventory/" + filename));
                filepath = "~/movie_inventory/" + filename;
                



                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //Trim = removes blankspaces
                SqlCommand cmd = new SqlCommand("INSERT INTO Film (TitluFilm, DescriereFilm, Gen, Limba, film_img, SalaID) VALUES (@TitluFilm, @DescriereFilm, @Gen, @Limba, @film_img, (SELECT SalaID FROM Sala WHERE NumeSala = '"  +DropDownList1.SelectedItem.Value+ "' )) ", con);
               
                cmd.Parameters.AddWithValue("@TitluFilm", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@DescriereFilm", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@Gen", Gen);
                cmd.Parameters.AddWithValue("@Limba", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@NumeSala", DropDownList1.SelectedItem.Value);

                cmd.Parameters.AddWithValue("@film_img", filepath);


                cmd.ExecuteNonQuery(); //fire the query
               
                Response.Write("<script>alert('Filmul a fost adaugat.');</script>");
                con.Close();
                GridView1.DataBind(); // se da refresh automat la tabel
                clearForm();
                

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                

            }

        }
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox6.Text = "";
           
        }

        //GO BUTTON
        protected void Button4_Click(object sender, EventArgs e)
        {
            GetMovieByTitle();
        }

     /*   void fillSalaValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT NumeSala FROM Sala ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd); //cream un data table, il umplem, deci adapterul adapteaza outputul lui cmd. 

                DataTable dt = new DataTable();
                da.Fill(dt); // avem aici toate datele din film

                DropDownList1.DataSource = dt;
                DropDownList1.DataValueField = "NumeSala";
                DropDownList1.DataBind();


            }
            catch (Exception ex)
            {

            }
        }
        */


    }
}
