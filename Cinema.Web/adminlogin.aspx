<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="Cinema.Web.adminlogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class=" container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <!-- din bootstrap componenta card -->
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                         <img width="150px" src="images/admin.jpg" />
                               </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h5> Admin Login</h5>
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
                                <label>AdminName</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="AdminName"></asp:TextBox>

                                </div>
                                <label>Parola</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="ParolaID" TextMode="Password"></asp:TextBox>

                                </div>


                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="LogIn" OnClick="Button1_Click" />

                                </div>




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
