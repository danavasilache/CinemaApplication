<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewmovies.aspx.cs" Inherits="Cinema.Web.viewmovies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="card-md-7">
            <div class="card-body">
                <div class="row">
                    <div class="col">
                        <center>
                           <h4>Lista filme</h4>
                        </center>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <hr>
                    </div>
                </div>
                <div class="row">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col">
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
                                    <asp:GridView class="table table-striped table-bordered table-hover table-light" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                        <Columns>

                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <div class=" container-fluid">
                                                        <div class="row">
                                                            <div class="col-lg-10">
                                                                <div class="row-border">
                                                                    <div class=" col-12">
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("TitluFilm") %>' Font-Bold="True" Font-Size="Large"></asp:Label>
                                                                    </div>


                                                                </div>

                                                                <div class="row">
                                                                    <div class=" col-12">
                                                                        Gen -
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Gen") %>' Font-Bold="True"></asp:Label>

                                                                        &nbsp;| Limba -
                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Limba") %>' Font-Bold="True"></asp:Label>


                                                                        &nbsp;|
                                                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("NumeSala") %>' Font-Bold="True"></asp:Label>


                                                                    </div>


                                                                </div>
                                                                <div class="row">
                                                                    <div class=" col-12">
                                                                        Descriere -
                                                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("DescriereFilm") %>' Font-Italic="True" Font-Size="Smaller"></asp:Label>

                                                                    </div>


                                                                </div>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <asp:Image CssClass=" img-fluid p-2" ID="Image1" runat="server" ImageUrl='<%# Eval("film_img") %>' />
                                                            </div>
                                                            &nbsp;
                                                        </div>
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
        <a href="homepage.aspx"><< Back to Home</a><br>
        <br>
        <br>
        <br>
        <br>
        <br>
        <br>
        <br>
        <br>
        <br>
    </div>


</asp:Content>
