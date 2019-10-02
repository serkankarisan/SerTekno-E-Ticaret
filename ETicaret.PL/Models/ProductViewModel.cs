using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaret.PL.Models
{
    public class ProductViewModel
    {
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
        public virtual string ModelName { get; set; }
        public virtual string SubCategoryName { get; set; }
        public virtual string ProductCoverImages { get; set; }
        public virtual int ProductCommentsCount { get; set; }
    }
}