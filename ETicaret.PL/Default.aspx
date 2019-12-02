<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ETicaret.PL.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <asp:Panel ID="SuccesAlertDiv" runat="server" CssClass="alert alert-success alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center" role="alert" Visible="False">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <asp:Label ID="lblSuccesAlert" runat="server" Text=""></asp:Label>
        </asp:Panel>
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 pr-3">
                <div class="row pr-3 pl-3">
                    <div id="FilterNavMaster" class="container-fluid">
                        <nav class="navbar navbar-expand-lg navbar-dark">
                            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerSidebar" aria-controls="navbarTogglerSidebar" aria-expanded="false" aria-label="Toggle navigation">
                                Filtreler
                            </button>

                            <div class="collapse navbar-collapse" id="navbarTogglerSidebar">
                                <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
                                    <li class="nav-item pr-2 pl-2 pt-2">
                                        <div class="accordion" id="accordionSidebar"></div>
                                        <button class="nav-link collapsed btn btn-outline-success col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12" type="button" data-toggle="collapse" data-target="#collapseFilterBrands" aria-expanded="false" aria-controls="collapseFilterBrands">
                                            Markaya Göre
                                        </button>
                                        <div id="collapseFilterBrands" class="collapse" data-parent="#accordionSidebar">
                                            <asp:Panel ID="pnlFilterBrands" runat="server"></asp:Panel>
                                        </div>
                                    </li>
                                    <li class="nav-item pr-2 pl-2 pt-2">
                                        <button class="nav-link collapsed btn btn-outline-success col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12" type="button" data-toggle="collapse" data-target="#collapseFilterCategory" aria-expanded="false" aria-controls="collapseFilterCategory">
                                            Kategoriye Göre
                                        </button>
                                        <div id="collapseFilterCategory" class="collapse" data-parent="#accordionSidebar">
                                            <asp:Panel ID="pnlFilterCategory" runat="server"></asp:Panel>
                                        </div>
                                    </li>
                                    <li class="nav-item pr-2 pl-2 pt-2">
                                        <asp:Button ID="btnFilter" runat="server" CssClass="btn btn-success col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12" Text="Filtrele" OnClick="btnFilter_Click" />
                                    </li>
                                </ul>
                            </div>
                        </nav>
                        <div class="row">
                            <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-left">
                                <span class="text-beyaz pl-4">Filtrelerinizi seçin ve Filtrele butonuna tıklayın.</span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row d-none d-sm-none d-md-none d-lg-block d-xl-block pt-3 pr-4 pl-4">
                    <asp:Panel ID="pnlContent" runat="server" CssClass="container-fluid">
                        <div class="row">
                            <asp:ListView ID="lvProduct" runat="server">
                                <ItemTemplate>
                                    <div class="col-lg-3 col-xl-3 pt-3">
                                        <a class="btn btn-light" href='ProductDetails.aspx?ProductId=<%#Eval("Id") %>'>
                                            <div class="container card border-success" style="height: 300px; width: 200px;">
                                                <div class="row">
                                                    <div class="container-fluid text-center pt-2" style="min-height: 155px;">
                                                        <img src='<%#Eval("ProductCoverImages") %>' alt='<%#Eval("ProductName") %>' height="150" width="130" />
                                                    </div>
                                                </div>
                                                <div class="row" style="min-height: 100px;">
                                                    <div class="col-lg-12 col-xl-12 text-success text-center pt-2">
                                                        <strong class="footertextcontent"><%# Eval("ProductName") %></strong>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-4 col-xl-4">
                                                        <div class="row">
                                                            <div class="col-lg-4 col-xl-4 pr-2">
                                                                <i class="fa fa-thumbs-o-up"></i>
                                                            </div>
                                                            <div class="col-lg-3 col-xl-3 pl-2">
                                                                <span class="badge badge-pill badge-light"><%# Eval("LikeCount") %></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4 col-xl-4">
                                                        <div class="row">
                                                            <div class="col-lg-4 col-xl-4 pr-2">
                                                                <i class="fa fa-thumbs-o-down"></i>
                                                            </div>
                                                            <div class="col-lg-3 col-xl-3 pl-2">
                                                                <span class="badge badge-pill badge-light"><%# Eval("DislikeCount") %></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-4 col-xl-4">
                                                        <div class="row">
                                                            <div class="col-lg-4 col-xl-4 pr-2">
                                                                <i class="fa fa-commenting-o"></i>
                                                            </div>
                                                            <div class="col-lg-3 col-xl-3 pl-2">
                                                                <span class="badge badge-pill badge-light"><%# Eval("ProductCommentsCount") %></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </a>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlEmtyList" runat="server" CssClass="container-fluid" Visible="false">
                        <div class="container pt-5 pb-5 text-center" style="min-height: 350px;">
                            <span class="h4">Aradığınız kriterlere uygun ürün bulunamadı!</span>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
        <div class="row d-block d-sm-block d-md-block d-lg-none d-xl-none pt-3 pr-4 pl-4">
            <asp:Panel ID="pnlSmall" runat="server" CssClass="container-fluid">
                <div class="row">
                    <asp:ListView ID="lvProductSmall" runat="server">
                        <ItemTemplate>
                            <div class="col-6 col-sm-4 col-md-3 pt-3">
                                <a class="btn btn-light" href='ProductDetails.aspx?ProductId=<%#Eval("Id") %>'>
                                    <div class="container card border-success" style="height: 250px; width: 160px;">
                                        <div class="row">
                                            <div class="container-fluid text-center pt-2" style="min-height: 115px;">
                                                <img src='<%#Eval("ProductCoverImages") %>' alt='<%#Eval("ProductName") %>' height="110" width="100" />
                                            </div>
                                        </div>
                                        <div class="row" style="min-height: 100px;">
                                            <div class="col-12 col-sm-12 col-md-12 text-success text-center">
                                                <strong class="footertextcontent"><%# Eval("ProductName") %></strong>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-4 col-sm-4 col-md-4">
                                                <div class="row">
                                                    <div class="col-4 col-sm-4 col-md-4 pr-2">
                                                        <i class="fa fa-thumbs-o-up"></i>
                                                    </div>
                                                    <div class="col-3 col-sm-3 col-md-3 pl-2">
                                                        <span class="badge badge-pill badge-light"><%# Eval("LikeCount") %></span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-4 col-sm-4 col-md-4">
                                                <div class="row">
                                                    <div class="col-4 col-sm-4 col-md-4 pr-2">
                                                        <i class="fa fa-thumbs-o-down"></i>
                                                    </div>
                                                    <div class="col-3 col-sm-3 col-md-3 pl-2">
                                                        <span class="badge badge-pill badge-light"><%# Eval("DislikeCount") %></span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-4 col-sm-4 col-md-4">
                                                <div class="row">
                                                    <div class="col-4 col-sm-4 col-md-4 pr-2">
                                                        <i class="fa fa-commenting-o"></i>
                                                    </div>
                                                    <div class="col-3 col-sm-3 col-md-3 pl-2">
                                                        <span class="badge badge-pill badge-light"><%# Eval("ProductCommentsCount") %></span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlEmtyListSmall" runat="server" CssClass="container-fluid" Visible="false">
                <div class="container pt-5 pb-5 text-center" style="min-height: 350px;">
                    <span class="h4">Aradığınız kriterlere uygun ürün bulunamadı!</span>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
