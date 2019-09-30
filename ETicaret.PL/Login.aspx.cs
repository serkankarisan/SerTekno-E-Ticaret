using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ETicaret.PL
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["UserName"]!=null)
                {
                    lblRegSucces.Text= "Kayıt <strong>Başarılı</strong>.Giriş yaparak devam edebilirsin!";
                    pnlAlertSuccesRegister.Visible = true;
                    txtUsername.Text = Request.QueryString["UserName"];
                    txtPassword.Focus();
                }
            }
            if (User.Identity.IsAuthenticated)
            {
                General.LastUrl = "http://localhost:51010/Login.aspx";
                Response.Redirect("Default.aspx");
            }
        }
        protected void SignIn(object sender, EventArgs e)
        {
            var user = General.Service.UserManager.Find(txtUsername.Text.Trim(), txtPassword.Text.Trim());

            if (user != null)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = General.Service.UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                bool RememberMe = cbxRememberMe.Checked;
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = RememberMe }, userIdentity);
                General.LastUrl = "http://localhost:51010/Login.aspx";
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                lblAlert.Text = "Giriş <strong>Başarısız</strong>. Geçersiz kullanıcı adı veya şifre.";
                pnlDivAlert.Visible = true;
            }
        }

       
    }
}