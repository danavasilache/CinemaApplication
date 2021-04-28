<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userProfile.aspx.cs" Inherits="Cinema.Web.userProfile" %>

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

    <div class=" container-fluid">
        <div class="row">
            <div class="col-md-5">
                <!-- din bootstrap componenta card -->
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                          <img width="100px" src="images/3f9470b34a8e3f526dbdb022f9f19cf7.jpg" />
                               </center>
                            </div>
                        </div>

                        <div class="row">
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                    <h5> Your profile</h5>
                                    <span> Account status - </span>
                                        <asp:Label class="badge rounded-pill bg-info text-dark" Label ID="Label1" runat="server" Text="Your status"></asp:Label>
                                    
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
                            <label>Nume</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Nume"></asp:TextBox>

                            </div>

                        </div>
                        <div class="col-md-6">
                            <label>Prenume</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Prenume"></asp:TextBox>

                            </div>

                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-6">
                            <label>Email</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>

                            </div>

                        </div>
                        <div class="col-md-6">
                            <label>Telefon</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Telefon" TextMode="Phone"></asp:TextBox>

                            </div>

                        </div>


                    </div>

                    <!-- form group =clasa predefinita in bootstrap(creeaza cele doua text-boxuri) -->
                    <div class="row">
                        <div class="col-md-4">
                            <label>Username</label>
                            <div class="form-group">
                                <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="Username" ReadOnly="True"></asp:TextBox>

                            </div>

                        </div>
                        <div class="col-md-4">
                            <label>Parola Veche</label>
                            <div class="form-group">
                                <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="Parola Veche" ReadOnly="True"></asp:TextBox>

                            </div>

                        </div>
                        <div class="col-md-4">
                            <label>Parola Noua</label>
                            <div class="form-group">
                                <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="Parola Noua" TextMode="Password"></asp:TextBox>

                            </div>

                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                        <div class="form-group">
                           <asp:Button class="btn btn-primary btn-lg" ID="Button1" runat="server" Text="Update" OnClick="Button1_Click"   />
                        </div>
                         </center>
                        </div>
                    </div>
                </div>
                <a href=" homepage.aspx"><- Back to Home </a>

            </div>

            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                          <img width="100px" src="images/userprofile.jpg" />
                               </center>
                            </div>
                        </div>

                        <div class="row">
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                    <h5> Rezervarile tale</h5>
                                    
                                    
                               </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <asp:GridView class="table table-striped table-bordered table-hover" ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound"></asp:GridView>
                        </div>
                    </div>

                </div>



            </div>
            <br>
            <br>
            <br>
            <br>
        </div>



    </div>
    <br>
    <br>
    <br>
    <br>
    </div>

            

</asp:Content>
