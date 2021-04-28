<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="Cinema.Web.homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- prima imagine mare de pe home -->
    <section>

        <style>
            .cinema {
                width: 100%;
                height: 450px;
            }
        </style>
        <img src="images/cinema-virgin-radio.jpg" class="cinema" alt="Photo of cinema hall" />
    </section>

    <section>
        <!-- row - o portiune completa a containerului, cu coloane separate-->
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                  <h2>Cinema Star </h2>      
               </center>
                </div>
            </div>
            <!-- md - breakpoint , division ocupa 4 spatii din rand -->
            <div class="row">
                <div class="col-md-4">
                    <center>
                  <img src="images/ticket-linear-vector-icon-isolated-600w-1739024111.jpg" style="height: 157px; width: 158px" />
                  <h5>Rezeva bilet</h5>
               </center>
                </div>


                <div class="col-md-4">
                    <center>
                  <img src="images/welcome.jpg" style="height: 168px; width: 209px" />
                
               </center>
                </div>

                <div class="col-md-4">
                    <center>
                  <img src="images/aaf705e06726ce3881288ae4be3ac5fe.jpg" style="height: 158px; width: 150px" />
                  <h5>Lista filme</h5>
               </center>
                </div>

            </div>
            <br>
            <br>
            <br>
        </div>

        </div>
      </div>
    </section>

</asp:Content>
