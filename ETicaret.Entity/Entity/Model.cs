using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entity.Entity
{
    [Table("Model")]
    public class Model:EntityBase
    {
        private string _modelName;

        [MaxLength(100,ErrorMessage ="Model ismi 100 karakteri geçemez!")]
        [Required]
        [Column(Order=3)]
        public string ModelName { get => _modelName; set => _modelName = value; }

        [ForeignKey("BrandId")]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
