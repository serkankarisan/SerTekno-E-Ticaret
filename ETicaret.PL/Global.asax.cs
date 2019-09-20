using ETicaret.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ETicaret.PL
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            using (ETicaretContext ent =new ETicaretContext())
            {
                ent.Database.CreateIfNotExists();
            }
        }
    }
}