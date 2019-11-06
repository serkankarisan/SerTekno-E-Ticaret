using ETicaret.DAL.Context;
using ETicaret.Entity.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ETicaret.PL
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            using (ETicaretContext ent = new ETicaretContext())
            {
                ent.Database.CreateIfNotExists();
                if (General.Service.UserManager.FindByName("serkankarisan1905@gmail.com") == null)
                {
                    AppUser AppUserAdmin = new AppUser() { Name = "Serkan", SurName = "Karışan", Email = "serkankarisan1905@gmail.com", UserName = "serkankarisan1905@gmail.com", EmailConfirmed = true, SecurityStamp = "d6b253a0-6325-410b-bed4-796ba916e443", PhoneNumber = "5355063330", PhoneNumberConfirmed = true, TwoFactorEnabled = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, Adress = "Sancaktepe/Istanbul", AdressZipCode = 34795, Province = "Istanbul", District = "Sancaktepe", Gender = "Erkek", ProfileImage = "Images/profile-icon-png-917.png" };
                    IdentityResult result = General.Service.UserManager.Create(AppUserAdmin, "123Qw.");
                    if (result.Succeeded)
                    {
                        if (General.Service.RoleManager.FindByName("Admin") != null)
                        {
                            AppRole Rol = General.Service.RoleManager.FindByName("Admin");
                            var currentUser = General.Service.UserManager.FindByName(AppUserAdmin.UserName);
                            General.Service.UserManager.AddToRole(currentUser.Id, "Admin");
                        }
                        else
                        {
                            AppRole appRole = new AppRole();
                            appRole.Name = "Admin";
                            General.Service.RoleManager.Create(appRole);
                            var currentUser = General.Service.UserManager.FindByName(AppUserAdmin.UserName);
                            General.Service.UserManager.AddToRole(currentUser.Id, "Admin");
                        }
                        if (General.Service.RoleManager.FindByName("User") == null)
                        {
                            AppRole appRole = new AppRole();
                            appRole.Name = "User";
                            General.Service.RoleManager.Create(appRole);
                        }
                    }
                }
            }
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            decimal m = 1;
            Session["MoneyChar"] = m.ToString("C").Replace("1", "").Replace("0", "").Replace(",", "").Replace(".", "");
            Session["commentdel"] = "false";
        }
        protected void Session_End(object sender, EventArgs e)
        {
            Session["MoneyChar"] = "";
            Session["commentdel"] = "false";
        }
    }
}