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
        <div class="col-10 col-sm-10 col-md-6 col-lg-4 col-xl-4 offset-1 offset-sm-1 offset-md-3 offset-lg-4 offset-xl-4 pt-5">
            <form action="" method="post">
                <h3 class="text-center text-success">Kayıt Ol</h3>
                <div class="form-group">
                    <label for="username" class="text-success">Kullanıcı Adı:</label><br>
                    <input type="text" name="username" id="username" class="form-control">
                </div>
                <div class="form-group">
                    <label for="password" class="text-success">Şifre:</label><br>
                    <input type="text" name="password" id="password" class="form-control">
                </div>
                <div class="text-right">
                    <a href="#" class="btn btn-outline-success">Kayıt Ol</a>
                </div>
            </form>
        </div>
    </div>


    <script src="Content/js/jquery-3.4.1.min.js"></script>
    <script src="Content/js/popper.min.js"></script>
    <script src="Content/js/bootstrap.min.js"></script>
</body>
</html>
