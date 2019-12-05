using ETicaret.Entity.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace ETicaret.PL
{
    public partial class Register1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                General.LastUrl = "http://localhost:51010/Register.aspx";
                Response.Redirect("Default.aspx");
            }
        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            if (CustomValidatorPassword.ErrorMessage == "")
            {

                AppUser user = new AppUser();
                user.UserName = txtEmail.Text.Trim();
                if (General.Service.UserManager.Users.Where(u => u.UserName == user.UserName).FirstOrDefault() == null)
                {
                    user.Adress = txtAdress.Text.Trim();
                    user.AdressZipCode = Convert.ToInt32(txtZipCode.Text.Trim());
                    user.Province = txtProvince.Text.Trim();
                    user.District = txtDistrict.Text.Trim();
                    user.Email = txtEmail.Text.Trim();
                    user.Gender = ddlGender.Text.Trim();
                    user.Name = txtName.Text.Trim();
                    user.SurName = txtSurName.Text.Trim();
                    user.PhoneNumber = txtPhoneNumber.Text.Trim();
                    user.ProfileImage = "Images/profile-icon-png-917.png";
                    //user.PhoneNumberConfirmed = true;
                    //user.EmailConfirmed = true;
                    try
                    {
                        IdentityResult result = General.Service.UserManager.Create(user, txtPassword.Text.Trim());
                        if (result.Succeeded)
                        {
                            if (General.Service.RoleManager.FindByName("User") != null)
                            {
                                AppRole Rol = General.Service.RoleManager.FindByName("User");
                                var currentUser = General.Service.UserManager.FindByName(user.UserName);
                                General.Service.UserManager.AddToRole(currentUser.Id, "User");
                            }
                            else
                            {
                                AppRole appRole = new AppRole();
                                appRole.Name = "User";
                                General.Service.RoleManager.Create(appRole);
                                var currentUser = General.Service.UserManager.FindByName(user.UserName);
                                General.Service.UserManager.AddToRole(currentUser.Id, "User");
                            }
                            General.LastUrl = "http://localhost:51010/Register.aspx";
                            Response.Redirect("~/Login.aspx?UserName=" + user.UserName);
                        }
                        else
                        {
                            string hata = result.Errors.FirstOrDefault();
                        }
                    }
                    catch (Exception ex)
                    {
                        string hata = ex.Message;
                        pnlDivAlert.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                        lblAlert.Text = "<strong>İşlem Başarısız</strong>! " + hata + "!";
                        pnlDivAlert.Visible = true;
                    }
                }
                else
                {
                    lblAlert.Text = "Kayıt <strong>Başarısız</strong>. Bu Email daha önce kullanılmış!";
                    pnlDivAlert.Visible = true;
                    txtEmail.Focus();
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
    }
}