using ETicaret.Entity.Entity;
using ETicaret.Entity.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ETicaret.PL
{
    public partial class UserProfile : System.Web.UI.Page
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
                string UserID = User.Identity.GetUserId();
                AppUser CurrentUser = General.Service.UserManager.FindById(UserID);
                ProfileImg.ImageUrl = CurrentUser.ProfileImage;
                lblNameSurname.Text = CurrentUser.Name + " " + CurrentUser.SurName;
                lblAdress.Text = CurrentUser.Adress;
                lblEmail.Text = CurrentUser.Email;
                lblPhone.Text = CurrentUser.PhoneNumber;
                lblProvince.Text = CurrentUser.Province;
                lblDistrict.Text = CurrentUser.District;
                List<Order> OrderList = General.Service.Order.ListByUserId(UserID);
                if (OrderList.Count!=0)
                {
                    pnlOrderContent.Visible = false;
                    pnlEmtyList.Visible = true;
                    lvOrders.DataSource = OrderList;
                    lvOrders.DataBind();
                }
                else
                {
                    pnlOrderContent.Visible = true;
                    pnlEmtyList.Visible = false;
                }
            }
        }
        protected void CustomValidatorPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string inputData = args.Value;
            args.IsValid = false;
            CustomValidatorPassword.ErrorMessage = "";
            if (inputData.Length < 6)
            {
                CustomValidatorPassword.ErrorMessage = "Şifre en az 6 karakterden oluşmalı!";
                return;
            }
            bool upperCase = false;
            foreach (char ch in inputData)
            {
                if (ch >= 'A' && ch <= 'Z')
                {
                    upperCase = true;
                    break;
                }
            }
            if (!upperCase)
            {
                CustomValidatorPassword.ErrorMessage = "Şifrenizde en az bir adet büyük harf olmalı!";
                return;
            }
            bool lowerCase = false;
            foreach (char ch in inputData)
            {
                if (ch >= 'a' && ch <= 'z')
                {
                    lowerCase = true;
                    break;
                }
            }
            if (!lowerCase)
            {
                CustomValidatorPassword.ErrorMessage = "Şifrenizde en az bir adet küçük harf olmalı!";
                return;
            }
            bool number = false;
            foreach (char ch in inputData)
            {
                if (ch >= '0' && ch <= '9')
                {
                    number = true;
                    break;
                }
            }
            if (!number)
            {
                CustomValidatorPassword.ErrorMessage = "Şifrenizde en az bir adet rakam olmalı!";
                return;
            }
            args.IsValid = true;
        }

        protected void btnModalPasswordSave_Click(object sender, EventArgs e)
        {
            if (CustomValidatorPassword.ErrorMessage == "")
            {
                string UserID = User.Identity.GetUserId();
                AppUser user = General.Service.UserManager.FindById(UserID);
                if (!General.Service.UserManager.CheckPassword(user, txtOldPassword.Text.Trim()))
                {
                    lblAlert.Text = "İşlem <strong>Başarısız</strong>. Mevcut şifren bu değil!";
                    pnlDivAlert.Visible = true;
                    txtOldPassword.Text = "";
                }
                else
                {
                    IdentityResult result = General.Service.UserManager.ChangePassword(UserID, txtOldPassword.Text.Trim(), txtPassword.Text.Trim());
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    authenticationManager.SignOut();
                    Session["basket"] = null;
                    Session["totalcount"] = null;
                    Session["totalamount"] = null;
                    General.LastUrl = Request.Url.ToString();
                    Response.Redirect("~/Login.aspx");
                    txtOldPassword.Text = "";
                    txtPassword.Text = "";
                    txtRePassword.Text = "";
                }
            }
        }

        protected void btnProfileUpdate_Click(object sender, EventArgs e)
        {
            General.LastUrl = Request.Url.ToString();
            Response.Redirect("~/ProfileUpdate.aspx");
        }

        protected void btnImageUpdate_Click(object sender, EventArgs e)
        {
            string UserID = User.Identity.GetUserId();
            AppUser SelectedUser = General.Service.UserManager.FindById(UserID);
            if (FileUploadProfileImage.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadProfileImage.FileName);
                    if (filename != "")
                    {
                        if (SelectedUser.ProfileImage != "Images/profile-icon-png-917.png")
                        {
                            File.Delete(MapPath(SelectedUser.ProfileImage));
                        }
                        FileUploadProfileImage.SaveAs(Server.MapPath("~/Images/") + filename);
                        SelectedUser.ProfileImage = "Images/" + filename;
                    }
                }
                catch (Exception ex)
                {
                    string hata = ex.Message;
                    pnlDivAlert.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                    lblAlert.Text = "<strong>İşlem Başarısız</strong>! " + hata + "!";
                    pnlDivAlert.Visible = true;
                }
                IdentityResult ıdentityResult = General.Service.UserManager.Update(SelectedUser);
                if (ıdentityResult.Succeeded)
                {
                    General.LastUrl = Request.Url.ToString();
                    Response.Redirect("~/UserProfile.aspx");
                }
                else
                {
                    pnlDivAlert.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                    lblAlert.Text = "<strong>Kayıt Başarısız</strong>! " + ıdentityResult.Errors.FirstOrDefault() + "!";
                    pnlDivAlert.Visible = true;
                }
            }
        }
    }
}