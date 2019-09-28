<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="denemeRegister.aspx.cs" Inherits="ETicaret.PL.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h4 style="font-size: medium">Yeni kullanıcı oluştur.</h4>
            <hr />
            <p>
                <asp:Literal runat="server" ID="StatusMessage" />
            </p>
            <div style="margin-bottom: 10px">
                <asp:Label runat="server" AssociatedControlID="UserName">Kullanıcı Adı</asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="UserName" />
                </div>
            </div>
            <div style="margin-bottom: 10px">
                <asp:Label runat="server" AssociatedControlID="Password">Şifre</asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                </div>
            </div>
            <div style="margin-bottom: 10px">
                <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Şifre(Tekrar)</asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                </div>
            </div>
            <div>
                <div>
                    <asp:Button runat="server" OnClick="CreateUser_Click" Text="Oluştur" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
