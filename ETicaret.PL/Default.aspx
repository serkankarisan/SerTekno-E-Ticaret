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
            <div class="col-3 col-sm-3 col-md-3 col-lg-3 col-xl-3">
                <ul class="navbar-nav">
                                <li class="nav-item">
                                    <a class="nav-link" href="Default.aspx">Markalar</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#">Kategoriler</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link " href="#">Alt Kategoriler</a>
                                </li>
                            </ul>
            </div>
            <div class="col-9 col-sm-9 col-md-9 col-lg-9 col-xl-9">
                aaa
            </div>
        </div>
    </div>
</asp:Content>
