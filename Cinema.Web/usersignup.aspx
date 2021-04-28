<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="Cinema.Web.usersignup1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class=" container-fluid">
        <div class="row">
            <div class="col-md-8 mx-auto">
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
                                    <h5> User SignUp</h5>
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
                        <div class="col-md-6">
                            <label>Username</label>
                            <div class="form-group">
                                <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="Username"></asp:TextBox>

                            </div>

                        </div>
                        <div class="col-md-6">
                            <label>Parola</label>
                            <div class="form-group">
                                <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="ParolaID" TextMode="Password"></asp:TextBox>

                            </div>

                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <div class="form-group">
                                <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <a href=" homepage.aspx"><- Back to Home </a>

            </div>

            <br>
            <br>
            <br>
            <br>
        </div>


    </div>


</asp:Content>
