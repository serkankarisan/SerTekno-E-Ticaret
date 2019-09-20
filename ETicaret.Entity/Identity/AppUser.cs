using ETicaret.Entity.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entity.Identity
{
    public class AppUser:IdentityUser
    {
        private string _name;
        private string _surName;
        private string _profileImage;
        private string _adress;
        private int _adressZipCode;
        private string _province;
        private string _district;
        private string _gender;

        [MaxLength(100, ErrorMessage = "İsim 100 karakteri geçemez!")]
        [Required]
        public string Name { get => _name; set => _name = value; }
        [MaxLength(100, ErrorMessage = "Soyisim 100 karakteri geçemez!")]
        [Required]
        public string SurName { get => _surName; set => _surName = value; }
        public string ProfileImage { get => _profileImage; set => _profileImage = value; }
        [MaxLength(350, ErrorMessage = "Adres 350 karakteri geçemez!")]
        [Required]
        public string Adress { get => _adress; set => _adress = value; }
        [Required]
        public int AdressZipCode { get => _adressZipCode; set => _adressZipCode = value; }
        [MaxLength(100, ErrorMessage = "İl 100 karakteri geçemez!")]
        [Required]
        public string Province { get => _province; set => _province = value; }
        [MaxLength(100, ErrorMessage = "İlçe 100 karakteri geçemez!")]
        [Required]
        public string District { get => _district; set => _district = value; }
        [MaxLength(50, ErrorMessage = "Cinsiyet 50 karakteri geçemez!")]
        [Required]
        public string Gender { get => _gender; set => _gender = value; }

        public virtual List<ProductComment> ProductComments { get; set; }
    }
}
