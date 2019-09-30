using ETicaret.BLL.Repository.Service;
using ETicaret.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaret.PL
{
    public class General
    {
        public static RepositoryService Service = new RepositoryService();
        public static AppUser ActiveUser;
        public static string LastUrl = "";
    }
}