<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="ETicaret.PL.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <hr class="mt-0" />
        <div class="row">
            <div class="col-xl-2 text-center">
                <div class="like-content">
                    <span class="btn-secondary like-review" data-fa="fa-thumbs-up">
                        <i class="fa fa-thumbs-up" aria-hidden="true"></i>
                        <asp:Label ID="lblbtnLike" runat="server" Text="Beğen" ForeColor="White"></asp:Label>
                    </span>
                    <asp:Button ID="btnLike" runat="server" Text="" Visible="true" OnClick="btnLike_Click" Width="0px" />
                </div>
            </div>
            <div class="col-xl-2 text-center">
                <div class="like-content">
                    <span class="btn-secondary like-review" data-fa="fa-thumbs-down">
                        <i class="fa fa-thumbs-down" aria-hidden="true"></i>
                        <asp:Label ID="lblbtndislike" runat="server" Text="Beğenme" ForeColor="White"></asp:Label>
                    </span>
                    <asp:Button ID="btndislike" runat="server" Text="" Visible="true" OnClick="btndislike_Click" />
                </div>
            </div>
            <div class="col-xl-2 text-center">
                <div class="like-content">
                    <span class="btn-secondary like-review" data-fa="fa-comment">
                        <i class="fa fa-comment" aria-hidden="true"></i>Yorum Yap
                    </span>
                    <asp:Button ID="btncomment" runat="server" Text="" Visible="true" OnClick="btncomment_Click" />
                </div>
            </div>
        </div>
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
                    <span class="h4 row pt-4 pl-3">Özellikler</span><hr />
                    <div class="row pt-3">
                        <div class="col-xl-auto pr-0">
                            <asp:Label ID="lblProperties" runat="server" Text="" CssClass="h6"></asp:Label>
                        </div>
                        <div class="col-xl-auto pl-0">
                            <asp:Label ID="lblPropertiesDesc" runat="server" Text="" CssClass="h6"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".like-review").click(function () {
                var fa = $(this).data("fa");
                $(this).children('.' + fa).addClass('animate-like');
                var delayInMilliseconds = 1000;
                setTimeout(function () {
                    if (fa === "fa-thumbs-up") {
                        $('#ContentPlaceHolder1_btnLike').trigger('click');
                    }
                    else if (fa === "fa-thumbs-down") {
                        $('#ContentPlaceHolder1_btndislike').trigger('click');
                    }
                    else if (fa === "fa-comment") {
                        $('#ContentPlaceHolder1_btncomment').trigger('click');
                    }
                }, delayInMilliseconds);
            });
        });
    </script>
</asp:Content>
