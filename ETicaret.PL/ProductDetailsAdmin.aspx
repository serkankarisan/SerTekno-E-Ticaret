<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetailsAdmin.aspx.cs" Inherits="ETicaret.PL.ProductDetailsAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-xl-6">
                <div id="pnlcarouselProductIndicators" class="carousel slide" data-ride="carousel">
                        <asp:Label ID="lblCarouselIndicators" runat="server" Text=""></asp:Label>
                        <div id="pnlCarouselInner" class="carousel-inner">
                            <asp:Label ID="lblCarouselInner" runat="server" Text=""></asp:Label>
                        </div>
                        <a class="carousel-control-prev" href="#pnlcarouselProductIndicators" role="button" data-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="sr-only">Önceki</span>
                        </a>
                        <a class="carousel-control-next" href="#pnlcarouselProductIndicators" role="button" data-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="sr-only">Sonraki</span>
                        </a>
                </div>
            </div>
            <div class="col-xl-6">
            </div>
        </div>
    </div>
</asp:Content>
