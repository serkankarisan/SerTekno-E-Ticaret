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
    public partial class UserManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
                        AccordionUser.SelectedIndex = 0;
                        gvUsers.DataSource = General.Service.UserManager.Users.ToList();
                        gvUsers.DataBind();
                    }
                    else
                    {
                        General.LastUrl = Request.Url.ToString();
                        Response.Redirect("http://localhost:51010/Default.aspx");
                    }
                }
                else
                {
                    General.LastUrl = Request.Url.ToString();
                    Response.Redirect("http://localhost:51010/Login.aspx");
                }
            }
        }
        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            AccordionUser.SelectedIndex = 1;
            Session["SelectedUserID"] = gvUsers.DataKeys[e.NewEditIndex].Value.ToString();
            gvUsers.EditIndex = -1;
            AppUser SelectedUser = General.Service.UserManager.FindById(Session["SelectedUserID"].ToString());
            txtAdress.Text = SelectedUser.Adress;
            txtDistrict.Text = SelectedUser.District;
            txtEmail.Text = SelectedUser.Email;
            txtName.Text = SelectedUser.Name;
            txtPhoneNumber.Text = SelectedUser.PhoneNumber;
            txtProvince.Text = SelectedUser.Province;
            txtSurName.Text = SelectedUser.SurName;
            txtZipCode.Text = SelectedUser.AdressZipCode.ToString();
            ddlGender.SelectedValue = ddlGender.Items.FindByText(SelectedUser.Gender).Value;
            UserManageProfileImg.ImageUrl = SelectedUser.ProfileImage;
            gvUsers.DataSource = General.Service.UserManager.Users.ToList();
            gvUsers.DataBind();
        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            pnlAlertDiv.Visible = false;
            gvUsers.EditIndex = -1;
            string ID = gvUsers.DataKeys[e.RowIndex].Value.ToString();
            AppUser selectedUser = General.Service.UserManager.FindById(ID);
            File.Delete(MapPath(selectedUser.ProfileImage));
            General.Service.UserManager.Delete(selectedUser);
            gvUsers.DataSource = General.Service.UserManager.Users.ToList();
            gvUsers.DataBind();
        }

        protected void btnModalDelete_Click(object sender, EventArgs e)
        {
            pnlAlertDiv.Visible = false;
            gvUsers.EditIndex = -1;
            bool selected = false;
            foreach (GridViewRow row in gvUsers.Rows)
            {
                CheckBox Secilimi = (CheckBox)row.FindControl("cbxSelectDelete");
                if (Secilimi.Checked)
                {
                    selected = true;
                    string ID = gvUsers.DataKeys[row.RowIndex].Value.ToString();
                    AppUser selectedUser = General.Service.UserManager.FindById(ID);
                    File.Delete(MapPath(selectedUser.ProfileImage));
                    General.Service.UserManager.Delete(selectedUser);
                }
            }
            if (selected)
            {
                pnlAlertDiv.CssClass = "alert alert-warning alert-dismissible text-center";
                lblAlertDiv.Text = "<strong>İşlem Başarılı</strong>. Kullanıcı Başarıyla Silindi.";
            }
            else
            {
                pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible text-center";
                lblAlertDiv.Text = "<strong>İşlem Başarısız!</strong> Önce Kullanıcı Seçmelisiniz!";
            }
            pnlAlertDiv.Visible = true;
            gvUsers.DataSource = General.Service.UserManager.Users.ToList();
            gvUsers.DataBind();
        }

        protected void btnUserUpdate_Click(object sender, EventArgs e)
        {
            AppUser SelectedUser = General.Service.UserManager.FindById(Session["SelectedUserID"].ToString());
            if (FileUploadProfileImage.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadProfileImage.FileName);
                    if (filename != "")
                    {
                        FileUploadProfileImage.SaveAs(Server.MapPath("~/Images/") + filename);
                        SelectedUser.ProfileImage="Images/" + filename;
                    }
                }
                catch (Exception ex)
                {
                    string hata = ex.Message;
                    AccordionUser.SelectedIndex = 0;
                    pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                    lblAlertDiv.Text = "<strong>Kayıt Başarısız</strong>! " + hata + "!";
                    pnlAlertDiv.Visible = true;
                }
            }
            SelectedUser.Adress = txtAdress.Text.Trim();
            SelectedUser.District = txtDistrict.Text.Trim();
            SelectedUser.Province = txtProvince.Text.Trim();
            SelectedUser.Email = txtEmail.Text.Trim();
            SelectedUser.Name = txtName.Text.Trim();
            SelectedUser.SurName = txtSurName.Text.Trim();
            SelectedUser.PhoneNumber = txtPhoneNumber.Text.Trim();
            SelectedUser.AdressZipCode = Convert.ToInt32(txtZipCode.Text.Trim());
            SelectedUser.Gender = ddlGender.SelectedItem.Text.Trim();
            IdentityResult ıdentityResult = General.Service.UserManager.Update(SelectedUser);
            if (ıdentityResult.Succeeded)
            {
                AccordionUser.SelectedIndex = 0;
                pnlAlertDiv.CssClass = "alert alert-success alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                lblAlertDiv.Text = "<strong>İşlem Başarılı</strong>. Kullanıcı Başarıyla Güncellendi.";
                pnlAlertDiv.Visible = true;
            }
            else
            {
                AccordionUser.SelectedIndex = 0;
                pnlAlertDiv.CssClass = "alert alert-danger alert-dismissible col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center";
                lblAlertDiv.Text = "<strong>Kayıt Başarısız</strong>! " + ıdentityResult.Errors.FirstOrDefault() + "!";
                pnlAlertDiv.Visible = true;
            }
            gvUsers.EditIndex = -1;
            gvUsers.DataSource = General.Service.UserManager.Users.ToList();
            gvUsers.DataBind();
        }

        protected void btnVazgec_Click(object sender, EventArgs e)
        {
            AccordionUser.SelectedIndex = 0;
            gvUsers.EditIndex = -1;
            gvUsers.DataSource = General.Service.UserManager.Users.ToList();
            gvUsers.DataBind();
        }
    }
}