using ETicaret.Entity.Entity;
using ETicaret.Entity.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

                        if (ddlBrand.SelectedItem == null)
                        {
                            ddlModel.DataSource = General.Service.Model.Select();
                        }
                        else
                        {
                            ddlModel.DataSource = General.Service.Model.ListByBrandId(Convert.ToInt32(ddlBrand.SelectedItem.Value));
                        }
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

                        if (ddlCategory.SelectedItem == null)
                        {
                            ddlSubCategory.DataSource = General.Service.SubCategory.Select();
                        }
                        else
                        {
                            ddlSubCategory.DataSource = General.Service.SubCategory.ListByCategoryId(Convert.ToInt32(ddlCategory.SelectedItem.Value));
                        }
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
                else
                {
                    General.LastUrl = Request.Url.ToString();
                    Response.Redirect("http://localhost:51010/Default.aspx");
                }
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            pnlAlertDivAccordionEdit.Visible = false;
            gvProduct.EditIndex = -1;
            if (FileUploadCoverImage.HasFile)
            {
                try
                {
                    string filename = DateTime.Now.ToString().Replace(" ", "").Replace(".", "").Replace(":", "") + DateTime.Now.Millisecond.ToString() + "_" + Path.GetFileName(FileUploadCoverImage.FileName);
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
            pnlAlertDivAccordionEdit.Visible = false;
            gvProduct.EditIndex = -1;
            Brand br = new Brand();
            br.BrandName = txtModalBrand.Text.Trim();
            if (!General.Service.Brand.ControlByBrandName(br.BrandName))
            {
                try
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
                        ddlModalModelBrand.SelectedValue = ddlModalModelBrand.Items.FindByText(br.BrandName).Value;
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
                catch (Exception ex)
                {
                    string hata = ex.Message;
                    pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                    lblAlertDiv.Text = "<strong>İşlem Başarısız</strong>! " + hata + "!";
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
            pnlAlertDivAccordionEdit.Visible = false;
            gvProduct.EditIndex = -1;
            Model mdl = new Model();
            mdl.ModelName = txtModalModel.Text.Trim();
            mdl.BrandId = Convert.ToInt32(ddlModalModelBrand.SelectedItem.Value);
            if (!General.Service.Model.ControlByModelName(mdl.ModelName))
            {
                try
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
                catch (Exception ex)
                {
                    string hata = ex.Message;
                    pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                    lblAlertDiv.Text = "<strong>İşlem Başarısız</strong>! " + hata + "!";
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
            pnlAlertDivAccordionEdit.Visible = false;
            gvProduct.EditIndex = -1;
            pnlAlertDiv.Visible = false;
            ddlModel.DataSource = General.Service.Model.ListByBrandId(Convert.ToInt32(ddlBrand.SelectedItem.Value));
            ddlModel.DataValueField = "Id";
            ddlModel.DataTextField = "ModelName";
            ddlModel.DataBind();
            ddlModalModelBrand.SelectedValue = ddlModalModelBrand.Items.FindByText(General.Service.Brand.SelectById(Convert.ToInt32(ddlBrand.SelectedItem.Value)).BrandName).Value;
        }

        protected void btnModalCategorySave_Click(object sender, EventArgs e)
        {
            pnlAlertDivAccordionEdit.Visible = false;
            gvProduct.EditIndex = -1;
            Category c = new Category();
            c.CategoryName = txtModalCategory.Text.Trim();
            if (!General.Service.Category.ControlByCategoryName(c.CategoryName))
            {
                try
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
                        ddlModalSubCategoryCategory.SelectedValue = ddlModalSubCategoryCategory.Items.FindByText(c.CategoryName).Value;
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
                catch (Exception ex)
                {
                    string hata = ex.Message;
                    pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                    lblAlertDiv.Text = "<strong>İşlem Başarısız</strong>! " + hata + "!";
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
            pnlAlertDivAccordionEdit.Visible = false;
            gvProduct.EditIndex = -1;
            SubCategory sc = new SubCategory();
            sc.SubCategoryName = txtModalSubCategory.Text.Trim();
            sc.CategoryId = Convert.ToInt32(ddlModalSubCategoryCategory.SelectedItem.Value);
            if (!General.Service.SubCategory.ControlBySubCategoryName(sc.SubCategoryName))
            {
                try
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
                catch (Exception ex)
                {
                    string hata = ex.Message;
                    pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                    lblAlertDiv.Text = "<strong>İşlem Başarısız</strong>! " + hata + "!";
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
            pnlAlertDivAccordionEdit.Visible = false;
            gvProduct.EditIndex = -1;
            pnlAlertDiv.Visible = false;
            ddlSubCategory.DataSource = General.Service.SubCategory.ListByCategoryId(Convert.ToInt32(ddlCategory.SelectedItem.Value));
            ddlSubCategory.DataValueField = "Id";
            ddlSubCategory.DataTextField = "SubCategoryName";
            ddlSubCategory.DataBind();
            ddlModalSubCategoryCategory.SelectedValue = ddlModalSubCategoryCategory.Items.FindByText(General.Service.Category.SelectById(Convert.ToInt32(ddlCategory.SelectedItem.Value)).CategoryName).Value;
        }

        protected void btnSelectedDelete_Click(object sender, EventArgs e)
        {
            pnlAlertDivAccordionEdit.Visible = false;
            gvProduct.EditIndex = -1;
            bool selected = false;
            foreach (GridViewRow row in gvProduct.Rows)
            {
                CheckBox Secilimi = (CheckBox)row.FindControl("cbxSelectDelete");
                if (Secilimi.Checked)
                {
                    try
                    {
                        selected = true;
                        int ID = Convert.ToInt32(gvProduct.DataKeys[row.RowIndex].Value);
                        foreach (ProductImage img in General.Service.ProductImage.ListByProductID(ID))
                        {
                            File.Delete(MapPath(img.ImagesPath));
                            General.Service.ProductImage.Delete(img.Id);
                        }
                        General.Service.Product.Delete(ID);
                    }
                    catch (Exception ex)
                    {
                        string hata = ex.Message;
                        pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                        lblAlertDiv.Text = "<strong>İşlem Başarısız</strong>! " + hata + "!";
                        pnlAlertDiv.Visible = true;
                    }
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
            pnlAlertDivAccordionEdit.Visible = false;
            gvProduct.EditIndex = e.NewEditIndex;
            gvProduct.DataSource = General.ProductListToProductViewList(General.Service.Product.Select());
            gvProduct.DataBind();
        }

        protected void gvProduct_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            pnlAlertDivAccordionEdit.Visible = false;
            gvProduct.EditIndex = -1;
            gvProduct.DataSource = General.ProductListToProductViewList(General.Service.Product.Select());
            gvProduct.DataBind();
        }

        protected void gvProduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            pnlAlertDivAccordionEdit.Visible = false;
            int ID = Convert.ToInt32(gvProduct.DataKeys[e.RowIndex].Value);
            TextBox ProductName = (TextBox)gvProduct.Rows[e.RowIndex].FindControl("txtProductNameEdit");
            TextBox Origin = (TextBox)gvProduct.Rows[e.RowIndex].FindControl("txtOriginEdit");
            TextBox WarrantyYearCount = (TextBox)gvProduct.Rows[e.RowIndex].FindControl("txtWarrantyYearCountEdit");
            TextBox StockCount = (TextBox)gvProduct.Rows[e.RowIndex].FindControl("txtStockCountEdit");
            TextBox CriticalStockCount = (TextBox)gvProduct.Rows[e.RowIndex].FindControl("txtCriticalStockCountEdit");
            TextBox Price = (TextBox)gvProduct.Rows[e.RowIndex].FindControl("txtPriceEdit");
            var UpdatePro = General.Service.Product.SelectById(ID);
            UpdatePro.ProductName = ProductName.Text.Trim();
            UpdatePro.Origin = Origin.Text.Trim();
            UpdatePro.WarrantyYearCount = Convert.ToInt32(WarrantyYearCount.Text.Trim());
            UpdatePro.StockCount = Convert.ToInt32(StockCount.Text.Trim());
            UpdatePro.CriticalStockCount = Convert.ToInt32(CriticalStockCount.Text.Trim());
            UpdatePro.Price = Convert.ToDecimal(Price.Text.Trim().Replace(".", ","));
            try
            {
                General.Service.Product.Update(UpdatePro);
                gvProduct.EditIndex = -1;
                pnlAlertDivAccordionEdit.CssClass = "alert alert-success alert-dismissible text-center";
                lblAlertDivAccordionEdit.Text = "<strong>İşlem Başarılı</strong>. Ürün Başarıyla Güncellendi.";
                pnlAlertDivAccordionEdit.Visible = true;
                gvProduct.DataSource = General.ProductListToProductViewList(General.Service.Product.Select());
                gvProduct.DataBind();
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
                pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                lblAlertDiv.Text = "<strong>İşlem Başarısız</strong>! " + hata + "!";
                pnlAlertDiv.Visible = true;
            }
        }

        protected void gvProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                pnlAlertDivAccordionEdit.Visible = false;
                gvProduct.EditIndex = -1;
                int ID = Convert.ToInt32(gvProduct.DataKeys[e.RowIndex].Value);
                foreach (ProductImage img in General.Service.ProductImage.ListByProductID(ID))
                {
                    File.Delete(MapPath(img.ImagesPath));
                    General.Service.ProductImage.Delete(img.Id);
                }
                General.Service.Product.Delete(ID);
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
                pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                lblAlertDiv.Text = "<strong>İşlem Başarısız</strong>! " + hata + "!";
                pnlAlertDiv.Visible = true;
            }
            pnlAlertDivAccordionEdit.CssClass = "alert alert-warning alert-dismissible text-center";
            lblAlertDivAccordionEdit.Text = "<strong>İşlem Başarılı</strong>. Ürün Başarıyla Silindi.";
            pnlAlertDivAccordionEdit.Visible = true;
            gvProduct.DataSource = General.ProductListToProductViewList(General.Service.Product.Select());
            gvProduct.DataBind();
        }

    }
}