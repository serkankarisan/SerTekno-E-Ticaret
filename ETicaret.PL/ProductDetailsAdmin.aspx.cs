using ETicaret.Entity.Entity;
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
    public partial class ProductDetailsAdmin : System.Web.UI.Page
    {
        int ProductID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductID = Convert.ToInt32(Request.QueryString["ProductId"]);
            if (ProductID != 0)
            {
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
                            string Li = "<ol class=\"" + "carousel-indicators\">" + "<li data-target=\"" + "#pnlcarouselProductIndicators\" " + "data-slide-to=\"" + "0\"" + " class=\"" + "active\"" + "></li>";
                            for (int i = 1; i < General.Service.ProductImage.ListByProductID(ProductID).Count - 1; i++)
                            {
                                Li += "<li data-target=\"" + "#pnlcarouselProductIndicators\" " + "data-slide-to=\"" + i + "\"" + "></li>";
                            }
                            lblCarouselIndicators.Text = Li + "</ol>";
                            string Div = "";
                            foreach (ProductImage PImage in General.Service.ProductImage.ListByProductID(ProductID))
                            {
                                if (PImage.ImageType == "Cover")
                                {
                                    Div += "<div class=\"carousel-item active\"><img class=\"d-block w-100 container\" src=\"" + PImage.ImagesPath + "\" alt=\"" + PImage.ImageType + " Images\"></div>";
                                }
                                Div += "<div class=\"carousel-item\"><img class=\"d-block w-100 container\" src=\"" + PImage.ImagesPath + "\" alt=\"" + PImage.ImageType + " Images\"></div>";
                            }
                            lblCarouselInner.Text = Div;
                        }
                        else
                        {
                            General.LastUrl = Request.Url.ToString();
                            Response.Redirect("http://localhost:51010/ProductDetails.aspx?ProductId=" + ProductID);
                        }
                    }
                    else
                    {
                        General.LastUrl = Request.Url.ToString();
                        Response.Redirect("http://localhost:51010/ProductDetails.aspx?ProductId=" + ProductID);
                    }
                }
            }
            else
            {
                General.LastUrl = Request.Url.ToString();
                Response.Redirect("http://localhost:51010/Default.aspx");
            }
        }
    }
}