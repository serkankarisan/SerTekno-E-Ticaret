using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaret.Entity.Entity
{
    [Table("ProductImage")]
    public class ProductImage : EntityBase
    {
        private string _imagePath;
        private string _imageType;

        public string ImagesPath { get => _imagePath; set => _imagePath = value; }
        [Required]
        [Column(Order = 3)]
        public string ImageType { get => _imageType; set => _imageType = value; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public ProductImage()
        {
            ImageType = "Cover";
        }
    }
}
