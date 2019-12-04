<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="ETicaret.PL.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
        <hr />
        <asp:Panel ID="pnlDivAlert" runat="server" CssClass="alert alert-danger alert-dismissible col-10 col-sm-10 col-md-10 col-lg-10 col-xl-10 offset-1 offset-sm-1 offset-md-1 offset-lg-1 offset-xl-1 text-center" role="alert" Visible="False">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <asp:Label ID="lblAlert" runat="server" Text=""></asp:Label>
        </asp:Panel>
        <div class="row pt-3 pb-3">
            <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-5 text-center">
                <asp:Image ID="ProfileImg" runat="server" CssClass="rounded-circle" alt="ProfilResmi" /><br />
                <asp:FileUpload ID="FileUploadProfileImage" runat="server" />
                <span id="ProfileImageSelect" class="btn btn-outline-info" style="width: 200px;">Fotoğrafı Değiştir</span>
                <asp:Button ID="btnImageUpdate" runat="server" Text="" OnClick="btnImageUpdate_Click" />
            </div>
            <div class="col-12 col-sm-12 col-md-4 col-lg-5 col-xl-5 text-center pt-3 text-xl-left text-lg-left text-md-left text-sm-center">
                <asp:Label ID="lblNameSurname" runat="server" Text="" CssClass="h5 pb-3"></asp:Label><br />
                <asp:Label ID="lblEmail" runat="server" Text="" CssClass="h6 pb-1"></asp:Label><br />
                <asp:Label ID="lblPhone" runat="server" Text="" CssClass="h6 pb-1"></asp:Label><br />
                <asp:Label ID="lblAdress" runat="server" Text="" CssClass="h6 pb-1"></asp:Label><br />
                <asp:Label ID="lblProvince" runat="server" Text="" CssClass="h6 pb-1"></asp:Label><br />
                <asp:Label ID="lblDistrict" runat="server" Text="" CssClass="h6 pb-1"></asp:Label><br />
            </div>
            <div class="col-12 col-sm-12 col-md-4 col-lg-3 col-xl-2 text-center text-xl-left text-lg-left text-md-left text-sm-center pt-5">
                <asp:Button ID="btnProfileUpdate" runat="server" Text="Bilgileri Düzenle" CssClass="btn btn-outline-warning" OnClick="btnProfileUpdate_Click" /><br />
                <br />
                <button type="button" class="btn btn-outline-danger" data-toggle="modal" data-target="#PasswordModal">
                    Şifre Değiştir
                </button>
            </div>
        </div>
        <hr />
        <div class="row">
            <asp:Panel ID="pnlOrderContent" runat="server" CssClass="container-fluid">
                <div class="row p-3">
                    <asp:ListView ID="lvOrders" runat="server">
                        <ItemTemplate>
                            <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 text-center">
                                <div class="card mb-2">
                                    <span>Sipariş Tarihi</span>
                                    <span class="badge badge-pill badge-light"><%# Eval("AddedDate") %></span><br />
                                    <span>Toplam Ürün Sayısı</span>
                                    <span class="badge badge-pill badge-light"><%# Eval("TotalProductCount") %></span><br />
                                    <span>Toplam Fiyat</span>
                                    <span class="badge badge-pill badge-light"><%# Eval("TotalPrice") %></span><br />
                                    <span>Teslim Tarihi</span>
                                    <span class="badge badge-pill badge-light"><%# Eval("DeliveryDate", "{0:d}") %></span><br />
                                    <div class="row mb-2">
                                        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center">
                                            <a class="btn btn-outline-info pt-1 pb-1" href="OrderDetails.aspx?OrderId=<%# Eval("Id") %>">Detaylar
                                            </a>
                                        </div>
                                    </div>
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
    </div>
    <asp:Panel ID="pnlPasswordModal" runat="server" DefaultButton="btnModalPasswordSave">
        <!-- PasswordModal -->
        <div class="modal fade" id="PasswordModal" tabindex="-1" role="dialog" aria-labelledby="PasswordModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="BrandModalLabel">Şifre Değiştir</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <asp:Label ID="lblOldPasswoprd" runat="server" Text="Eski Şifre" for="txtOldPassword" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtOldPassword" runat="server" name="oldpassword" CssClass="form-control" type="password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorOldPassword" runat="server" ErrorMessage="Eski Şifrenizi girmelisiniz!" ControlToValidate="txtOldPassword" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="ModalPasswordValidate"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="CustomValidatorOldPassword" runat="server" ErrorMessage="Geçersiz şifre!" Display="Dynamic" SetFocusOnError="True" ForeColor="#990000" ControlToValidate="txtOldPassword" OnServerValidate="CustomValidatorPassword_ServerValidate" ValidationGroup="ModalPasswordValidate"></asp:CustomValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblPassword" runat="server" Text="Yeni Şifre" for="txtPassword" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtPassword" runat="server" name="password" CssClass="form-control" type="password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Şifre girmelisiniz!" ControlToValidate="txtPassword" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="ModalPasswordValidate"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="CustomValidatorPassword" runat="server" ErrorMessage="Geçersiz şifre!" Display="Dynamic" SetFocusOnError="True" ForeColor="#990000" ControlToValidate="txtPassword" OnServerValidate="CustomValidatorPassword_ServerValidate" ValidationGroup="ModalPasswordValidate"></asp:CustomValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblRePassword" runat="server" Text="Yeni Şifre(Tekrar)" for="txtRePassword" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtRePassword" runat="server" name="repassword" CssClass="form-control" type="password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorRePassword" runat="server" ErrorMessage="Şifreyi tekrar girmelisiniz!" ControlToValidate="txtRePassword" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ValidationGroup="ModalPasswordValidate"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidatorRePassword" runat="server" ErrorMessage="Şifre eşleştirilemedi!" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ControlToCompare="txtPassword" ControlToValidate="txtRePassword" ValidationGroup="ModalPasswordValidate"></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Vazgeç</button>
                        <asp:Button ValidationGroup="ModalPasswordValidate" ID="btnModalPasswordSave" runat="server" Text="Kaydet" CssClass="btn btn-success" OnClick="btnModalPasswordSave_Click" />
                    </div>
                </div>
            </div>
        </div>
        <!-- BrandModal End-->
    </asp:Panel>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ProfileImageSelect").click(function () {
                $('#ContentPlaceHolder1_FileUploadProfileImage').trigger('click');
            });
            $("#ContentPlaceHolder1_FileUploadProfileImage").change(function () {
                console.log("a");
                $('#ContentPlaceHolder1_btnImageUpdate').trigger('click');
            });
        });
    </script>
</asp:Content>
