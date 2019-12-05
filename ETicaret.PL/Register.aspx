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
                    <asp:Panel ID="pnlDivAlert" runat="server" CssClass="alert alert-danger alert-dismissible col-10 col-sm-10 col-md-10 col-lg-10 col-xl-10 offset-1 offset-sm-1 offset-md-1 offset-lg-1 offset-xl-1 text-center" role="alert" Visible="False">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <asp:Label ID="lblAlert" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                    <div class="col-10 col-sm-10 col-md-8 col-lg-4 col-xl-4 offset-1 offset-sm-1 offset-md-2 offset-lg-1 offset-xl-1">
                        <div class="form-group">
                            <asp:Label ID="lblName" runat="server" Text="Ad" for="txtName" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" name="txtName"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ErrorMessage="Adınızı girmelisiniz!" ControlToValidate="txtName" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblSurName" runat="server" Text="Soyad" for="txtSurName" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtSurName" runat="server" name="SurName" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorSurName" runat="server" ErrorMessage="Soyadınızı girmelisiniz!" ControlToValidate="txtSurName" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblEmail" runat="server" Text="Email" for="txtEmail" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" name="txtEmail"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="Email girmelisiniz!" ControlToValidate="txtEmail" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ErrorMessage="Geçerli bir Email girmelisiniz!" ControlToValidate="txtEmail" ForeColor="#990000" SetFocusOnError="True" ValidationExpression="[\w-]+@([\w-]+\.)+[\w-]+" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblPhoneNumber" runat="server" Text="Telefon( 5XXXXXXXXX )" for="txtPhoneNumber" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" name="txtPhoneNumber" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhoneNumber" runat="server" ErrorMessage="Telefon numarası girmelisiniz!" ControlToValidate="txtPhoneNumber" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPhoneNumber" runat="server" ErrorMessage="Geçerli bir telefon numarası girmelisiniz!" ControlToValidate="txtPhoneNumber" ForeColor="#990000" SetFocusOnError="True" ValidationExpression="(([\+]90?)|([0]?))([ ]?)((\([0-9]{3}\))|([0-9]{3}))([ ]?)([0-9]{3})(\s*[\-]?)([0-9]{2})(\s*[\-]?)([0-9]{2})" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblPassword" runat="server" Text="Şifre" for="txtPassword" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtPassword" runat="server" name="password" CssClass="form-control" type="password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Şifre girmelisiniz!" ControlToValidate="txtPassword" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="CustomValidatorPassword" runat="server" ErrorMessage="Geçersiz şifre!" Display="Dynamic" SetFocusOnError="True" ForeColor="#990000" ControlToValidate="txtPassword" OnServerValidate="CustomValidatorPassword_ServerValidate"></asp:CustomValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblRePassword" runat="server" Text="Şifre(Tekrar)" for="txtRePassword" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtRePassword" runat="server" name="repassword" CssClass="form-control" type="password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorRePassword" runat="server" ErrorMessage="Şifreyi tekrar girmelisiniz!" ControlToValidate="txtRePassword" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidatorRePassword" runat="server" ErrorMessage="Şifre eşleştirilemedi!" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic" ControlToCompare="txtPassword" ControlToValidate="txtRePassword"></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="col-10 col-sm-10 col-md-8 col-lg-4 col-xl-4 offset-1 offset-sm-1 offset-md-2 offset-lg-2 offset-xl-2">
                        <div class="form-group">
                            <asp:Label ID="lblAdress" runat="server" Text="Adres" for="txtAdress" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtAdress" runat="server" CssClass="form-control" TextMode="MultiLine" name="txtAdress" Rows="4" Columns="6"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAdress" runat="server" ErrorMessage="Adres girmelisiniz!" ControlToValidate="txtAdress" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblZipCode" runat="server" Text="Alan Kodu" for="txtZipCode" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtZipCode" runat="server" name="ZipCode" CssClass="form-control" MaxLength="5"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorZipCode" runat="server" ErrorMessage="Alan kodu girmelisiniz!" ControlToValidate="txtZipCode" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorZipCode" runat="server" ErrorMessage="Geçerli bir Alan kodu girmelisiniz!" ControlToValidate="txtZipCode" ForeColor="#990000" SetFocusOnError="True" ValidationExpression="^[-+]?\d+$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblProvince" runat="server" Text="Şehir" for="txtProvince" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtProvince" runat="server" CssClass="form-control" name="txtProvince"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorProvinve" runat="server" ErrorMessage="Şehir adı girmelisiniz!" ControlToValidate="txtProvince" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblDistrict" runat="server" Text="İlçe" for="txtDistrict" CssClass="text-success"></asp:Label><br />
                            <asp:TextBox ID="txtDistrict" runat="server" name="District" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDistrict" runat="server" ErrorMessage="İlçe adı girmelisiniz!" ControlToValidate="txtDistrict" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblGender" runat="server" Text="Cinsiyet" for="ddlGender" CssClass="text-success"></asp:Label><br />
                            <asp:DropDownList ID="ddlGender" runat="server" CssClass="dropdown form-control">
                                <asp:ListItem Text="" Value="" />
                                <asp:ListItem Text="Erkek" Value="Erkek" />
                                <asp:ListItem Text="Kadın" Value="Kadın" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server" ErrorMessage="Cinsiyet seçmelisiniz!" ControlToValidate="ddlGender" SetFocusOnError="True" ForeColor="#990000" Display="Dynamic"></asp:RequiredFieldValidator>
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
