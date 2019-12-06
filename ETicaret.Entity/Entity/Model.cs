using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaret.Entity.Entity
{
    [Table("Model")]
    public class Model : EntityBase
    {
        private string _modelName;

        [MaxLength(100, ErrorMessage = "Model ismi 100 karakteri geçemez!")]
        [Required]
        [Column(Order = 3)]
        public string ModelName
        {
            get
            {
                return _modelName;
            }
            set
            {
                _modelName = Methods.CapitalizeText(value);
            }
        }
        public int BrandId { get; set; }


        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
