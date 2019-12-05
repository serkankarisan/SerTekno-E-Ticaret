using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaret.Entity.Entity
{
    [Table("SubCategory")]
    public class SubCategory : EntityBase
    {
        private string _subCategoryName;

        [MaxLength(150, ErrorMessage = "Alt kategori adı 150 karakteri geçemez!")]
        [Required]
        [Column(Order = 3)]
        public string SubCategoryName { get => _subCategoryName; set => _subCategoryName = value; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
