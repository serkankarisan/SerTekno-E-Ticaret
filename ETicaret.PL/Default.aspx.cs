using ETicaret.Entity.Entity;
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
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    if (General.LastUrl == "http://localhost:51010/Login.aspx")
                    {
                        string UserID = User.Identity.GetUserId();
                        General.ActiveUser = General.Service.UserManager.Users.Where(u => u.Id == UserID).FirstOrDefault();
                        lblSuccesAlert.Text = "<strong>Giriş Başarılı</strong>. Merhaba <strong>" + General.ActiveUser.Name + " " + General.ActiveUser.SurName + "</strong>";
                        SuccesAlertDiv.Visible = true;
                    }
                }
                else
                {
                    SuccesAlertDiv.Visible = false;
                }
            }
            if (Request.QueryString["search"] != null)
            {
                List<ProductViewModel> ProductViewList = General.ProductListToProductViewList(General.Service.Product.ListBySearch(Request.QueryString["search"]));
                lvProduct.DataSource = ProductViewList;
                lvProduct.DataBind();
                lvProductSmall.DataSource = ProductViewList;
                lvProductSmall.DataBind();
            }
            else
            {
                List<ProductViewModel> ProductViewList = General.ProductListToProductViewList(General.Service.Product.Select());
                lvProduct.DataSource = ProductViewList;
                lvProduct.DataBind();
                lvProductSmall.DataSource = ProductViewList;
                lvProductSmall.DataBind();
            }
            if (General.Service.Brand.Select().Count() == 0)
            {
                Label lblNotBrand = new Label();
                lblNotBrand.Text = "Markalara ulaşılamadı!";
                lblNotBrand.CssClass = "text-beyaz h6 col-xl-12 wordwrap";
                pnlFilterCategory.Controls.Add(lblNotBrand);
                Label bs = new Label();
                bs.Text = "<br />";
                pnlFilterCategory.Controls.Add(bs);
            }
            else
            {
                foreach (Brand br in General.Service.Brand.Select())
                {
                    CheckBox cb = new CheckBox();
                    cb.Text = br.BrandName;
                    cb.ID = "BrandFilter_" + br.Id;
                    cb.Checked = false;
                    cb.CssClass = "text-beyaz h6 col-xl-12";
                    cb.Attributes.Add("data-brandid", br.Id.ToString());
                    pnlFilterBrands.Controls.Add(cb);
                    Label bosluk = new Label();
                    bosluk.Text = "<br />";
                    pnlFilterBrands.Controls.Add(bosluk);
                }
            }
            if (General.Service.Category.Select().Count() == 0)
            {
                Label lblNotCat = new Label();
                lblNotCat.Text = "Kategorilere ulaşılamadı!";
                lblNotCat.CssClass = "text-beyaz h6 col-xl-12 wordwrap";
                pnlFilterCategory.Controls.Add(lblNotCat);
                Label bs = new Label();
                bs.Text = "<br />";
                pnlFilterCategory.Controls.Add(bs);
            }
            else
            {
                foreach (Category c in General.Service.Category.Select())
                {
                    CheckBox cbc = new CheckBox();
                    cbc.Text = c.CategoryName;
                    cbc.ID = "CategoryFilter_" + c.Id;
                    cbc.Checked = false;
                    cbc.CssClass = "text-beyaz h6 col-xl-12";
                    cbc.InputAttributes.Add("class", "CategoryFilter");
                    cbc.Attributes.Add("data-catid", c.Id.ToString());
                    pnlFilterCategory.Controls.Add(cbc);
                    Label bosluk = new Label();
                    bosluk.Text = "<br />";
                    pnlFilterCategory.Controls.Add(bosluk);
                }
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            List<ProductViewModel> ProductViewList = FilterList();
            lvProduct.DataSource = ProductViewList;
            lvProduct.DataBind();
            lvProductSmall.DataSource = ProductViewList;
            lvProductSmall.DataBind();
            if (ProductViewList.Count==0)
            {
                pnlContent.Visible = false;
                pnlSmall.Visible = false;
                pnlEmtyList.Visible = true;
                pnlEmtyListSmall.Visible = true;
            }
            else
            {
                pnlContent.Visible = true;
                pnlSmall.Visible = true;
                pnlEmtyList.Visible = false;
                pnlEmtyListSmall.Visible = false;
            }
        }
       
        private List<ProductViewModel> FilterList()
        {
            List<Product> ProductFilterList = new List<Product>();
            bool CatFilterSelected = false;
            bool BrandFilterSelected = false;
            foreach (var cb in pnlFilterBrands.Controls)
            {
                if (cb is CheckBox)
                {
                    CheckBox c = (CheckBox)cb;
                    if (c.Checked == true)
                    {
                        BrandFilterSelected = true;
                        break;
                    }
                }
            }
            foreach (var cb in pnlFilterCategory.Controls)
            {
                if (cb is CheckBox)
                {
                    CheckBox c = (CheckBox)cb;
                    if (c.Checked == true)
                    {
                        CatFilterSelected = true;
                        break;
                    }
                }
            }            
            if (CatFilterSelected)
            {
                foreach (var cb in pnlFilterCategory.Controls)
                {
                    if (cb is CheckBox)
                    {
                        CheckBox c = (CheckBox)cb;
                        if (c.Checked == true)
                        {
                            string[] checkbox = c.ID.Trim().Split('_');
                            foreach (Product pr in General.Service.Product.ListByCategoryID(Convert.ToInt32(checkbox[1])))
                            {
                                if (!ProductFilterList.Contains(pr))
                                {
                                    ProductFilterList.Add(pr);
                                }
                            }
                        }
                    }
                }
            }
            if (BrandFilterSelected && !CatFilterSelected)
            {
                foreach (var cb in pnlFilterBrands.Controls)
                {
                    if (cb is CheckBox)
                    {
                        CheckBox c = (CheckBox)cb;
                        if (c.Checked == true)
                        {
                            string[] checkbox = c.ID.Trim().Split('_');
                            foreach (Product pr in General.Service.Product.ListByBrandID(Convert.ToInt32(checkbox[1])))
                            {
                                if (!ProductFilterList.Contains(pr))
                                {
                                    ProductFilterList.Add(pr);
                                }
                            }
                        }
                    }
                }
            }
            else if (BrandFilterSelected && CatFilterSelected)
            {
                List<Product> ProductNewFilterList = new List<Product>();
                foreach (var cb in pnlFilterBrands.Controls)
                {
                    if (cb is CheckBox)
                    {
                        CheckBox c = (CheckBox)cb;
                        if (c.Checked == true)
                        {
                            string[] checkbox = c.ID.Trim().Split('_');
                            foreach (Product pr in General.Service.Product.ListByBrandID(Convert.ToInt32(checkbox[1])))
                            {
                                if (ProductFilterList.Contains(pr))
                                {
                                    ProductNewFilterList.Add(pr);
                                }
                            }
                        }
                    }
                }
                ProductFilterList = ProductNewFilterList;
            }
            else if (!BrandFilterSelected && !CatFilterSelected)
            {
                ProductFilterList = General.Service.Product.Select();
            }
            return General.ProductListToProductViewList(ProductFilterList);
        }
    }
}