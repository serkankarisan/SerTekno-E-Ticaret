using ETicaret.Entity.Entity;
using System.Collections.Generic;
using System.Linq;

namespace ETicaret.BLL.Repository
{
    public class ProductRepository : BaseRepository<Product>
    {
        public Product SelectByProductCode(string ProductCode)
        {
            return _dbSet.Where(w => w.IsActive == true).FirstOrDefault(x => x.ProductCode.ToLower() == ProductCode.ToLower());
        }
        public List<Product> ListByModelID(int ModelID)
        {
            return _dbSet.Where(w => w.IsActive == true && w.ModelId == ModelID).ToList();
        }
        public List<Product> ListByBrandID(int BrandID)
        {
            List<Product> resultList = new List<Product>();
            ModelRepository mr = new ModelRepository();
            foreach (Model m in mr.ListByBrandId(BrandID))
            {
                foreach (Product p in _dbSet.Where(w => w.IsActive == true && w.ModelId == m.Id).ToList())
                {
                    resultList.Add(p);
                }
            }
            return resultList;
        }
        public List<Product> ListByCategoryID(int CategoryID)
        {
            List<Product> resultList = new List<Product>();
            SubCategoryRepository scr = new SubCategoryRepository();
            foreach (SubCategory sc in scr.ListByCategoryId(CategoryID))
            {
                foreach (Product p in _dbSet.Where(w => w.IsActive == true && w.SubCategoryId == sc.Id).ToList())
                {
                    resultList.Add(p);
                }
            }
            return resultList;
        }
        public List<Product> ListBySearch(string Search)
        {
            List<Product> ProductList = new List<Product>();
            BrandRepository br = new BrandRepository();
            ModelRepository mr = new ModelRepository();
            CategoryRepository cr = new CategoryRepository();
            SubCategoryRepository scr = new SubCategoryRepository();
            foreach (var pr in _dbSet.Where(w => w.IsActive == true && (w.Decription.ToLower().Contains(Search.ToLower()) || w.ProductName.ToLower().Contains(Search.ToLower()))).ToList())
            {
                ProductList.Add(pr);
            }
            foreach (var bp in br.Select().Where(w => w.BrandName.ToLower().Contains(Search.ToLower())).ToList())
            {
                foreach (var mp in mr.ListByBrandId(bp.Id))
                {
                    foreach (var pr in _dbSet.Where(w => w.IsActive == true && w.ModelId == mp.Id).ToList())
                    {
                        if (!ProductList.Contains(pr))
                        {
                            ProductList.Add(pr);
                        }
                    }
                }
            }
            foreach (var mp in mr.Select().Where(w => w.ModelName.ToLower().Contains(Search.ToLower())).ToList())
            {
                foreach (var pr in _dbSet.Where(w => w.IsActive == true && w.ModelId == mp.Id).ToList())
                {
                    if (!ProductList.Contains(pr))
                    {
                        ProductList.Add(pr);
                    }
                }
            }
            foreach (var cp in cr.Select().Where(w => w.CategoryName.ToLower().Contains(Search.ToLower())).ToList())
            {
                foreach (var scp in scr.ListByCategoryId(cp.Id))
                {
                    foreach (var pr in _dbSet.Where(w => w.IsActive == true && w.SubCategoryId == scp.Id).ToList())
                    {
                        if (!ProductList.Contains(pr))
                        {
                            ProductList.Add(pr);
                        }
                    }
                }
            }
            foreach (var scp in scr.Select().Where(w => w.SubCategoryName.ToLower().Contains(Search.ToLower())).ToList())
            {
                foreach (var pr in _dbSet.Where(w => w.IsActive == true && w.SubCategoryId == scp.Id).ToList())
                {
                    if (!ProductList.Contains(pr))
                    {
                        ProductList.Add(pr);
                    }
                }
            }
            return ProductList;
        }
    }
}
