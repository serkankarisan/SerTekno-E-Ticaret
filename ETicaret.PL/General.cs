using ETicaret.BLL.Repository.Service;
using ETicaret.Entity.Entity;
using ETicaret.Entity.Identity;
using ETicaret.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaret.PL
{
    public class General
    {
        public static RepositoryService Service = new RepositoryService();
        public static AppUser ActiveUser;
        public static string LastUrl = "";

        public static List<ProductViewModel> ProductListToProductViewList(List<Product> ProductList)
        {
            List<ProductViewModel> ProductViewList = new List<ProductViewModel>();
            foreach (Product product in ProductList)
            {
                ProductViewModel productView = new ProductViewModel();
                productView.CriticalStockCount = product.CriticalStockCount;
                productView.Decription = product.Decription;
                productView.DislikeCount = product.DislikeCount;
                productView.LikeCount = product.LikeCount;
                productView.ModelName = product.Model.ModelName;
                productView.Origin = product.Origin;
                productView.Price = product.Price;
                productView.ProductCode = product.ProductCode;
                productView.ProductCommentsCount = product.ProductComments.Count();
                productView.ProductCoverImages = product.ProductImages.Where(p => p.ImageType == "Cover").Select(p => p.ImagesPath).FirstOrDefault();
                productView.ProductName = product.ProductName;
                productView.Properties = product.Properties;
                productView.StockCount = product.StockCount;
                productView.SubCategoryName = product.SubCategory.SubCategoryName;
                productView.WarrantyYearCount = product.WarrantyYearCount;
                ProductViewList.Add(productView);
            }
            return ProductViewList;
        }
    }
}