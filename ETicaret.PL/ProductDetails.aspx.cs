using ETicaret.Entity.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ETicaret.PL
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        int ProductID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductID = Convert.ToInt32(Request.QueryString["ProductId"]);
            if (!Page.IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    bool Admin = false;
                    string UserID = User.Identity.GetUserId();
                    List<AppRole> AdminRoles = General.Service.RoleManager.Roles.Where(r => r.Name == "Admin").ToList();
                    foreach (AppRole Role in AdminRoles)
                    {
                        if (Role.Users.Where(ur => ur.UserId == UserID).FirstOrDefault() != null)
                        {
                            Admin = true;
                        }
                    }
                    if (Admin)
                    {
                        General.LastUrl = Request.Url.ToString();
                        Response.Redirect("http://localhost:51010/ProductDetailsAdmin.aspx?ProductId="+ProductID);
                    }
                    else
                    {

                    }
                }
            }
        }
    }
}