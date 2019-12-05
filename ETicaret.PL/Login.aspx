<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ETicaret.PL.Login1" %>

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
<body id="loginBody">
    <div id="login" class="container-fluid">
        <div class="col-10 col-sm-10 col-md-6 col-lg-4 col-xl-4 offset-1 offset-sm-1 offset-md-3 offset-lg-4 offset-xl-4 pt-5">
            <form runat="server">
                <h3 class="text-center text-success">Giriş Yap</h3>
                <asp:Panel ID="pnlDivAlert" runat="server" CssClass="alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center" role="alert" Visible="False">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <asp:Label ID="lblAlert" runat="server" Text=""></asp:Label>
                </asp:Panel>
                <asp:Panel ID="pnlAlertSuccesRegister" runat="server" CssClass="alert alert-success alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center" role="alert" Visible="False">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <asp:Label ID="lblRegSucces" runat="server" Text=""></asp:Label>
                </asp:Panel>
                <div class="form-group">
                    <asp:Label ID="lblUsername" runat="server" Text="Email" for="txtUsername" CssClass="text-success"></asp:Label><br />
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" name="txtUsername"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName" runat="server" ErrorMessage="Email girmelisiniz!" ControlToValidate="txtUsername" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorUsername" runat="server" ErrorMessage="Geçerli bir Email girmelisiniz!" ControlToValidate="txtUsername" ForeColor="#990000" SetFocusOnError="True" ValidationExpression="[\w-]+@([\w-]+\.)+[\w-]+" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblPassword" runat="server" Text="Şifre" for="txtPassword" CssClass="text-success"></asp:Label><br />
                    <asp:TextBox ID="txtPassword" runat="server" name="password" CssClass="form-control" type="password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Şifre girmelisiniz!" ControlToValidate="txtPassword" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <div class="row pt-5">
                        <div class="col-8 col-sm-8 col-md-8 col-lg-8 col-xl-8 text-left">
                            <div class="row">
                                <div class="col-5 col-sm-5 col-md-5 col-lg-5 col-xl-5">
                                    <div class="text-left">
                                        <asp:Button ID="btnLogin" runat="server" Text="Giriş Yap" CssClass="btn btn-outline-success btn-md" OnClick="SignIn" />
                                    </div>
                                </div>
                                <div class="col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6 pl-0">
                                    <label for="cbxRememberMe" class="text-success">
                                        <span>Beni Hatırla</span>
                                        <span>
                                            <asp:CheckBox ID="cbxRememberMe" runat="server" />
                                        </span>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="col-4 col-sm-4 col-md-4 col-lg-4 col-xl-4">
                            <div class="text-right">
                                <asp:LinkButton ID="lnkbtnRegister" href="Register.aspx" runat="server" CssClass="btn btn-outline-success">Kayıt Ol</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div class="row pt-5">
                        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-left">
                            <asp:LinkButton ID="lnkbtnAnasayfa" href="Default.aspx" runat="server" CssClass="btn btn-outline-info">Giriş Yapmadan Devam Et...</asp:LinkButton>
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
