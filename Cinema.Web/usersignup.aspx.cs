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
    public partial class usersignup1 : System.Web.UI.Page
    {
        //conexiunea la baza de date :
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //sign up button click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkUserExists())
            {
                Response.Write("<script>alert('Username indisponibil. Incercati alt username.');</script>");
            }
            else
            {
                signUpNewUser(); //daca un username nu exista deja; il adaugam.
            }

        }

        //user defined method

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
                SqlCommand cmd = new SqlCommand("SELECT * FROM [User] WHERE Username ='" + TextBox1.Text.Trim() + "' ", con); //verificam daca mai exista acelasi username
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
                Response.Write("<script>alert('V-ati inregistrat cu succes. Mergeti la User LogIn.');</script>");


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }

        }

        void signUpNewUser()
        {
            //Response.Write("<script>alert('Testing');</script>");

            try
            {
                //cream un obiect con , cu parametrul strcon

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO [User]( Username, Nume, Prenume,  Parola, Email, Telefon,  AdminID, StatusCont) values( @Username, @Nume, @Prenume , @Parola, @Email, @Telefon, @AdminID, @StatusCont)", con);


                cmd.Parameters.AddWithValue("@Username", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Nume", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@Prenume", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@Parola", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@Telefon", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@AdminID", DBNull.Value);
                cmd.Parameters.AddWithValue("@StatusCont", "pending");

                cmd.ExecuteNonQuery(); //fire the query
                con.Close();
                Response.Write("<script>alert('V-ati inregistrat cu succes. Mergeti la User LogIn.');</script>");


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


    }
}