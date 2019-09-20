using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entity.Entity
{
    [Table("ProductImage")]
    public class ProductImage:EntityBase
    {
        private string _imagesPath;

        [Required]
        [Column(Order = 3)]
        public string ImagesPath { get => _imagesPath; set => _imagesPath = value; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
