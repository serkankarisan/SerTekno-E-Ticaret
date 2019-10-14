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
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                bool Admin=false;
                string UserID = HttpContext.Current.User.Identity.GetUserId();
                General.ActiveUser = General.Service.UserManager.Users.Where(u => u.Id == UserID).FirstOrDefault();
                List<AppRole> AdminRoles = General.Service.RoleManager.Roles.Where(r => r.Name == "Admin").ToList();
                foreach (AppRole Role in AdminRoles)
                {
                    if (Role.Users.Where(ur => ur.UserId == UserID).FirstOrDefault() != null)
                    {
                        Admin = true;
                    }
                }
                if (!Admin)
                {
                    lnkbtnAdminUserManage.Visible = false;
                    lnkbtnAdminProductManage.Visible = false;
                }
                SiteMasterProfileImg.ImageUrl = General.ActiveUser.ProfileImage;
                lblUsername.Text = General.ActiveUser.Name;
                pnlKullanici.Visible = true;
                pnlGirisYap.Visible = false;
            }
            else
            {
                pnlKullanici.Visible = false;
                pnlGirisYap.Visible = true;
            }
        }
        protected void SignOut(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            General.LastUrl = Request.Url.ToString();
            Response.Redirect("~/Login.aspx");
        }
    }
}