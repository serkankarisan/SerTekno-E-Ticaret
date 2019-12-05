using ETicaret.Entity.Entity;
using System.Collections.Generic;
using System.Linq;

namespace ETicaret.BLL.Repository
{
    public class ProductCommentRepository : BaseRepository<ProductComment>
    {
        public List<ProductComment> ListByProductId(int ProductID)
        {
            return _dbSet.Where(w => w.IsActive == true && w.ProductId == ProductID).ToList();
        }
        public ProductComment GetProductCommentByUser(string UserID, int ProductID)
        {
            return _dbSet.Where(w => w.IsActive == true).FirstOrDefault(x => x.ProductId == ProductID && x.UserId == UserID);
        }
        public int ProductCommentCount(int ProductID)
        {
            return _dbSet.Where(w => w.IsActive == true && w.ProductId == ProductID).Count();
        }
    }
}
