<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetailsAdmin.aspx.cs" Inherits="ETicaret.PL.ProductDetailsAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <hr class="mt-0" />
        <div class="row">
            <asp:Panel ID="pnlAlertDiv" runat="server" role="alert" Visible="False">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <asp:Label ID="lblAlertDiv" runat="server" Text=""></asp:Label>
            </asp:Panel>
        </div>
        <div class="row">
            <div class="col-4 col-sm-4 col-md-4 col-lg-2 col-xl-2 text-center">
                <div class="like-content">
                    <span class="btn-secondary like-review" data-fa="fa-thumbs-up">
                        <i class="fa fa-thumbs-up" aria-hidden="true"></i>
                        <asp:Label ID="lblbtnLike" runat="server" Text="Beğen" ForeColor="White"></asp:Label>
                    </span>
                    <asp:Button ID="btnLike" runat="server" Text="" Visible="true" OnClick="btnLike_Click" Width="0px" />
                </div>
            </div>
            <div class="col-4 col-sm-4 col-md-4 col-lg-2 col-xl-2 text-center">
                <div class="like-content">
                    <span class="btn-secondary like-review" data-fa="fa-thumbs-down">
                        <i class="fa fa-thumbs-down" aria-hidden="true"></i>
                        <asp:Label ID="lblbtndislike" runat="server" Text="Beğenme" ForeColor="White"></asp:Label>
                    </span>
                    <asp:Button ID="btndislike" runat="server" Text="" Visible="true" OnClick="btndislike_Click" />
                </div>
            </div>
            <div class="col-4 col-sm-4 col-md-4 col-lg-2 col-xl-2 text-center">
                <div class="like-content">
                    <span class="btn-secondary like-review" data-fa="fa-comment" data-toggle="modal" data-target="#CommentModal">
                        <i class="fa fa-comment" aria-hidden="true"></i>Yorum Yap
                    </span>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6 pt-3 pb-3">
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
                <asp:Panel ID="pnlComments" runat="server" CssClass="pl-3 pr-3">
                    <div>
                        <span class="h5">Yorumlar</span>
                        <hr class="mt-0" />
                    </div>
                    <asp:Label ID="lblCommentItem" runat="server" Text=""></asp:Label>
                </asp:Panel>
            </div>
            <div class="col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6">
                <div class="container">
                    <div class="row">
                        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
                            <asp:Label ID="lblBrand" runat="server" Text="" CssClass="h3"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
                            <asp:Label ID="lblProductName" runat="server" Text="" CssClass="h4"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 pt-3 pb-3">
                            <asp:Label ID="lblPrice" runat="server" Text="" CssClass="h5"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6 col-sm-6 col-md-6 col-lg-2 col-xl-2">
                            <asp:TextBox ID="txtCount" TextMode="Number" Min="1" Text="1" runat="server" CssClass="form-control" Width="100px"></asp:TextBox>
                        </div>
                        <div class="col-6 col-sm-6 col-md-6 col-lg-8 col-xl-8 text-right">
                            <asp:Button ID="btnAddBasket" runat="server" Text="Sepete Ekle" OnClick="btnAddBasket_Click" CssClass="btn btn-outline-success" />
                        </div>
                    </div>
                    <span class="h4 row pt-4 pl-3">Özellikler</span><hr />
                    <div class="row pt-3">
                        <div class="col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6 pr-0">
                            <asp:Label ID="lblProperties" runat="server" Text="" CssClass="h6"></asp:Label>
                        </div>
                        <div class="col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6 pl-0">
                            <asp:Label ID="lblPropertiesDesc" runat="server" Text="" CssClass="h6"></asp:Label>
                        </div>
                    </div>
                    <span class="h5 row pt-5 pl-3">Öneriler</span><hr />
                    <div class="row">                       
                        <asp:ListView ID="lvProductSmall" runat="server">
                            <ItemTemplate>
                                <div class="col-6 col-sm-6 col-md-4 col-lg-6 col-xl-4 pt-3">
                                    <a class="btn btn-light" href='ProductDetailsAdmin.aspx?ProductId=<%#Eval("Id") %>'>
                                        <div class="container card border-success" style="height: 200px; width: 170px;">
                                            <div class="row">
                                                <div class="container-fluid text-center pt-2" style="min-height: 75px;">
                                                    <img src='<%#Eval("ProductCoverImages") %>' alt='<%#Eval("ProductName") %>' height="60" width="55" />
                                                </div>
                                            </div>
                                            <div class="row" style="min-height: 80px;">
                                                <div class="col-12 col-sm-12 col-md-12 text-success text-center">
                                                    <span class="wordwrap h6"><%# Eval("ProductName") %></span>
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
                </div>
            </div>
        </div>
    </div>
    <asp:Panel ID="pnlModalSubCategory" runat="server" DefaultButton="btnModalCommentSave">
        <!-- CommentModal -->
        <div class="modal fade" id="CommentModal" tabindex="-1" role="dialog" aria-labelledby="CommentModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="CommentModalLabel">Yorum Yap</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <asp:Label ID="lblCommentModal" runat="server" Text="Yorumunuz" for="txtModalComment" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtModalComment" runat="server" CssClass="form-control" name="txtModalComment" Columns="5" Rows="4" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorModalComment" runat="server" ErrorMessage="Yorum girmelisiniz!" ControlToValidate="txtModalComment" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="ModalCommentValidate"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Vazgeç</button>
                        <asp:Button ID="btnModalCommentSave" runat="server" Text="Kaydet" CssClass="btn btn-success" ValidationGroup="ModalCommentValidate" OnClick="btncomment_Click" />
                    </div>
                </div>
            </div>
        </div>
        <!-- CommentModal End-->
    </asp:Panel>
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

                    }
                }, delayInMilliseconds);
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".btnCommentDelete").click(function () {
                var commid = $(this).data("commid");
                var productid = $(this).data("productid");
                '<%Session["commentdel"] = "true"; %>';
                var result = confirm("Silmek istiyor musunuz?");
                if (result) {
                    window.location.href = "http://localhost:51010/ProductDetailsAdmin.aspx?ProductId=" + productid + "&CommentID=" + commid;
                }
            });
        });
    </script>
</asp:Content>
