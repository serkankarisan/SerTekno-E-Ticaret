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
                        lblSuccesAlert.Text = "<strong>Giriş Başarılı</strong>. Merhaba <strong>" + General.ActiveUser.Name + " " + General.ActiveUser.SurName+"</strong>";
                        SuccesAlertDiv.Visible = true;
                    }
                }
                else
                {
                    SuccesAlertDiv.Visible = false;
                }
            }
        }
    }
}