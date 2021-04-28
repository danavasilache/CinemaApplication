<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminTicketManagement.aspx.cs" Inherits="Cinema.Web.adminTicketManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {

            $(document).ready(function () {
                $('.table').DataTable();
            });

            /*      $(document).ready(function () {
                      $('.new').DataTable();
                  });*/
            $(".table").prepend($("<thead></thead > ").append($(this).find("tr: first"))).dataTable();
            //$('.table1').DataTable();
            //document - cand documentul e gata, ready - cand e gata, function - custom function
            // $ = select,ne selecteaza toate componentele din gridview din tot documentul, heading-ul = thead => numele coloanelor din DB
        });
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">


            <br>
        </div>
        <div class="col-md">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                           <h2>Statistici</h2>
                        </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                           <h4>Evidenta biletelor si a rezervarilor la film</h4>
                        </center>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <center>
                       
                       <img width="200px" src="images/onlinebook.jpg" 
                        </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">


                            <asp:GridView class="table table-success  table-hover table-striped table-bordered  " ID="GridView1" runat="server" Font-Bold="True">
                            </asp:GridView>



                            <a href="homepage.aspx"><< Back to Home</a><br>
                            <br>
                        </div>



                    </div>
                </div>

            </div>
            <div class="col-md">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <div class="row">
                                    <div class="col">
                                        <center>
                           <h4>Evidenta Useri cu cele mai multe rezervari</h4>
                        </center>
                                    </div>
                                </div>

                                <asp:GridView class="table-primary table-hover table-striped table-bordered" ID="GridView2" runat="server" Width="1250px"></asp:GridView>


                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <div class="row">
                                    <div class="col">
                                        <center>
                           <h4>Evidenta Useri cu mai mult de o rezervare neplatita</h4>
                        </center>
                                    </div>
                                </div>

                                <asp:GridView class="table-danger table-hover table-striped table-bordered" ID="GridView3" runat="server" Width="1250px"></asp:GridView>


                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="col-md">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <div class="row">
                                    <div class="col">
                                        <center>
                           <h4>Filmele si sala pentru care nu s-a facut nicio rezervare</h4>
                        </center>
                                    </div>
                                </div>

                                <asp:GridView class="table-warning table-hover table-striped table-bordered" ID="GridView4" runat="server" Width="1250px"></asp:GridView>


                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="col-md">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <div class="row">
                                    <div class="col">
                                        <center>
                           <h4>Lista filmelor ordonate descrescator dupa numarul total al biletelor rezervate</h4>
                        </center>
                                    </div>
                                </div>

                                <asp:GridView class="table-info table-hover table-striped table-bordered" ID="GridView5" runat="server" Width="1250px"></asp:GridView>


                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            
            <div class="col-md">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <div class="row">
                                    <div class="col">
                                        <center>
                           <h4>Numărul biletelor de pe o rezervare în funcție de User</h4>
                        </center>
                                    </div>
                                </div>

                                <asp:GridView class="table-info table-hover table-striped table-bordered" ID="GridView6" runat="server" Width="1250px"></asp:GridView>


                            </div>
                        </div>
                    </div>
                </div>
            </div>

            
            <div class="col-md">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <div class="row">
                                    <div class="col">
                                        <center>
                           <h4>Status plata pentru fiecare rezervare</h4>
                        </center>
                                    </div>
                                </div>

                                <asp:GridView class="table-info table-hover table-striped table-bordered" ID="GridView7" runat="server" Width="1250px"></asp:GridView>


                            </div>
                        </div>
                    </div>
                </div>
            </div>


             <div class="col-md">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <div class="row">
                                    <div class="col">
                                        <center>
                           <h4>Detalii useri si rezervari</h4>
                        </center>
                                    </div>
                                </div>

                                <asp:GridView class="table-info table-hover table-striped table-bordered" ID="GridView8" runat="server" Width="1250px"></asp:GridView>


                            </div>
                        </div>
                    </div>
                </div>
            </div>

               <div class="col-md">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <div class="row">
                                    <div class="col">
                                        <center>
                           <h4>Rezervarile platite</h4>
                        </center>
                                    </div>
                                </div>

                                <asp:GridView class="table-info table-hover table-striped table-bordered" ID="GridView9" runat="server" Width="1250px"></asp:GridView>


                            </div>
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
