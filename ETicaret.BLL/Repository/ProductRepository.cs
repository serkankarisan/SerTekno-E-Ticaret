using ETicaret.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BLL.Repository
{
    public class ProductRepository:BaseRepository<Product>
    {
        public Product SelectByProductCode(string ProductCode)
        {
            return _dbSet.Where(w => w.IsActive == true).FirstOrDefault(x => x.ProductCode.ToLower() == ProductCode.ToLower());
        }
        public List<Product> ListByModelID(int ModelID)
        {
            return _dbSet.Where(w => w.IsActive == true && w.ModelId == ModelID).ToList();
        }
    }
}
