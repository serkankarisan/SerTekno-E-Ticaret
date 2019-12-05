<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="ETicaret.PL.OrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <asp:Panel ID="pnlOrderDetailContent" runat="server" CssClass="container-fluid">
        <div class="row p-3">
            <asp:ListView ID="lvOrderDetails" runat="server">
                <ItemTemplate>
                    <asp:Panel ID="pnlOrderDetail" runat="server" CssClass='<%# ((int)Eval("DifferentProductCount") == 1) ? "col-12 col-sm-6 col-md-4 col-lg-4 col-xl-4 text-center offset-xl-4 offset-lg-4 offset-md-4 offset-sm-3 pb-3" : ((int)Eval("DifferentProductCount") == 2) ? "col-12 col-sm-6 col-md-5 col-lg-4 col-xl-4 text-center offset-xl-1 offset-lg-1 offset-md-1 pb-3" : ((int)Eval("DifferentProductCount") > 2) ?"col-12 col-sm-6 col-md-6 col-lg-4 col-xl-4 text-center pb-3":""%>'>
                        <div class="card">
                            <span>Ürün Adı</span>
                            <span class="badge badge-pill badge-light"><%# Eval("ProductName") %></span><br />
                            <span>Marka</span>
                            <span class="badge badge-pill badge-light"><%# Eval("Brand") %></span><br />
                            <span>Kategori</span>
                            <span class="badge badge-pill badge-light"><%# Eval("Category") %></span><br />
                            <span>Birim Fiyat</span>
                            <span class="badge badge-pill badge-light"><%# Eval("UnitPrice","{0:c}") %></span><br />
                            <span>Ürün Sayısı</span>
                            <span class="badge badge-pill badge-light"><%# Eval("Count") %></span><br />
                            <span>Tutar</span>
                            <span class="badge badge-pill badge-light"><%# Eval("Amount","{0:c}") %></span>
                        </div>
                    </asp:Panel>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <hr />
        <div class="row">
            <div class="col-12 col-sm-6 col-md-3 col-lg-3 col-xl-3">
                <span class="font-weight-bold h5">Sipariş Tarihi:&nbsp;</span><asp:Label CssClass="h5" ID="lblOrderDate" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-12 col-sm-6 col-md-3 col-lg-3 col-xl-3">
                <span class="font-weight-bold h5">Ürün Sayısı:&nbsp;</span><asp:Label CssClass="h5" ID="lblProductCount" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-12 col-sm-6 col-md-3 col-lg-3 col-xl-3">
                <span class="font-weight-bold h5">Teslim Tarihi:&nbsp;</span><asp:Label CssClass="h5" ID="lblDeliveryDate" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-12 col-sm-6 col-md-3 col-lg-3 col-xl-3">
                <span class="font-weight-bold h5">Toplam Tutar:&nbsp;</span><asp:Label CssClass="h5" ID="lblTotalPrice" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <hr />
    </asp:Panel>
    <asp:Panel ID="pnlEmtyList" runat="server" CssClass="container-fluid" Visible="false">
        <div class="container pt-5 pb-5 text-center" style="min-height: 350px;">
            <span class="h4">Detaylara ulaşılamadı! Tekrar giriş yapmayı deneyin.</span>
        </div>
    </asp:Panel>
</asp:Content>
