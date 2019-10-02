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
            <div class="d-block d-sm-block d-md-block d-lg-none d-xl-none col-6 col-sm-6 col-md-4 col-lg-3 col-xl-2">
                <div class="row pl-4 pr-3">
                    <div id="AccordionNavMaster" class="container-fluid">
                        <nav class="navbar navbar-expand-lg navbar-dark">
                            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerMaster" aria-controls="navbarTogglerMaster" aria-expanded="false" aria-label="Toggle navigation">
                                Ürünler
                            </button>
                            <div class="collapse navbar-collapse" id="navbarTogglerMaster">
                                <div class="accordion" id="accordionNavMaster">
                                    <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
                                        <li class="nav-item pr-2 pt-2">

                                            <button class="nav-link collapsed btn btn-outline-success col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12" type="button" data-toggle="collapse" data-target="#collapseBrands" aria-expanded="false" aria-controls="collapseBrands">
                                                Markalar
                                            </button>
                                            <div id="collapseBrands" class="collapse" data-parent="#accordionNavMaster">
                                                <div>
                                                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf 
                                                </div>
                                            </div>
                                        </li>
                                        <li class="nav-item pr-2 pt-2">
                                            <button class="nav-link collapsed btn btn-outline-success col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12" type="button" data-toggle="collapse" data-target="#collapseCategory" aria-expanded="false" aria-controls="collapseCategory">
                                                Kategoriler
                                            </button>
                                            <div id="collapseCategory" class="collapse" data-parent="#accordionNavMaster">
                                                <div>
                                                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf 
                                                </div>
                                            </div>
                                        </li>
                                        <li class="nav-item pr pt-2">
                                            <button class="nav-link collapsed btn btn-outline-success col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12" type="button" data-toggle="collapse" data-target="#collapseSubCategory" aria-expanded="false" aria-controls="collapseSubCategory">
                                                Alt Kategoriler
                                            </button>
                                            <div id="collapseSubCategory" class="collapse" data-parent="#accordionNavMaster">
                                                <div>
                                                    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf 
                                                </div>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </nav>

                    </div>
                </div>

            </div>

            <div class="d-none d-sm-none d-md-none d-lg-block d-xl-block col-5 col-sm-4 col-md-4 col-lg-3 col-xl-2">
                <ul id="NavbarUl" class="navbar-nav pl-3 pr-3 pt-2">
                    <li class="nav-item pt-1 pb-1 row">
                        <div class="btn-group dropright col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
                            <button type="button" class="btn btn-light dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                Markalar
                            </button>
                            <div class="dropdown-menu" x-placement="right-start" style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(107px, 0px, 0px);">
                                <a class="dropdown-item" href="#">Action</a>
                                <a class="dropdown-item" href="#">Another action</a>
                                <a class="dropdown-item" href="#">Something else here</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item" href="#">Separated link</a>
                            </div>
                        </div>
                    </li>
                    <li class="nav-item pb-1 row">
                        <div class="btn-group dropright col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
                            <button type="button" class="btn btn-light dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                Kategoriler
                            </button>
                            <div class="dropdown-menu" x-placement="right-start" style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(107px, 0px, 0px);">
                                <a class="dropdown-item" href="#">Action</a>
                                <a class="dropdown-item" href="#">Another action</a>
                                <a class="dropdown-item" href="#">Something else here</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item" href="#">Separated link</a>
                            </div>
                        </div>
                    </li>
                    <li class="nav-item pb-1 row">
                        <div class="btn-group dropright col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
                            <button type="button" class="btn btn-light dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                Alt Kategoriler
                            </button>
                            <div class="dropdown-menu" x-placement="right-start" style="position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(107px, 0px, 0px);">
                                <a class="dropdown-item" href="#">Action</a>
                                <a class="dropdown-item" href="#">Another action</a>
                                <a class="dropdown-item" href="#">Something else here</a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item" href="#">Separated link</a>
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
            <div class="col-6 col-sm-6 col-md-8 col-lg-9 col-xl-10 pr-3">
                <div class="row pr-4">
                    <div id="FilterNavMaster" class="container-fluid">
                        <nav class="navbar navbar-expand-lg navbar-dark">
                            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerSidebar" aria-controls="navbarTogglerSidebar" aria-expanded="false" aria-label="Toggle navigation">
                                Filtrele
                            </button>

                            <div class="collapse navbar-collapse" id="navbarTogglerSidebar">
                                <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
                                    <li class="nav-item pr-2 pl-2 pt-2">
                                        <div class="accordion" id="accordionSidebar"></div>
                                        <button class="nav-link collapsed btn btn-outline-success col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12" type="button" data-toggle="collapse" data-target="#collapseFilterBrands" aria-expanded="false" aria-controls="collapseFilterBrands">
                                            Markaya Göre
                                        </button>
                                        <div id="collapseFilterBrands" class="collapse" data-parent="#accordionSidebar">
                                            <div>
                                                Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                            </div>
                                        </div>
                                    </li>
                                    <li class="nav-item pr-2 pl-2 pt-2">
                                        <button class="nav-link collapsed btn btn-outline-success col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12" type="button" data-toggle="collapse" data-target="#collapseFilterCategory" aria-expanded="false" aria-controls="collapseFilterCategory">
                                            Kategoriye Göre
                                        </button>
                                        <div id="collapseFilterCategory" class="collapse" data-parent="#accordionSidebar">
                                            <div>
                                                Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                            </div>
                                        </div>
                                    </li>
                                    <li class="nav-item pr-2 pl-2 pt-2">
                                        <button class="nav-link collapsed btn btn-outline-success col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12" type="button" data-toggle="collapse" data-target="#collapseFilterSubCategory" aria-expanded="false" aria-controls="collapseFilterSubCategory">
                                            Alt Kategoriye Göre
                                        </button>
                                        <div id="collapseFilterSubCategory" class="collapse" data-parent="#accordionSidebar">
                                            <div>
                                                Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                            </div>
                                        </div>
                                    </li>
                                    <li class="nav-item pr-2 pl-2 pt-2">
                                        <button class="btn btn-success col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12" type="button">
                                            Filtrele
                                        </button>
                                    </li>
                                </ul>
                            </div>
                        </nav>

                    </div>
                </div>
                <div class="row d-none d-sm-none d-md-none d-lg-block d-xl-block pt-3 pr-4">
                    <asp:Panel ID="pnlContent" runat="server" CssClass="container-fluid">
                        <div class="row">
                            <asp:ListView ID="lvProduct" runat="server">
                                <ItemTemplate>
                                    <div class="col-lg-4 col-xl-3 pt-3">
                                        <a class="btn btn-light" href="#">
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
                </div>
            </div>
        </div>
        <div class="row d-block d-sm-block d-md-block d-lg-none d-xl-none pt-3 pr-4 pl-2">
            <asp:Panel ID="pnlSmall" runat="server" CssClass="container-fluid">
                <div class="row">
                    <asp:ListView ID="lvProductSmall" runat="server">
                        <ItemTemplate>
                            <div class="col-6 col-sm-4 col-md-3 pt-3">
                                <a class="btn btn-light" href="#">
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
        </div>
    </div>
</asp:Content>
