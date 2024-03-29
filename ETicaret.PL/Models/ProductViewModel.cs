﻿namespace ETicaret.PL.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string Origin { get; set; }
        public string Decription { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public int WarrantyYearCount { get; set; }
        public int StockCount { get; set; }
        public int CriticalStockCount { get; set; }
        public decimal Price { get; set; }
        public string Properties { get; set; }
        public virtual string BrandName { get; set; }
        public virtual string ModelName { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual string SubCategoryName { get; set; }
        public virtual string ProductCoverImages { get; set; }
        public virtual int ProductCommentsCount { get; set; }

        public override string ToString()
        {
            return ProductName;
        }
    }
}