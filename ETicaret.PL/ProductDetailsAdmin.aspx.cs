using ETicaret.Entity.Entity;
using ETicaret.Entity.Identity;
using ETicaret.PL.Models;
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
        int CommentID = 0;
        BasketItem bskt = new BasketItem();
        int ProductID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductID = Convert.ToInt32(Request.QueryString["ProductId"]);
            if (ProductID != 0)
            {
                string del = (string)Session["commentdel"];
                CommentID = Convert.ToInt32(Request.QueryString["CommentID"]);
                Product prdct = General.Service.Product.SelectById(ProductID);
                if (CommentID != 0 && del == "true")
                {
                    CommentDelete(CommentID);
                    Session["commentdel"] = "false";
                    General.LastUrl = Request.Url.ToString();
                    Response.Redirect("http://localhost:51010/ProductDetailsAdmin.aspx?ProductId=" + ProductID);
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        string UserID = "";
                        if (User.Identity.IsAuthenticated)
                        {
                            bool Admin = false;
                            UserID = User.Identity.GetUserId();
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
                                General.LastUrl = Request.Url.ToString();
                                Response.Redirect("http://localhost:51010/ProductDetails.aspx?ProductId=" + ProductID);
                            }
                            ProductEvaluation pe = General.Service.ProductEvaluation.GetProductEvaluationByUser(UserID, ProductID);
                            if (pe == null)
                            {
                                lblbtndislike.Text = "Beğenme";
                                lblbtnLike.Text = "Beğen";
                            }
                            else
                            {
                                if (pe.Like)
                                {
                                    lblbtndislike.Text = "Beğenme";
                                    lblbtnLike.Text = "Vazgeç";
                                }
                                else if (pe.DisLike)
                                {
                                    lblbtndislike.Text = "Vazgeç";
                                    lblbtnLike.Text = "Beğen";
                                }
                                else
                                {
                                    lblbtndislike.Text = "Beğenme";
                                    lblbtnLike.Text = "Beğen";
                                }
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
                        string properties = "";
                        string propertiesDesc = "";
                        string[] propList = prdct.Properties.Split(',');
                        foreach (var Prop in propList)
                        {
                            string[] propdetail = Prop.Split(':');
                            properties += "<span>" + propdetail[0] + "</span><br/><hr class=\"mt-0 mb-0\"/>";
                            if (propdetail.Count() == 2)
                            {
                                propertiesDesc += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span>" + propdetail[1] + "</span><br/><hr class=\"mt-0 mb-0\"/>";
                            }
                            else
                            {
                                propertiesDesc += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Belirtilmedi <br/><hr class=\"mt-0 mb-0\"/>";
                            }
                        }
                        lblPropertiesDesc.Text = propertiesDesc;
                        lblProperties.Text = properties;
                        txtCount.Attributes.Add("Max", prdct.StockCount.ToString());
                        btnAddBasket.CommandArgument = prdct.Id.ToString();
                        btnAddBasket.CommandName = "AddBasket";
                        List<ProductComment> CommentList = General.Service.ProductComment.ListByProductId(ProductID);
                        if (CommentList.Count() == 0)
                        {
                            pnlComments.Visible = false;
                        }
                        else
                        {
                            pnlComments.Visible = true;
                            string CommentItem = "";
                            foreach (ProductComment comment in CommentList)
                            {
                                AppUser commUser = General.Service.UserManager.FindById(comment.UserId);
                                if (UserID != "")
                                {                                   
                                        CommentItem += "<span class=\"h6\">" + commUser.Name + " " + commUser.SurName + "</span>" +
                                            "<div class=\"row\" style=\"min-width: 200px;min-height: 100px;border: 2px dashed #6DB72C;\">" +
                                            "<div class=\"p-2 col-8 col-sm-8 col-md-8 col-lg-8 col-xl-9 wordwrap\">" +
                                            comment.Content +
                                            "</div>"
                                            + "<div class=\"col-4 col-sm-4 col-md-4 col-lg-4 col-xl-3 text-center pt-4\">" +
                                            "<a id=\"btnCommentDelete" + ProductID + "\" class=\"btn btn-danger btnCommentDelete\" data-commid=\"" + comment.Id + "\" data-productid=\"" + ProductID + "\"/>Yorumu Sil</a>" +
                                        "</div>" +
                                            "</div>";
                                    
                                }
                                else
                                {
                                    CommentItem += "<span class=\"h6\">" + commUser.Name + " " + commUser.SurName + "</span>" +
                                            "<div class=\"row\" style=\"min-width: 200px;min-height: 100px;border: 2px dashed #6DB72C;\">" +
                                            "<div class=\"p-2 col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 wordwrap\">" +
                                            comment.Content +
                                            "</div>" +
                                            "</div>";
                                }
                            }
                            lblCommentItem.Text = CommentItem;
                        }
                    }
                }
                List<ProductViewModel> ProductViewList = General.ProductListToProductViewList(General.Service.Product.Select().Where(p => p.Id != ProductID && p.SubCategoryId == prdct.SubCategoryId).ToList());
                lvProductSmall.DataSource = ProductViewList.OrderByDescending(p => (p.LikeCount- p.DislikeCount)).Take(6);
                lvProductSmall.DataBind();
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
            Response.Redirect("http://localhost:51010/ProductDetailsAdmin.aspx?ProductId=" + ProductID);
        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                ProductID = Convert.ToInt32(Request.QueryString["ProductId"]);
                string UserID = User.Identity.GetUserId();
                ProductEvaluation pe = General.Service.ProductEvaluation.GetProductEvaluationByUser(UserID, ProductID);
                if (pe == null)
                {
                    pe = new ProductEvaluation();
                    pe.UserId = UserID;
                    pe.ProductId = ProductID;
                    pe.Like = true;
                    pe.DisLike = false;
                    General.Service.ProductEvaluation.Insert(pe);
                }
                else
                {
                    if (pe.Like)
                    {
                        pe.Like = false;
                        pe.DisLike = false;
                    }
                    else
                    {
                        pe.Like = true;
                        pe.DisLike = false;
                    }
                    General.Service.ProductEvaluation.Update(pe);
                }
                General.LastUrl = Request.Url.ToString();
                Response.Redirect("http://localhost:51010/ProductDetailsAdmin.aspx?ProductId=" + ProductID);
            }
            else
            {
                pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                lblAlertDiv.Text = "<strong>Değerlendirme yapabilmek için giriş yapmalısınız.</strong>";
                pnlAlertDiv.Visible = true;
            }
        }

        protected void btndislike_Click(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                ProductID = Convert.ToInt32(Request.QueryString["ProductId"]);
                string UserID = User.Identity.GetUserId();
                ProductEvaluation pe = General.Service.ProductEvaluation.GetProductEvaluationByUser(UserID, ProductID);
                if (pe == null)
                {
                    pe = new ProductEvaluation();
                    pe.UserId = UserID;
                    pe.ProductId = ProductID;
                    pe.Like = false;
                    pe.DisLike = true;
                    General.Service.ProductEvaluation.Insert(pe);
                }
                else
                {
                    if (pe.DisLike)
                    {
                        pe.Like = false;
                        pe.DisLike = false;
                    }
                    else
                    {
                        pe.Like = false;
                        pe.DisLike = true;
                    }
                    General.Service.ProductEvaluation.Update(pe);
                }
                General.LastUrl = Request.Url.ToString();
                Response.Redirect("http://localhost:51010/ProductDetailsAdmin.aspx?ProductId=" + ProductID);
            }
            else
            {
                pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                lblAlertDiv.Text = "<strong>Değerlendirme yapabilmek için giriş yapmalısınız.</strong>";
                pnlAlertDiv.Visible = true;
            }
        }

        protected void btncomment_Click(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                ProductID = Convert.ToInt32(Request.QueryString["ProductId"]);
                string UserID = User.Identity.GetUserId();
                ProductComment pc = new ProductComment();
                pc.ProductId = ProductID;
                pc.UserId = UserID;
                pc.Content = txtModalComment.Text.Trim();
                General.Service.ProductComment.Insert(pc);
                General.LastUrl = Request.Url.ToString();
                Response.Redirect("http://localhost:51010/ProductDetailsAdmin.aspx?ProductId=" + ProductID);
            }
            else
            {
                pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                lblAlertDiv.Text = "<strong>Değerlendirme yapabilmek için giriş yapmalısınız.</strong>";
                pnlAlertDiv.Visible = true;
            }
        }
        private void CommentDelete(int CommID)
        {
            General.Service.ProductComment.Delete(CommID);
        }

    }
}