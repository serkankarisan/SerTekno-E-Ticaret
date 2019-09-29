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
                    string UserID = User.Identity.GetUserId();
                    General.ActiveUser = General.Service.UserManager.Users.Where(u => u.Id == UserID).FirstOrDefault();
                    lblSuccesAlert.Text = "Giriş başarılı. Merhaba "+General.ActiveUser.Name+" "+General.ActiveUser.SurName;
                    SuccesAlertDiv.Visible = true;
                    SuccesAlertDiv.Visible = true;
                }
                else
                {
                    SuccesAlertDiv.Visible = false;
                }
            }
        }
    }
}