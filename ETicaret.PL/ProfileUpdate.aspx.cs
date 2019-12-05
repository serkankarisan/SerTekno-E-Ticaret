using ETicaret.Entity.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;

namespace ETicaret.PL
{
    public partial class ProfileUpdate : System.Web.UI.Page
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
                if (General.LastUrl != "http://localhost:51010/UserProfile.aspx")
                {
                    General.LastUrl = Request.Url.ToString();
                    Response.Redirect("http://localhost:51010/UserProfile.aspx");
                }
                if (!Page.IsPostBack)
                {
                    string UserID = User.Identity.GetUserId();
                    AppUser user = General.Service.UserManager.FindById(UserID);
                    txtAdress.Text = user.Adress;
                    txtDistrict.Text = user.District;
                    txtEmail.Text = user.Email;
                    txtName.Text = user.Name;
                    txtPhoneNumber.Text = user.PhoneNumber;
                    txtProvince.Text = user.Province;
                    txtSurName.Text = user.SurName;
                    txtZipCode.Text = user.AdressZipCode.ToString();
                    ddlGender.Text = user.Gender;
                }
            }
        }

        protected void btnProfileUpdate_Click(object sender, EventArgs e)
        {
            string UserID = User.Identity.GetUserId();
            AppUser user = General.Service.UserManager.FindById(UserID);
            user.UserName = txtEmail.Text.Trim();
            if (General.Service.UserManager.Users.Where(u => u.UserName == user.UserName && u.Id != UserID).FirstOrDefault() == null)
            {
                try
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
                    IdentityResult result = General.Service.UserManager.Update(user);
                    if (result.Succeeded)
                    {
                        General.LastUrl = Request.Url.ToString();
                        Response.Redirect("~/UserProfile.aspx");
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
}