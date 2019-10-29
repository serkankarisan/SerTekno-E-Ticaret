<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="ETicaret.PL.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-xl-6 pt-3 pb-3">
                <div id="pnlcarouselProductIndicators" class="carousel slide text-center" data-ride="carousel">
                    <asp:Label ID="lblCarouselIndicators" runat="server" Text=""></asp:Label>
                    <div id="pnlCarouselInner" class="carousel-inner">
                        <asp:Label ID="lblCarouselInner" runat="server" Text=""></asp:Label>
                    </div>
                    <a class="carousel-control-prev" href="#pnlcarouselProductIndicators" role="button" data-slide="prev">
                        <span id="prev-btn" class="carousel-control-prev-icon" style="color: red" aria-hidden="true"></span>
                        <span class="sr-only">Önceki</span>
                    </a>
                    <a class="carousel-control-next" href="#pnlcarouselProductIndicators" role="button" data-slide="next">
                        <span id="next-btn" class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="sr-only">Sonraki</span>
                    </a>
                </div>
            </div>
            <div class="col-xl-6">
                <div class="container">
                    <div class="row">
                        <div class="col-xl-12">
                            <asp:Label ID="lblBrand" runat="server" Text="" CssClass="h3"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xl-12">
                            <asp:Label ID="lblProductName" runat="server" Text="" CssClass="h4"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xl-12 pt-3 pb-3">
                            <asp:Label ID="lblPrice" runat="server" Text="" CssClass="h5"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xl-2">
                            <asp:TextBox ID="txtCount" TextMode="Number" Min="1" Text="1" runat="server" CssClass="form-control" Width="100px"></asp:TextBox>
                        </div>
                        <div class="col-xl-8">
                            <asp:Button ID="btnAddBasket" runat="server" Text="Sepete Ekle" OnClick="btnAddBasket_Click" CssClass="btn btn-outline-success" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
