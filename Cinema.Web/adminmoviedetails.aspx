<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmoviedetails.aspx.cs" Inherits="Cinema.Web.adminmoviedetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
     <script type="text/javascript">
         $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
         });

         function readURL(input) {
             if (input.files && input.files[0]) {
                 var reader = new FileReader();

                 reader.onload = function (e) {
                     $('#imgview').attr('src', e.target.result);
                 };

                 reader.readAsDataURL(input.files[0]);
             }
         }

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
                           <h4>Detalii film</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                        <img id ="imgview" src="movie_inventory/cienamdan.png" height="200" width="300" />
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
                         
                        <asp:FileUpload onchange="readURL(this);" class="form-control" ID="FileUpload1" runat="server" />
                     </div>
                  </div>
                  <div class="row">
                     
                     <div class="col-md-9">
                        <label>Titlu film</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Titlu Film"></asp:TextBox>
                          <div class="input-group">
                             
                              <asp:Button class="btn  btn-primary" ID="Button4" runat="server" Text =" Go" OnClick="Button4_Click" Width="61px"></asp:Button>
                           </div>
                          
                        </div>
                     </div>
                  </div>
                  <div class="row">
                      
                     <div class="col-md-4">
                        <label>Limba</label>
                        <div class="form-group">

                            
                            <asp:DropDownList ID="DropDownList2" runat="server">

                                 <asp:ListItem Text="English" Value="English" />
                              <asp:ListItem Text="Hindi" Value="Hindi" />
                              <asp:ListItem Text="Marathi" Value="Marathi" />
                              <asp:ListItem Text="French" Value="French" />
                              <asp:ListItem Text="German" Value="German" />
                              <asp:ListItem Text="Urdu" Value="Urdu" />

                            </asp:DropDownList>



                           
                        </div>
                      
                     </div>
                    
                     <div class="col-md-4">
                        <label>Genre</label>
                        <div class="form-group">
                           <asp:ListBox CssClass="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple" Rows="5">
                              <asp:ListItem Text="Action" Value="Action" />
                              <asp:ListItem Text="Adventure" Value="Adventure" />
                              <asp:ListItem Text="Comic Book" Value="Anime" />
                              <asp:ListItem Text="Self Help" Value="Self Help" />
                              <asp:ListItem Text="Motivation" Value="Motivation" />
                              <asp:ListItem Text="Healthy Living" Value="Healthy Living" />
                              <asp:ListItem Text="Wellness" Value="Wellness" />
                              <asp:ListItem Text="Crime" Value="Crime" />
                              <asp:ListItem Text="Drama" Value="Drama" />
                              <asp:ListItem Text="Fantasy" Value="Fantasy" />
                              <asp:ListItem Text="Horror" Value="Horror" />
                              <asp:ListItem Text="Poetry" Value="Poetry" />
                              <asp:ListItem Text="Personal Development" Value="Personal Development" />
                              <asp:ListItem Text="Romance" Value="Romance" />
                              <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                              <asp:ListItem Text="Suspense" Value="Suspense" />
                              <asp:ListItem Text="Thriller" Value="Thriller" />
                              <asp:ListItem Text="Art" Value="Art" />
                              <asp:ListItem Text="Autobiography" Value="Autobiography" />
                              <asp:ListItem Text="Encyclopedia" Value="Encyclopedia" />
                              <asp:ListItem Text="Health" Value="Health" />
                              <asp:ListItem Text="History" Value="History" />
                              <asp:ListItem Text="Math" Value="Math" />
                              <asp:ListItem Text="Textbook" Value="Textbook" />
                              <asp:ListItem Text="Science" Value="Science" />
                              <asp:ListItem Text="Travel" Value="Travel" />
                           </asp:ListBox>
                        </div>
                     </div>

                         
                     <div class="col-md-4">
                        <label>Sala</label>
                        <div class="form-group">

                            
                            <asp:DropDownList ID="DropDownList1" runat="server">

                              <asp:ListItem Text="Sala 1" Value="Sala 1" />
                              <asp:ListItem Text="Sala 2" Value="Sala 2" />
                              <asp:ListItem Text="Sala 3" Value="Sala 3" />
                             

                            </asp:DropDownList>
          
                        </div>
                      
                     </div>
                  
                    

                  </div>
                  <div class="row">
                     <div class="col-12">
                        <label>Descriere Film</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Descriere Film" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-4">
                        <asp:Button ID="Button1" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button1_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button3_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button2_Click" />
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
                           <h4>Film Inventory List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CinemaDBConnectionString5 %>" SelectCommand="SELECT TitluFilm, DescriereFilm, Gen, Limba, film_img, NumeSala  FROM [Film] F INNER JOIN [Sala] S ON F.SalaID = S.SalaID WHERE F.SalaID = S.SalaID"></asp:SqlDataSource>
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered table-hover table-warning" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" >
                            <Columns>
                               
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class =" container-fluid">
                                            <div class ="row">
                                                <div class ="col-lg-10">
                                                     <div class ="row-border">
                                                            <div class =" col-12">
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("TitluFilm") %>' Font-Bold="True" Font-Size="Large"></asp:Label>
                                                            </div>


                                                      </div>

                                                    <div class ="row">
                                                            <div class =" col-12">
                                                               
                                                                Gen - <asp:Label ID="Label2" runat="server" Text='<%# Eval("Gen") %>' Font-Bold="True"></asp:Label>
                                                               
                                                                &nbsp;| Limba - <asp:Label ID="Label3" runat="server" Text='<%# Eval("Limba") %>' Font-Bold="True"></asp:Label>
                                                               
                                                               
                                                                &nbsp;| <asp:Label ID="Label5" runat="server" Text='<%# Eval("NumeSala") %>' Font-Bold="True"></asp:Label>
                                                               
                                                               
                                                            </div>


                                                      </div>
                                                    <div class ="row">
                                                            <div class =" col-12">

                                                                Descriere - <asp:Label ID="Label4" runat="server" Text='<%# Eval("DescriereFilm") %>' Font-Italic="True" Font-Size="Smaller"></asp:Label>

                                                            </div>


                                                      </div>
                                                </div>
                                                <div class ="col-lg-2">
                                                    <asp:Image CssClass =" img-fluid p-2" ID="Image1" runat="server" ImageUrl='<%# Eval("film_img") %>' />
                                                </div>
                                                &nbsp;</div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                         </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>
</asp:Content>
