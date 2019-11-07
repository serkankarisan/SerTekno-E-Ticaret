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
                        <div class="col-8 col-sm-7 col-md-7 col-lg-7 col-xl-7">
                            <asp:Label ID="lblProductName" runat="server" Text="" CssClass="h4"></asp:Label>
                        </div>
                        <div class="pl-0 col-4 col-sm-5 col-md-5 col-lg-5 col-xl-5">
                            <asp:Panel ID="pnlAddImages" runat="server" DefaultButton="btnAddImages" CssClass="row">
                                <div class="mb-1 col-12 col-sm-7 col-md-7 col-lg-7 col-xl-7 pl-1 pr-1">
                                    <div class="input-group ">
                                        <div class="input-group-btn">
                                            <span class="fileUpload btn btn-outline-primary">
                                                <span class="upl" id="upload">Resim Ekle</span>
                                                <asp:FileUpload ID="FileUploadProductImages" AllowMultiple="true" runat="server" CssClass="upload up" onchange="UploadChange(this)" />
                                            </span>
                                        </div>
                                    </div>
                                    <span id="SelectedImages" class="text-success h6"></span>
                                </div>
                                <div id="DivImageSave" class="col-5 col-sm-5 col-md-5 col-lg-5 col-xl-5" style="display: none;">
                                    <asp:Button ID="btnAddImages" runat="server" Text="Kaydet" CssClass="btn btn-outline-primary pt-0 pb-0" ValidationGroup="ProductImagesValidate" OnClick="btnAddImages_Click" /><br />
                                    <asp:Button ID="btnIptal" runat="server" Text="Iptal" CssClass="btn btn-outline-secondary pt-0 pb-0 mt-1" />
                                </div>
                                <div id="DivImageDelete" class="col-12 col-sm-5 col-md-5 col-lg-5 col-xl-5 pl-1 pr-1">
                                    <button type="button" class="btn btn-outline-danger" data-toggle="modal" data-target="#ImageDeleteModal">Resim Sil</button>
                                </div>
                            </asp:Panel>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCoverImage" runat="server" ErrorMessage="En az 1 adet fotoğraf seçmelisiniz!" ControlToValidate="FileUploadProductImages" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="ProductImagesValidate"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 pt-3 pb-3">
                            <asp:Label ID="lblPrice" runat="server" Text="" CssClass="h5"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6 col-sm-6 col-md-2 col-lg-3 col-xl-3">
                            <asp:TextBox ID="txtCount" TextMode="Number" Min="1" Text="1" runat="server" CssClass="form-control" Width="100px"></asp:TextBox>
                        </div>
                        <div class="col-6 col-sm-6 col-md-2 col-lg-4 col-xl-3 text-right">
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
                                                    <span class="wordwrap" style="font-size: 13px;"><%# Eval("ProductName") %></span>
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
    <asp:Panel ID="pnlModalComment" runat="server" DefaultButton="btnModalCommentSave">
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
    <asp:Panel ID="pnlModalImageDelete" runat="server" DefaultButton="btnImagesDelete">
        <!-- ImageDeleteModal -->
        <div class="modal fade" id="ImageDeleteModal" tabindex="-1" role="dialog" aria-labelledby="ImageDeleteModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="ImageDeleteModalLabel">Fotoğraf Sil</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row h6">
                            <span class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center">Silmek İstediğin fotoğrafları seçiniz.</span>
                        </div>
                        <div class="row">
                            <asp:ListView ID="lvImagesDel" runat="server">
                                <ItemTemplate>
                                    <a href="#" data-imgid='<%#Eval("Id") %>' class="col-6 col-sm-6 col-md-4 col-lg-6 col-xl-4 mb-2 ImageDelBtn">
                                        <div class="card p-1">
                                            <div class="container-fluid text-center" style="height: 100px;">
                                                <img src='<%#Eval("ImagesPath") %>' alt='<%#Eval("ProductId")+"_"+Eval("Id") %>' height="100" width="95" />
                                            </div>
                                        </div>
                                    </a>

                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                        <asp:TextBox ID="txtSessionImgID" runat="server"></asp:TextBox>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnImagesDelete" runat="server" Text="Sil" CssClass="btn btn-success" OnClick="btnImagesDelete_Click" />
                        <button id="btnImageDeleteModalCancel" type="button" class="btn btn-secondary" data-dismiss="modal">Vazgeç</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- ImageDeleteModal End-->
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
    <script type="text/javascript">
        function UploadChange(Input) {
            var fi = document.getElementById(Input.id);
            $("#SelectedImages").text(fi.files.length + " Dosya seçildi");
            $("#upload").text("Yeniden Seç");
            $('#DivImageSave').removeAttr("style");
            $('#DivImageDelete').attr("style", "display: none;");
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            var ImgIdList = new Array();
            $(".ImageDelBtn").click(function () {
                var Imgid = $(this).data("imgid");
                var contains = ImgIdList.includes(Imgid);
                if (!contains) {
                    ImgIdList.push(Imgid);
                    $(this).children("div:last-child").attr("style", "border: 2px solid #6DB72C;");
                } else {
                    var index = ImgIdList.indexOf(Imgid);
                    if (index !== -1)
                        ImgIdList.splice(index, 1);
                    $(this).children("div:last-child").removeAttr("style");
                }
                '<%Session["ImgIdList"] = "' + ImgIdList + '"; %>';
                $("#ContentPlaceHolder1_txtSessionImgID").val('<%=Session["ImgIdList"]%>');
            });
            $(".btnImageDeleteModalCancel").click(function () {
                var ImgIdList = new Array();
                '<%Session["ImgIdList"] = "' + ImgIdList + '"; %>';
               
            });
        });
    </script>
</asp:Content>
