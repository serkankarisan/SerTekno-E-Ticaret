using ETicaret.Entity.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ETicaret.PL
{
    public partial class ProductManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                General.LastUrl = Request.Url.ToString();
                Response.Redirect("http://localhost:51010/Login.aspx");
            }
            else
            {

            }
            if (!Page.IsPostBack)
            {
                gvProduct.DataSource = General.ProductListToProductViewList(General.Service.Product.Select());
                gvProduct.DataBind();
                ddlBrand.DataSource = General.Service.Brand.Select();
                ddlBrand.DataValueField = "Id";
                ddlBrand.DataTextField = "BrandName";
                ddlBrand.DataBind();

                ddlModalModelBrand.DataSource = General.Service.Brand.Select();
                ddlModalModelBrand.DataValueField = "Id";
                ddlModalModelBrand.DataTextField = "BrandName";
                ddlModalModelBrand.DataBind();

                ddlModel.DataSource = General.Service.Model.ListByBrandId(Convert.ToInt32(ddlBrand.SelectedItem.Value));
                ddlModel.DataValueField = "Id";
                ddlModel.DataTextField = "ModelName";
                ddlModel.DataBind();

                ddlCategory.DataSource = General.Service.Category.Select();
                ddlCategory.DataValueField = "Id";
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataBind();

                ddlModalSubCategoryCategory.DataSource = General.Service.Category.Select();
                ddlModalSubCategoryCategory.DataValueField = "Id";
                ddlModalSubCategoryCategory.DataTextField = "CategoryName";
                ddlModalSubCategoryCategory.DataBind();

                ddlSubCategory.DataSource = General.Service.SubCategory.ListByCategoryId(Convert.ToInt32(ddlCategory.SelectedItem.Value));
                ddlSubCategory.DataValueField = "Id";
                ddlSubCategory.DataTextField = "SubCategoryName";
                ddlSubCategory.DataBind();
            }
            if (General.LastUrl == Request.Url.ToString())
            {
                pnlAlertDivAccordionEdit.CssClass = "alert alert-success alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                lblAlertDivAccordionEdit.Text = "<strong>Kayıt Başarılı</strong>. Ürün Başarıyla Kaydedildi.";
                pnlAlertDivAccordionEdit.Visible = true;
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (FileUploadCoverImage.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadCoverImage.FileName);
                    if (filename != "")
                    {
                        FileUploadCoverImage.SaveAs(Server.MapPath("~/Images/") + filename);
                        Product prd = new Product();
                        prd.CriticalStockCount = Convert.ToInt32(txtCriticalStockCount.Text.Trim());
                        prd.Decription = txtDescription.Text.Trim();
                        prd.ModelId = Convert.ToInt32(ddlModel.SelectedItem.Value);
                        prd.Origin = txtOrigin.Text.Trim();
                        prd.Price = Convert.ToDecimal(txtPrice.Text.Trim());
                        prd.ProductName = txtProductName.Text.Trim();
                        prd.Properties = txtProperties.Text.Trim();
                        prd.StockCount = Convert.ToInt32(txtStockCount.Text.Trim());
                        prd.SubCategoryId = Convert.ToInt32(ddlSubCategory.SelectedItem.Value);
                        prd.WarrantyYearCount = Convert.ToInt32(txtWarrantYearCount.Text.Trim());
                        if (General.Service.Product.Insert(prd) > 0)
                        {
                            ProductImage prImg = new ProductImage();
                            prImg.ImagesPath = "Images/" + filename;
                            prImg.ProductId = General.Service.Product.SelectByProductCode(prd.ProductCode).Id;
                            if (General.Service.ProductImage.Insert(prImg) > 0)
                            {
                                General.LastUrl = Request.Url.ToString();
                                Response.Redirect("http://localhost:51010/ProductManage.aspx");
                                AccordionProduct.SelectedIndex = 0;
                                pnlAlertDiv.CssClass = "alert alert-success alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                                lblAlertDiv.Text = "<strong>Kayıt Başarılı</strong>. Ürün Başarıyla Kaydedildi.";
                                pnlAlertDiv.Visible = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string hata = ex.Message;
                    AccordionProduct.SelectedIndex = 1;
                    pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                    lblAlertDiv.Text = "<strong>Kayıt Başarısız</strong>! " + hata + "!";
                    pnlAlertDiv.Visible = true;
                }
            }
        }

        protected void btnModalBrandSave_Click(object sender, EventArgs e)
        {
            Brand br = new Brand();
            br.BrandName = txtModalBrand.Text.Trim();
            if (!General.Service.Brand.ControlByBrandName(br.BrandName))
            {
                if (General.Service.Brand.Insert(br) > 0)
                {
                    ddlBrand.DataSource = General.Service.Brand.Select();
                    ddlBrand.DataValueField = "Id";
                    ddlBrand.DataTextField = "BrandName";
                    ddlBrand.DataBind();
                    ddlModalModelBrand.DataSource = General.Service.Brand.Select();
                    ddlModalModelBrand.DataValueField = "Id";
                    ddlModalModelBrand.DataTextField = "BrandName";
                    ddlModalModelBrand.DataBind();
                    ddlModel.DataSource = General.Service.Model.ListByBrandId(General.Service.Brand.SelectByBrandName(br.BrandName).Id);
                    ddlModel.DataValueField = "Id";
                    ddlModel.DataTextField = "ModelName";
                    ddlModel.DataBind();
                    AccordionProduct.SelectedIndex = 1;
                    ddlBrand.SelectedValue = ddlBrand.Items.FindByText(br.BrandName).Value;
                    pnlAlertDiv.CssClass = "alert alert-success alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                    lblAlertDiv.Text = "<strong>Kayıt Başarılı</strong>. Marka Başarıyla Kaydedildi.";
                    pnlAlertDiv.Visible = true;
                    txtModalBrand.Text = "";
                }
                else
                {
                    AccordionProduct.SelectedIndex = 1;
                    pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                    lblAlertDiv.Text = "<strong>Kayıt Başarısız</strong>! Yeniden işlem yapmayı deneyin!";
                    pnlAlertDiv.Visible = true;
                }
            }
            else
            {
                AccordionProduct.SelectedIndex = 1;
                pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                lblAlertDiv.Text = "<strong>Kayıt Başarısız</strong>! Bu Marka zaten kayıtlı!";
                pnlAlertDiv.Visible = true;
            }

        }

        protected void btnModalModelSave_Click(object sender, EventArgs e)
        {
            Model mdl = new Model();
            mdl.ModelName = txtModalModel.Text.Trim();
            mdl.BrandId = Convert.ToInt32(ddlModalModelBrand.SelectedItem.Value);
            if (!General.Service.Model.ControlByModelName(mdl.ModelName))
            {
                if (General.Service.Model.Insert(mdl) > 0)
                {
                    ddlBrand.DataSource = General.Service.Brand.Select();
                    ddlBrand.DataValueField = "Id";
                    ddlBrand.DataTextField = "BrandName";
                    ddlBrand.DataBind();

                    ddlModalModelBrand.DataSource = General.Service.Brand.Select();
                    ddlModalModelBrand.DataValueField = "Id";
                    ddlModalModelBrand.DataTextField = "BrandName";
                    ddlModalModelBrand.DataBind();

                    ddlModel.DataSource = General.Service.Model.ListByBrandId(mdl.BrandId);
                    ddlModel.DataValueField = "Id";
                    ddlModel.DataTextField = "ModelName";
                    ddlModel.DataBind();
                    AccordionProduct.SelectedIndex = 1;
                    ddlModel.SelectedValue = ddlModel.Items.FindByText(mdl.ModelName).Value;
                    ddlBrand.SelectedValue = ddlBrand.Items.FindByText(General.Service.Brand.SelectById(mdl.BrandId).BrandName).Value;
                    pnlAlertDiv.CssClass = "alert alert-success alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                    lblAlertDiv.Text = "<strong>Kayıt Başarılı</strong>. Model Başarıyla Kaydedildi.";
                    pnlAlertDiv.Visible = true;
                    txtModalModel.Text = "";
                }
                else
                {
                    AccordionProduct.SelectedIndex = 1;
                    pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                    lblAlertDiv.Text = "<strong>Kayıt Başarısız</strong>! Yeniden işlem yapmayı deneyin!";
                    pnlAlertDiv.Visible = true;
                }
            }
            else
            {
                AccordionProduct.SelectedIndex = 1;
                pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                lblAlertDiv.Text = "<strong>Kayıt Başarısız</strong>! Bu Model zaten kayıtlı!";
                pnlAlertDiv.Visible = true;
            }
        }

        protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlAlertDiv.Visible = false;
            ddlModel.DataSource = General.Service.Model.ListByBrandId(Convert.ToInt32(ddlBrand.SelectedItem.Value));
            ddlModel.DataValueField = "Id";
            ddlModel.DataTextField = "ModelName";
            ddlModel.DataBind();
        }

        protected void btnModalCategorySave_Click(object sender, EventArgs e)
        {
            Category c = new Category();
            c.CategoryName = txtModalCategory.Text.Trim();
            if (!General.Service.Category.ControlByCategoryName(c.CategoryName))
            {
                if (General.Service.Category.Insert(c) > 0)
                {
                    ddlCategory.DataSource = General.Service.Category.Select();
                    ddlCategory.DataValueField = "Id";
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataBind();

                    ddlModalSubCategoryCategory.DataSource = General.Service.Category.Select();
                    ddlModalSubCategoryCategory.DataValueField = "Id";
                    ddlModalSubCategoryCategory.DataTextField = "CategoryName";
                    ddlModalSubCategoryCategory.DataBind();

                    ddlSubCategory.DataSource = General.Service.SubCategory.ListByCategoryId(Convert.ToInt32(ddlCategory.SelectedItem.Value));
                    ddlSubCategory.DataValueField = "Id";
                    ddlSubCategory.DataTextField = "SubCategoryName";
                    ddlSubCategory.DataBind();
                    AccordionProduct.SelectedIndex = 1;
                    ddlCategory.SelectedValue = ddlCategory.Items.FindByText(c.CategoryName).Value;
                    pnlAlertDiv.CssClass = "alert alert-success alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                    lblAlertDiv.Text = "<strong>Kayıt Başarılı</strong>. Kategori Başarıyla Kaydedildi.";
                    pnlAlertDiv.Visible = true;
                    txtModalBrand.Text = "";
                }
                else
                {
                    AccordionProduct.SelectedIndex = 1;
                    pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                    lblAlertDiv.Text = "<strong>Kayıt Başarısız</strong>! Yeniden işlem yapmayı deneyin!";
                    pnlAlertDiv.Visible = true;
                }
            }
            else
            {
                AccordionProduct.SelectedIndex = 1;
                pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                lblAlertDiv.Text = "<strong>Kayıt Başarısız</strong>! Bu Kategori zaten kayıtlı!";
                pnlAlertDiv.Visible = true;
            }
        }

        protected void btnModalSubCategorySave_Click(object sender, EventArgs e)
        {
            SubCategory sc = new SubCategory();
            sc.SubCategoryName = txtModalSubCategory.Text.Trim();
            sc.CategoryId = Convert.ToInt32(ddlModalSubCategoryCategory.SelectedItem.Value);
            if (!General.Service.SubCategory.ControlBySubCategoryName(sc.SubCategoryName))
            {
                if (General.Service.SubCategory.Insert(sc) > 0)
                {
                    ddlCategory.DataSource = General.Service.Category.Select();
                    ddlCategory.DataValueField = "Id";
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataBind();

                    ddlModalSubCategoryCategory.DataSource = General.Service.Category.Select();
                    ddlModalSubCategoryCategory.DataValueField = "Id";
                    ddlModalSubCategoryCategory.DataTextField = "CategoryName";
                    ddlModalSubCategoryCategory.DataBind();

                    ddlSubCategory.DataSource = General.Service.SubCategory.ListByCategoryId(sc.CategoryId);
                    ddlSubCategory.DataValueField = "Id";
                    ddlSubCategory.DataTextField = "SubCategoryName";
                    ddlSubCategory.DataBind();
                    AccordionProduct.SelectedIndex = 1;
                    ddlSubCategory.SelectedValue = ddlSubCategory.Items.FindByText(sc.SubCategoryName).Value;
                    ddlCategory.SelectedValue = ddlCategory.Items.FindByText(General.Service.Category.SelectById(sc.CategoryId).CategoryName).Value;
                    pnlAlertDiv.CssClass = "alert alert-success alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                    lblAlertDiv.Text = "<strong>Kayıt Başarılı</strong>. Alt Kategori Başarıyla Kaydedildi.";
                    pnlAlertDiv.Visible = true;
                    txtModalModel.Text = "";
                }
                else
                {
                    AccordionProduct.SelectedIndex = 1;
                    pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                    lblAlertDiv.Text = "<strong>Kayıt Başarısız</strong>! Yeniden işlem yapmayı deneyin!";
                    pnlAlertDiv.Visible = true;
                }
            }
            else
            {
                AccordionProduct.SelectedIndex = 1;
                pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                lblAlertDiv.Text = "<strong>Kayıt Başarısız</strong>! Bu Alt Kategori zaten kayıtlı!";
                pnlAlertDiv.Visible = true;
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlAlertDiv.Visible = false;
            ddlSubCategory.DataSource = General.Service.SubCategory.ListByCategoryId(Convert.ToInt32(ddlCategory.SelectedItem.Value));
            ddlSubCategory.DataValueField = "Id";
            ddlSubCategory.DataTextField = "SubCategoryName";
            ddlSubCategory.DataBind();
        }

        protected void btnSelectedDelete_Click(object sender, EventArgs e)
        {
            bool selected = false;
            foreach (GridViewRow row in gvProduct.Rows)
            {
                CheckBox Secilimi = (CheckBox)row.FindControl("cbxSelectDelete");
                if (Secilimi.Checked)
                {
                    selected = true;
                    int ID = Convert.ToInt32(gvProduct.DataKeys[row.RowIndex].Value);
                    General.Service.Product.Delete(ID);
                }
            }
            if (selected)
            {
                pnlAlertDivAccordionEdit.CssClass = "alert alert-warning alert-dismissible text-center";
                lblAlertDivAccordionEdit.Text = "<strong>İşlem Başarılı</strong>. Ürün Başarıyla Silindi.";
            }
            else
            {
                pnlAlertDivAccordionEdit.CssClass = "alert alert-danger alert-dismissible text-center";
                lblAlertDivAccordionEdit.Text = "<strong>İşlem Başarısız!</strong> Önce Ürün Seçmelisiniz!";
            }
            pnlAlertDivAccordionEdit.Visible = true;
            gvProduct.DataSource = General.ProductListToProductViewList(General.Service.Product.Select());
            gvProduct.DataBind();
        }

        protected void gvProduct_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProduct.EditIndex = e.NewEditIndex;
            gvProduct.DataSource = General.ProductListToProductViewList(General.Service.Product.Select());
            gvProduct.DataBind();
        }

        protected void gvProduct_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProduct.EditIndex = -1;
            gvProduct.DataSource = General.ProductListToProductViewList(General.Service.Product.Select());
            gvProduct.DataBind();
        }

        protected void gvProduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gvProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(gvProduct.DataKeys[e.RowIndex].Value);
            General.Service.Product.Delete(ID);
            gvProduct.DataSource = General.ProductListToProductViewList(General.Service.Product.Select());
            gvProduct.DataBind();
        }
    }
}