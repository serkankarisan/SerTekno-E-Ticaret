using ETicaret.Entity.Entity;
using ETicaret.Entity.Identity;
using ETicaret.PL.Models;
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
        BasketItem bskt = new BasketItem();
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductID = Convert.ToInt32(Request.QueryString["ProductId"]);
            if (ProductID != 0)
            {
                Product prdct = General.Service.Product.SelectById(ProductID);
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
                            Response.Redirect("http://localhost:51010/ProductDetailsAdmin.aspx?ProductId=" + ProductID);
                        }
                    }
                    string Li = "<ol id=\"indicatorPrdct\" class=\"" + "carousel-indicators\">" + "<li data-target=\"" + "#pnlcarouselProductIndicators\" " + "data-slide-to=\"" + "0\"" + " class=\"" + " active\"" + "></li>";
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
                            Div += "<div class=\"carousel-item active\"><img class=\"DetailImgHeight\" src=\"" + PImage.ImagesPath + "\" alt=\"" + PImage.ImageType + " Images\"></div>";
                        }
                        else
                        {
                            Div += "<div class=\"carousel-item\"><img class=\"DetailImgHeight\" src=\"" + PImage.ImagesPath + "\" alt=\"" + PImage.ImageType + " Images\"></div>";
                        }
                    }
                    lblCarouselInner.Text = Div;
                    int BrandID = General.Service.Model.SelectById(prdct.ModelId).BrandId;
                    Brand br = General.Service.Brand.SelectById(BrandID);
                    lblBrand.Text = br.BrandName;
                    lblProductName.Text = prdct.ProductName;
                    lblPrice.Text = prdct.Price.ToString("C");
                    txtCount.Attributes.Add("Max", prdct.StockCount.ToString());
                    btnAddBasket.CommandArgument = prdct.Id.ToString();
                    btnAddBasket.CommandName = "AddBasket";
                }
            }
            else
            {
                General.LastUrl = Request.Url.ToString();
                Response.Redirect("http://localhost:51010/Default.aspx");
            }
        }

        protected void btnAddBasket_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (Session["basket"] == null)
            {
                Session["basket"] = bskt.EmptyBasket();
            }
            List<BasketItem> MyBasket = (List<BasketItem>)Session["basket"];
            BasketItem newItem = new BasketItem();
            newItem.ProductId = Convert.ToInt32(btn.CommandArgument);
            newItem.ProductName = lblProductName.Text;
            newItem.Count = Convert.ToInt32(txtCount.Text);
            newItem.UnitPrice = Convert.ToDecimal(lblPrice.Text.Trim().Replace(Session["MoneyChar"].ToString(), "").Replace(".", ""));
            newItem.Amount = newItem.Count * newItem.UnitPrice;
            bool SepetCheck = false;
            foreach (BasketItem item in MyBasket)
            {
                if (item.ProductId == newItem.ProductId)
                {
                    SepetCheck = true;
                    item.Count += newItem.Count;
                    item.Amount += newItem.Amount;
                    break;
                }
            }
            if (SepetCheck == false)
            {
                MyBasket.Add(newItem);
            }
            Session["basket"] = MyBasket;
            Session["totalcount"] = bskt.TotalCount(MyBasket);
            Session["totalamount"] = bskt.TotalAnmount(MyBasket);
            General.LastUrl = Request.Url.ToString();
            Response.Redirect("http://localhost:51010/ProductDetails.aspx?ProductId=" + ProductID);
        }
    }
}