using ETicaret.Entity.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ETicaret.PL
{
    public partial class Register1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {


            //AppUser user = new AppUser();
            //user.UserName = lblUsername.Text.Trim();
            //user.Adress = "a";
            //user.AdressZipCode = 1;
            //user.District = "a";
            //user.Email = "a@gmail.com";
            ////user.EmailConfirmed = true;
            //user.Gender = "e";
            //user.Name = "a";
            //user.SurName = "a";
            //user.PhoneNumber = "1112121212";
            ////user.PhoneNumberConfirmed = true;
            //user.Province = "a";
            //IdentityResult result = General.Service.UserManager.Create(user, lblPassword.Text.Trim());
            //if (result.Succeeded)
            //{
            //    StatusMessage.Text = string.Format("Kullanıcı {0} başarıyla oluşturuldu!", user.UserName);
            //}
            //else
            //{
            //    StatusMessage.Text = result.Errors.FirstOrDefault();
            //}
        }
    }
}