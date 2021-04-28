<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminMovieManagement.aspx.cs" Inherits="Cinema.Web.adminMovieManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script type="text/javascript">
        $(document).ready(function () {

            //$(document).ready(function () {
            //$('.table').DataTable();
            // });

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
                           <h4>Movie Management</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                            <!-- fas fa-film = clasa predefinita in fontawesome-->
                          <i class="fas fa-film"></i>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                  <div class="row">
                       <div class="col-md-6">
                        <label>Film ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Film ID"></asp:TextBox>
                              <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" />
                           </div>
                        </div>
                     </div>

                      <div class="col-md-6">
                        <label>Numar Rezervare</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Nr Rezervare"></asp:TextBox>
                              <asp:Button class="btn btn-primary" ID="Button3" runat="server" Text="Go" />
                           </div>
                        </div>
                     </div>

                      <div class="col-md-6">
                        <label>BiletID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="BiletID"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Sala</label>
                        
                           <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                              <asp:ListItem Text="Sala 1" Value="Sala 1" />
                              <asp:ListItem Text="Sala 2" Value="Sala 2" />
                           </asp:DropDownList>
                      
                     </div>
                      <div class="col-md-6">
                        <label>ScaunID</label>
                         <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                              <asp:ListItem Text="Scaun 1" Value="Scaun 1" />
                              <asp:ListItem Text="Scaun 2" Value="Scaun 2" />
                             <asp:ListItem Text="Scaun 3" Value="Scaun 3" />
                             <asp:ListItem Text="Scaun 4" Value="Scaun 4" />
                             <asp:ListItem Text="Scaun 5" Value="Scaun 5" />
                           </asp:DropDownList>
                     </div>

                    
                  </div>
                   <br />

              
                   <!--
                   <div class="row">
                     <div class="col-md-6">
                        <label>Titlu Film</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Titlu Film" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Descriere Film</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Descriere Film" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                  <div class="row">
                     <div class="col-md-6">
                        <label>Limba</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Start Date" TextMode="SingleLine"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Data</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Data" TextMode="DateTime"></asp:TextBox>
                        </div>
                     </div>
                  </div>

                   -->

                  <div class="row">
                     <div class="col-6">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" Text="Adauga" />
                     </div>
                     <div class="col-6">
                        <asp:Button ID="Button4" class="btn btn-lg btn-block btn-warning" runat="server" Text="Sterge" />
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
                           <h4>Lista Filme</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                     
                   <div class="row">
                     
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CinemaDBConnectionString3 %>" SelectCommand="SELECT [DescriereFilm], [TitluFilm], [Gen], [Limba] FROM [Film]" OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
                        
                      <div class="col">

                          &nbsp;<asp:GridView class="table table-striped table-bordered" ID="GridView8" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                              <Columns>
                                  <asp:BoundField DataField="DescriereFilm" HeaderText="DescriereFilm" SortExpression="DescriereFilm" />
                                  <asp:BoundField DataField="TitluFilm" HeaderText="TitluFilm" SortExpression="TitluFilm" />
                                  <asp:BoundField DataField="Gen" HeaderText="Gen" SortExpression="Gen" />
                                  <asp:BoundField DataField="Limba" HeaderText="Limba" SortExpression="Limba" />
                              </Columns>
                          </asp:GridView>
                     </div>
                      
                       <!--
                      <div class="col">
                          <label>Titlu Film</label>
                        <asp:GridView class="table table-striped table-bordered" ID="GridView7" runat="server"></asp:GridView>
                     </div>
                     <div class="col">
                     <label>Descriere</label>
                        <asp:GridView class="table table-striped table-bordered" ID="GridView4" runat="server"></asp:GridView>
                     </div>
                      <div class="col">
                          <label>Limba</label>
                        <asp:GridView class="table table-striped table-bordered" ID="GridView5" runat="server"></asp:GridView>
                     </div>
                      <div class="col">
                          <label>Data</label>
                        <asp:GridView class="table table-striped table-bordered" ID="GridView6" runat="server"></asp:GridView>
                     </div>
                       -->
                  </div>
               </div>
            </div>
         </div>
      </div>
   

</asp:Content>
