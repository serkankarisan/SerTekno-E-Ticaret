using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaret.Entity.Entity
{
    [Table("Brand")]
    public class Brand : EntityBase
    {
        private string _brandName;

        [MaxLength(100, ErrorMessage = "Marka ismi 100 karakteri geçemez!")]
        [Required]
        [Column(Order = 3)]
        public string BrandName { get => _brandName; set => _brandName = value; }

        public virtual List<Model> Models { get; set; }
    }
}
