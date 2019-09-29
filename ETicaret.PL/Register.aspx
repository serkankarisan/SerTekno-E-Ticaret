<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ETicaret.PL.Register1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link href="Content/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">
    <link href="Content/css/normalize.css" rel="stylesheet" />
    <link href="Content/css/Style.css" rel="stylesheet" />
</head>
<body id="RegisterBody">
    <div id="Register" class="container-fluid">
        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 pt-5">
            <form runat="server">
               
                <div class="row">
                     <h3 class="text-center text-success col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">Kayıt Ol</h3>
                    <div class="col-10 col-sm-10 col-md-8 col-lg-4 col-xl-4 offset-1 offset-sm-1 offset-md-2 offset-lg-1 offset-xl-1">
                        <div class="form-group">
                            <asp:Label ID="lblName" runat="server" Text="Ad" for="txtName" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" name="txtName"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblSurName" runat="server" Text="Soyad" for="txtSurName" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtSurName" runat="server" name="SurName" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblEmail" runat="server" Text="Email" for="txtEmail" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" name="txtEmail"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblPassword" runat="server" Text="Şifre" for="txtPassword" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtPassword" runat="server" name="password" CssClass="form-control" type="password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblRePassword" runat="server" Text="Şifre(Tekrar)" for="txtRePassword" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtRePassword" runat="server" name="repassword" CssClass="form-control" type="password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-10 col-sm-10 col-md-8 col-lg-4 col-xl-4 offset-1 offset-sm-1 offset-md-2 offset-lg-2 offset-xl-2">
                        <div class="form-group">
                            <asp:Label ID="lblAdress" runat="server" Text="Adres" for="txtAdress" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtAdress" runat="server" CssClass="form-control" name="txtAdress" Rows="4" Columns="6"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblZipCode" runat="server" Text="Alan Kodu" for="txtZipCode" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtZipCode" runat="server" name="ZipCode" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblProvince" runat="server" Text="Şehir" for="txtProvince" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtProvince" runat="server" CssClass="form-control" name="txtProvince"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblDistrict" runat="server" Text="İlçe" for="txtDistrict" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtDistrict" runat="server" name="District" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblPhoneNumber" runat="server" Text="Telefon" for="txtPhoneNumber" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" name="txtPhoneNumber"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblGender" runat="server" Text="Cinsiyet" for="ddlGender" CssClass="text-success"></asp:Label><br />
                            <asp:DropDownList ID="ddlGender" runat="server" CssClass="dropdown form-control">
                                <asp:ListItem Text="Erkek" Value="Erkek" />
                                <asp:ListItem Text="Kadın" Value="Kadın" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row pt-5">
                        <div class="col-6 col-sm-6 col-md-4 col-lg-6 col-xl-6 offset-1 offset-sm-1 offset-md-2 offset-lg-1 offset-xl-1 text-left">
                            <div class="text-left">
                                <asp:Button ID="btnRegister" runat="server" Text="Kayıt Ol" CssClass="btn btn-outline-success btn-md" OnClick="CreateUser_Click" />
                            </div>
                        </div>
                        <div class="col-4 col-sm-4 col-md-4 col-lg-4 col-xl-4">
                            <div class="text-right">
                                <asp:LinkButton ID="lnkbtnAnasayfa" href="Default.aspx" runat="server" CssClass="btn btn-outline-info">Vazgeç ve Keşfet...</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    </div>


    <script src="Content/js/jquery-3.4.1.min.js"></script>
    <script src="Content/js/popper.min.js"></script>
    <script src="Content/js/bootstrap.min.js"></script>
</body>
</html>
