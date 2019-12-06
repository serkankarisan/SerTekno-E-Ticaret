using ETicaret.Entity.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ETicaret.Entity.Identity
{
    public class AppUser : IdentityUser
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
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = Methods.CapitalizeText(value);
            }
        }
        [MaxLength(100, ErrorMessage = "Soyisim 100 karakteri geçemez!")]
        [Required]
        public string SurName
        {
            get
            {
                return _surName;
            }
            set
            {
                _surName = Methods.CapitalizeText(value);
            }
        }
        public string ProfileImage { get => _profileImage; set => _profileImage = value; }
        [MaxLength(350, ErrorMessage = "Adres 350 karakteri geçemez!")]
        [Required]
        public string Adress
        {
            get
            {
                return _adress;
            }
            set
            {
                _adress = Methods.CapitalizeText(value);
            }
        }
        [Required]
        public int AdressZipCode { get => _adressZipCode; set => _adressZipCode = value; }
        [MaxLength(100, ErrorMessage = "İl 100 karakteri geçemez!")]
        [Required]
        public string Province
        {
            get
            {
                return _province;
            }
            set
            {
                _province = Methods.CapitalizeText(value);
            }
        }
        [MaxLength(100, ErrorMessage = "İlçe 100 karakteri geçemez!")]
        [Required]
        public string District
        {
            get
            {
                return _district;
            }
            set
            {
                _district = Methods.CapitalizeText(value);
            }
        }
        [MaxLength(50, ErrorMessage = "Cinsiyet 50 karakteri geçemez!")]
        [Required]
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = Methods.CapitalizeText(value);
            }
        }

        public virtual List<ProductComment> ProductComments { get; set; }
    }
}
