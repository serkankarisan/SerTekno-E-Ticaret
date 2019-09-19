using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entity.Entity
{
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

        public string ProductName { get => _productName; set => _productName = value; }
        public string ProductCode { get => _productCode; set => _productCode = value; }
        public string Origin { get => _origin; set => _origin = value; }
        public string Decription { get => _decription; set => _decription = value; }
        public int LikeCount { get => _likeCount; set => _likeCount = value; }
        public int DislikeCount { get => __dislikeCount; set => __dislikeCount = value; }
        public int WarrantyYearCount { get => _warrantyYearCount; set => _warrantyYearCount = value; }
        public int StockCount { get => _stockCount; set => _stockCount = value; }
        public int CriticalStockCount { get => _criticalStockCount; set => _criticalStockCount = value; }
        public decimal Price { get => _price; set => _price = value; }
        public string Properties { get => _properties; set => _properties = value; }
    }
}
