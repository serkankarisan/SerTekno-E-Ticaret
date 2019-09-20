using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entity.Identity
{
    public class AppRole:IdentityRole
    {
        private string _description;

        [MaxLength(200,ErrorMessage ="Açıklama 200 karakteri geçemez!")]
        public string Description { get => _description; set => _description = value; }
    }
}
