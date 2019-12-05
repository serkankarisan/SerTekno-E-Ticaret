using ETicaret.Entity.Entity;
using System.Linq;

namespace ETicaret.BLL.Repository
{
    public class ProductEvaluationRepository : BaseRepository<ProductEvaluation>
    {
        public ProductEvaluation GetProductEvaluationByUser(string UserID, int ProductID)
        {
            return _dbSet.Where(w => w.IsActive == true).FirstOrDefault(x => x.ProductId == ProductID && x.UserId == UserID);
        }
        public int ProductLikeCount(int ProductID)
        {
            return _dbSet.Where(w => w.IsActive == true && w.ProductId == ProductID && w.Like == true).Count();
        }
        public int ProductDisLikeCount(int ProductID)
        {
            return _dbSet.Where(w => w.IsActive == true && w.ProductId == ProductID && w.DisLike == true).Count();
        }
    }
}
