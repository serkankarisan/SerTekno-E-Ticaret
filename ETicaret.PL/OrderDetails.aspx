<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="ETicaret.PL.OrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <div class="row">
        <asp:Panel ID="pnlOrderDetailContent" runat="server" CssClass="container-fluid">
            <div class="row p-3">
                <asp:ListView ID="lvOrderDetails" runat="server">
                    <ItemTemplate>
                        <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 text-center">
                            <div class="card">
                              <%--  <span>Sipariş Tarihi</span>
                                <span class="badge badge-pill badge-light"><%# Eval("AddedDate") %></span><br />
                                <span>Toplam Ürün Sayısı</span>
                                <span class="badge badge-pill badge-light"><%# Eval("TotalProductCount") %></span><br />
                                <span>Toplam Fiyat</span>
                                <span class="badge badge-pill badge-light"><%# Eval("TotalPrice") %></span><br />
                                <span>Teslim Tarihi</span>
                                <span class="badge badge-pill badge-light"><%# Eval("DeliveryDate", "{0:d}") %></span>--%>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlEmtyList" runat="server" CssClass="container-fluid" Visible="false">
            <div class="container pt-5 pb-5 text-center" style="min-height: 350px;">
                <span class="h4">Henüz sipariş vermemişsiniz! Ürünlerimiz sizi bekliyor.</span>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
