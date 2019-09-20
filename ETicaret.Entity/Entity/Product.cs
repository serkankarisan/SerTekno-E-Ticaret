using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entity.Entity
{
    [Table("Product")]
    public class Product:EntityBase
    {
        private string _productName;
        private string _productCode;
        private string _origin;
        private string _decription;
        private int _likeCount;
        private int __dislikeCount;
        private int _warrantyYearCount;
        private int _stockCount;
        private int _criticalStockCount;
        private decimal _price;
        private string _properties;

        [MaxLength(100, ErrorMessage = "Ürün ismi 100 karakteri geçemez!")]
        [Required]
        [Column(Order = 3)]
        public string ProductName { get => _productName; set => _productName = value; }
        [MaxLength(100, ErrorMessage = "Ürün kodu 100 karakteri geçemez!")]
        [Required]
        [Column(Order = 4)]
        public string ProductCode { get => _productCode; set => _productCode = value; }
        [MaxLength(100, ErrorMessage = "Karakter sayısını aştınız!")]
        [Column(Order = 5)]
        public string Origin { get => _origin; set => _origin = value; }
        [MaxLength(150, ErrorMessage = "Açıklama 150 karakteri geçemez!")]
        [Column(Order = 6)]
        public string Decription { get => _decription; set => _decription = value; }
        [Column(Order = 7)]
        public int LikeCount { get => _likeCount; set => _likeCount = value; }
        [Column(Order = 8)]
        public int DislikeCount { get => __dislikeCount; set => __dislikeCount = value; }
        [Column(Order = 9)]
        public int WarrantyYearCount { get => _warrantyYearCount; set => _warrantyYearCount = value; }
        [Required]
        [Column(Order = 10)]
        public int StockCount { get => _stockCount; set => _stockCount = value; }
        [Required]
        [Column(Order = 11)]
        public int CriticalStockCount { get => _criticalStockCount; set => _criticalStockCount = value; }
        [Required]
        [Column(Order = 12)]
        public decimal Price { get => _price; set => _price = value; }
        [Required]
        [Column(Order = 13)]
        public string Properties { get => _properties; set => _properties = value; }

        [ForeignKey("ModelId")]
        public int ModelId { get; set; }
        public virtual Model Model { get; set; }

        [ForeignKey("SubCategoryId")]
        public int SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }

        public virtual List<ProductImage> ProductImages { get; set; }
        public virtual List<ProductComment> ProductComments { get; set; }


    }
}
