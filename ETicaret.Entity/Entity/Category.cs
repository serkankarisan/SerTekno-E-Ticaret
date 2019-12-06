using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaret.Entity.Entity
{
    [Table("Category")]
    public class Category : EntityBase
    {
        private string _categoryName;

        [MaxLength(150, ErrorMessage = "Kategori adı 150 karakteri geçemez!")]
        [Required]
        [Column(Order = 3)]
        public string CategoryName
        {
            get
            {
                return _categoryName;
            }
            set
            {
                _categoryName = Methods.CapitalizeText(value);
            }
        }

        public virtual List<SubCategory> SubCategories { get; set; }


    }
}
