<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="Cinema.Web.userlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- mx auto- breaks division into center -->
    <div class=" container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <!-- din bootstrap componenta card -->
                <div class="card">
                    <div class="card-body">


                        <div class="row">
                            <div class="col">
                                <center>
                                    <div class="row">
                                        </div>

                                    <h5> User Login</h5>
                               </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                          <img width="150px" src="images/3f9470b34a8e3f526dbdb022f9f19cf7.jpg" />
                               </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <!-- form group =clasa predefinita in bootstrap(creeaza cele doua text-boxuri) -->
                        <div class="row">
                            <div class="col">
                                <label>Username</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Username"></asp:TextBox>

                                </div>
                                <label>Parola</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="ParolaID" TextMode="Password"></asp:TextBox>

                                </div>

                                <center>
                                 <div class="form-group">
                                     <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="LogIn" OnClick="Button1_Click" />

                                  </div>

                                <div class="form-group">
                                    <!-- redirectionam catre signup-->
                                     <a href="usersignup.aspx"><input class="btn btn-warning btn-block btn-lg" id="Button2" type="button" value="Sign Up" /></a

                                  </div>
                                    </center>




                            </div>
                        </div>


                    </div>

                    <!-- lasam Utilizatorului posibilitatea de a se intoarce la homepage -->

                    <a href=" homepage.aspx"><- Back to Home </a>
                </div>


                <br>
                <br>
                <br>
                <br>
            </div>



        </div>

    </div>

</asp:Content>
