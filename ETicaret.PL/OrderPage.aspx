<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderPage.aspx.cs" Inherits="ETicaret.PL.OrderPage" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
        <asp:Panel ID="pnlDivAlert" runat="server" CssClass="alert alert-danger alert-dismissible col-10 col-sm-10 col-md-10 col-lg-10 col-xl-10 offset-1 offset-sm-1 offset-md-1 offset-lg-1 offset-xl-1 text-center" role="alert" Visible="False">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <asp:Label ID="lblAlert" runat="server" Text=""></asp:Label>
        </asp:Panel>
        <div class="row pt-3 pb-3">
            <asp:Panel ID="pnlContent" runat="server" CssClass="container-fluid">
                <div class="row">
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
                        <div class="row">
                            <div class="col-4 col-sm-4 col-md-3 col-lg-2 col-xl-2 text-center">
                                &nbsp;
                            </div>
                            <div class="col-8 col-sm-8 col-md-9 col-lg-10 col-xl-10">
                                <div class="row">
                                    <div class="col-10 col-sm-10 col-md-10 col-lg-3 col-xl-3 d-none d-sm-none d-md-none d-lg-block d-xl-block">
                                        <span class="footertextcontent h6 font-weight-bold">Ürün Adı</span>
                                    </div>
                                    <div class="col-3 col-sm-3 col-md-3 col-lg-1 col-xl-1">
                                        <span class="footertextcontent h6 font-weight-bold">Adet</span>
                                    </div>
                                    <div class="col-4 col-sm-4 col-md-4 col-lg-3 col-xl-3">
                                        <span class="footertextcontent h6 font-weight-bold">Birim Fiyat</span>
                                    </div>
                                    <div class="col-4 col-sm-4 col-md-4 col-lg-3 col-xl-3">
                                        <span class="footertextcontent h6 font-weight-bold">Toplam</span>
                                    </div>
                                    <div class="text-right pr-5 d-none d-sm-none d-md-none d-lg-block d-xl-block col-1 col-sm-1 col-md-1 col-lg-2 col-xl-2">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:ListView ID="lvProduct" runat="server">
                        <ItemTemplate>
                            <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
                                <hr />
                                <div class="row">
                                    <div class="col-4 col-sm-4 col-md-3 col-lg-2 col-xl-2 text-center">
                                        <img src='<%#Eval("ProductCoverImages") %>' alt='<%#Eval("ProductName") %>' height="60" />
                                    </div>
                                    <div class="col-8 col-sm-8 col-md-9 col-lg-10 col-xl-10">
                                        <div class="row">
                                            <div class="col-9 col-sm-9 col-md-9 col-lg-3 col-xl-3">
                                                <span class="footertextcontent font-weight-bold"><%# Eval("ProductName") %></span>
                                                <hr class="d-block d-sm-block d-md-block d-lg-none d-xl-none" />
                                            </div>
                                            <div class="text-right pr-5 d-block d-sm-block d-md-block d-lg-none d-xl-none col-2 col-sm-2 col-md-2 col-lg-2 col-xl-2">
                                                <asp:Button ID="btnBasketItemDeleteS" runat="server" Text="&times;" Style="background-color: transparent; border: none;" OnClick="btnBasketItemDeleteS_Click" CommandArgument='<%# Eval("ProductId") %>' />
                                            </div>
                                            <div class="col-3 col-sm-3 col-md-3 col-lg-1 col-xl-1">
                                                <div class="row">
                                                    <div class="col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6 pt-2 text-right pr-2">
                                                        <span><%# Eval("Count") %></span>
                                                    </div>
                                                    <div class="col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6 pl-0">
                                                        <asp:Button ID="btnCountAdd" runat="server" Text="+" Style="background-color: transparent; border: none;" OnClick="btnCountAdd_Click" CommandArgument='<%# Eval("ProductId") %>' /><br />
                                                        <asp:Button ID="btnCountDelete" runat="server" Text="-" Style="background-color: transparent; border: none;" OnClick="btnCountDelete_Click" CommandArgument='<%# Eval("ProductId") %>' />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-4 col-sm-4 col-md-4 col-lg-3 col-xl-3">
                                                <span><%# Eval("UnitPrice","{0:c}") %></span>
                                            </div>
                                            <div class="col-4 col-sm-4 col-md-4 col-lg-3 col-xl-3">
                                                <span><%# Eval("Amount","{0:c}") %></span>
                                            </div>
                                            <div class="text-right pr-5 d-none d-sm-none d-md-none d-lg-block d-xl-block col-1 col-sm-1 col-md-1 col-lg-2 col-xl-2">
                                                <asp:Button ID="btnBasketItemDelete" runat="server" Text="&times;" Style="background-color: transparent; border: none;" OnClick="btnBasketItemDelete_Click" CommandArgument='<%# Eval("ProductId") %>' />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <hr />
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
                <hr />
                <div class="row">
                    <div class="col-12 col-sm-12 col-md-8 col-lg-6 col-xl-6">
                        <span class="alert-warning h6">Ürünler sipariş onayından sonra 7 gün içinde teslim edilir.</span><br />
                        <span class="font-weight-bold h5">Teslim Tarihi:&nbsp;</span><asp:Label CssClass="h5" ID="lblDeliveryDate" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-12 col-sm-12 col-md-4 col-lg-6 col-xl-6">
                        <br />
                        <span class="font-weight-bold h5">Toplam Tutar:&nbsp;</span><asp:Label CssClass="h5" ID="lblTotalPrice" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center">
                        <asp:Button ID="btnAccessOrder" runat="server" Text="Siparişi Onayla" CssClass="btn btn-outline-success" OnClick="btnAccessOrder_Click" />
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlEmtyList" runat="server" CssClass="container-fluid" Visible="false">
                <div class="container pt-5 pb-5 text-center" style="min-height: 350px;">
                    <span class="h4">Sepetiniz boş! Hadi ürünler sizi bekliyor.</span>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
