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
    public partial class adminMemberManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //GO Button- FILL DETAILS
        protected void LinkButton4_Click(object sender, EventArgs e)
        {

            if (checkMemberExists()) //update doar in cazul in care rezervarea deja exista
            {


                 GetMemberByUsername();

            }
            else
            {
                Response.Write("<script>alert('Member does not exist.');</script>");

            }
          
        }

        //ACTIVE BUTTON
        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            if (checkMemberExists()) //update doar in cazul in care rezervarea deja exista
            {


                updateMemberStatusByUSername("active");

            }
            else
            {
                Response.Write("<script>alert('Member does not exist.');</script>");

            }
            
        }

        //PENDING BUTTON
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (checkMemberExists()) //update doar in cazul in care rezervarea deja exista
            {


                updateMemberStatusByUSername("pending");

            }
            else
            {
                Response.Write("<script>alert('Member does not exist.');</script>");

            }
           
        }

        //DEACTIVE BUTTON
        protected void LinkButton3_Click(object sender, EventArgs e)
        {

            if (checkMemberExists()) //update doar in cazul in care rezervarea deja exista
            {


                updateMemberStatusByUSername("deactive");

            }
            else
            {
                Response.Write("<script>alert('Member does not exist.');</script>");

            }
            
        }

        //DELETE USER
        protected void Button2_Click(object sender, EventArgs e)
        {

            if (checkMemberExists()) //update doar in cazul in care rezervarea deja exista
            {


                deleteMemberByUsername();

            }
            else
            {
                Response.Write("<script>alert('Member does not exist.');</script>");

            }
        }

        void GetMemberByUsername()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed) //verificam intai daca conexiunea este inchisa
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from[User] where Username = '" + TextBox1.Text.Trim() + "' ", con);
                SqlDataReader dr = cmd.ExecuteReader(); //datareader= citeste din bd
                if (dr.HasRows) // verificam daca exista sau nu in bd
                {
                    while (dr.Read()) //cat timp se citeste 
                    {
                       
                        TextBox2.Text = dr.GetValue(2).ToString();
                        TextBox5.Text = dr.GetValue(3).ToString();
                        TextBox8.Text = dr.GetValue(5).ToString();
                        TextBox3.Text = dr.GetValue(6).ToString();
                        TextBox4.Text = dr.GetValue(4).ToString();
                        TextBox7.Text = dr.GetValue(8).ToString();
                    }

                }
                else Response.Write("<script>alert('User invalid ');</script>");

            }




            catch (Exception ex)
            {

            }
            //Response.Write("<script>alert('Button Click ');</script>");
        }

        void updateMemberStatusByUSername(string status)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed) //verificam intai daca conexiunea este inchisa
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE [User] SET StatusCont = '" + status  +"' where Username = '" + TextBox1.Text.Trim() + "' ", con);

                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('Member status updated. ');</script>");

            }




            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void deleteMemberByUsername()
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

                
                SqlCommand cmd = new SqlCommand("DELETE P FROM Plata P LEFT JOIN Rezervare R ON P.RezervareID = R.RezervareID LEFT JOIN [User] U ON R.UserID = U.UserID WHERE U.Username = '" + TextBox1.Text.Trim() + "' ", con);
                SqlCommand cmd1 = new SqlCommand("DELETE B FROM Bilet B LEFT JOIN Rezervare R ON B.RezervareID = R.RezervareID LEFT JOIN [User] U ON R.UserID = U.UserID WHERE U.Username = '" + TextBox1.Text.Trim() + "' ", con);
                SqlCommand cmd2 = new SqlCommand("DELETE FROM [User] WHERE Username = '" + TextBox1.Text.Trim() + "' ", con);

                cmd.ExecuteNonQuery(); //fire the query
                cmd1.ExecuteNonQuery(); //fire the query
                cmd2.ExecuteNonQuery(); //fire the query
                con.Close();
                Response.Write("<script>alert('Userul a fost sters permanent.');</script>");
                clearform();
                GridView1.DataBind(); // se da refresh automat la tabel
                                      // GridView2.DataBind(); // se da refresh automat la tabel


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }
        bool checkMemberExists()
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
        void clearform()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox5.Text = "";
            TextBox8.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox7.Text = "";
        }
    }
 }
