<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminRezervationManagement.aspx.cs" Inherits="Cinema.Web.adminRezervationManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      
    <script type="text/javascript">
        $(document).ready(function () {

            $(document).ready(function () {
            $('.table').DataTable();
             });

            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            //$('.table1').DataTable();
            //document - cand documentul e gata, ready - cand e gata, function - custom function
            // $ = select,ne selecteaza toate componentele din gridview din tot documentul, heading-ul = thead => numele coloanelor din DB
        });
    </script>

   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
      <div class="row">
         <div class="col-md-5">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Detalii Rezervare</h4> 
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                       
                        <img width="100px" src="images/key.jpg" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">


                     <div class="col">
                        <label>Nr rezervare</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Nr rezervare"></asp:TextBox>
                              <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                           </div>
                        </div>
                     </div>


                    

                   

                       <div class="col-md-4">
                        <label>Scaun</label>
                        <div class="form-group">
                           <asp:ListBox CssClass="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple" Rows="5">
                              <asp:ListItem Text="Scaun 1" Value="Scaun 1" />
                              <asp:ListItem Text="Scaun 2" Value="Scaun 2" />
                              <asp:ListItem Text="Scaun 3" Value="Scaun 3" />
                              <asp:ListItem Text="Scaun 4" Value="Scaun 4" />
                              <asp:ListItem Text="Scaun 5" Value="Scaun 5" />
                              <asp:ListItem Text="Scaun 6" Value="Scaun 6" />
                              <asp:ListItem Text="Scaun 7" Value="Scaun 7" />
                              <asp:ListItem Text="Scaun 8" Value="Scaun 8" />
                              <asp:ListItem Text="Scaun 9" Value="Scaun 9" />
                              <asp:ListItem Text="Scaun 10" Value="Scaun 10" />
                              <asp:ListItem Text="Scaun 11" Value="Scaun 11" />
                              <asp:ListItem Text="Scaun 12" Value="Scaun 12" />
                              <asp:ListItem Text="Scaun 13" Value="Scaun 13" />
                              <asp:ListItem Text="Scaun 14" Value="Scaun 14" />
                              <asp:ListItem Text="Scaun 15" Value="Scaun 15" />

                             
                           </asp:ListBox>
                        </div>
                     </div>
                      
                     <div class="col">
                        <label>Username</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Username"></asp:TextBox>
                        </div>
                     </div>

                       <div class="col">
                        <label>Film</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Film"></asp:TextBox>
                        </div>
                     </div>

                   
                       
                  </div>



                   <div class="row">
                       
                       <div class="col">
                        
                        <div class="form-group">
                      <asp:CheckBox ID="CheckBox1" placeholder="Platit" runat="server" Text="Platit" CausesValidation="True" Checked="True" />
                      </div>
                     </div>
                  </div>


                  <div class="row">
                     <div class="col-4">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button2_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button3_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button4_Click" />
                     </div>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br>
            <br>
         </div>
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">

                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Lista rezervari</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CinemaDBConnectionString %>" SelectCommand="SELECT * from [User] U INNER  JOIN [Rezervare] R  ON U.UserID = R.UserID LEFT JOIN [Bilet] B ON B.RezervareID = R.RezervareID INNER JOIN [Plata] P ON P.RezervareID = R.RezervareID INNER JOIN [Film] F ON F.FilmID = B.FilmID INNER JOIN [Sala] SA ON F.SalaID = SA.SalaID "></asp:SqlDataSource>
                      <div class="col">
                         <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server"  AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
                             <Columns>
                                 <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                                 <asp:BoundField DataField="NumarRezervare" HeaderText="NumarRezervare" SortExpression="NumarRezervare" />
                                 <asp:BoundField DataField="NumarBilete" HeaderText="NumarBilete" SortExpression="NumarBilete" />
                                 <asp:BoundField DataField="NumarScaun" HeaderText="NumarScaun" SortExpression="NumarScaun" />
                                 <asp:BoundField DataField="Platit" HeaderText="Platit" SortExpression="Platit" />
                                 <asp:BoundField DataField="TitluFilm" HeaderText="TitluFilm" SortExpression="TitluFilm" />
                                 <asp:BoundField DataField="NumeSala" HeaderText="NumeSala" SortExpression="NumeSala" />
                             </Columns>
                         </asp:GridView>
                     </div>

                       <div class="col">
                        </div>
                            
                  
                  </div>
               </div>
            </div>
         </div>
      </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
   </div>

</asp:Content>
