﻿using Microsoft.AspNet.Identity;
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
            if (User.Identity.IsAuthenticated)
            {
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
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                //StatusText.Text = "Geçersiz kullanıcı adı veya şifre.";
            }
        }

       
    }
}