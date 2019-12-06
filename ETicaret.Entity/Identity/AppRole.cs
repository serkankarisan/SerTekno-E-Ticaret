using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace ETicaret.Entity.Identity
{
    public class AppRole : IdentityRole
    {
        private string _description;

        [MaxLength(200, ErrorMessage = "Açıklama 200 karakteri geçemez!")]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = Methods.CapitalizeText(value);
            }
        }
    }
}
