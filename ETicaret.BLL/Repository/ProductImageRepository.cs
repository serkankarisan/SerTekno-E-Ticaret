using ETicaret.Entity.Entity;
using System.Collections.Generic;
using System.Linq;

namespace ETicaret.BLL.Repository
{
    public class ProductImageRepository : BaseRepository<ProductImage>
    {
        public List<ProductImage> ListByProductID(int ProductID)
        {
            return _dbSet.Where(w => w.IsActive == true && w.ProductId == ProductID).ToList();
        }
    }
}
