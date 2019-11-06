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
                productView.Id = product.Id;
                productView.CriticalStockCount = product.CriticalStockCount;
                productView.Decription = product.Decription;
                productView.DislikeCount = General.Service.ProductEvaluation.ProductDisLikeCount(product.Id);
                productView.LikeCount = General.Service.ProductEvaluation.ProductLikeCount(product.Id);
                productView.ModelName = General.Service.Model.SelectById(product.ModelId).ModelName;
                productView.Origin = product.Origin;
                productView.Price = product.Price;
                productView.ProductCode = product.ProductCode;
                productView.ProductCommentsCount = General.Service.ProductComment.ListByProductId(product.Id).Count();
                productView.ProductCoverImages = General.Service.ProductImage.Select().Where(p => p.ImageType == "Cover" && p.ProductId==product.Id).Select(p => p.ImagesPath).FirstOrDefault();
                productView.ProductName = product.ProductName;
                productView.Properties = product.Properties;
                productView.StockCount = product.StockCount;
                productView.SubCategoryName =General.Service.SubCategory.SelectById(product.SubCategoryId).SubCategoryName;
                productView.WarrantyYearCount = product.WarrantyYearCount;
                productView.CategoryName = General.Service.Category.SelectById(General.Service.SubCategory.SelectById(product.SubCategoryId).CategoryId).CategoryName;
                productView.BrandName = General.Service.Brand.SelectById(General.Service.Model.SelectById(product.ModelId).BrandId).BrandName;
                ProductViewList.Add(productView);
            }
            return ProductViewList;
        }
        public static List<BrandViewModel> BrandListToBrandViewList(List<Brand> BrandList)
        {
            List<BrandViewModel> BrandViewList = new List<BrandViewModel>();
            foreach (Brand brand in BrandList)
            {
                BrandViewModel brandView = new BrandViewModel();
                brandView.BrandName = brand.BrandName;
                brandView.ModelCount = General.Service.Model.ListByBrandId(brand.Id).Count();
                BrandViewList.Add(brandView);
            }
            return BrandViewList;
        }
    }
}