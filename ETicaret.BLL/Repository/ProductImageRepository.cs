using ETicaret.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BLL.Repository
{
    public class ProductImageRepository:BaseRepository<ProductImage>
    {
        public List<ProductImage> ListByProductID(int ProductID)
        {
            return _dbSet.Where(w => w.IsActive == true && w.ProductId == ProductID).ToList();
        }
    }
}
