using ETicaret.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BLL.Repository
{
    public class OrderRepository:BaseRepository<Order>
    {
        public List<Order> ListByUserId(string UserID)
        {
            return _dbSet.Where(w => w.IsActive == true && w.UserId == UserID).ToList();
        }
        public Order SelectByOrderCode(string OrderCode)
        {
            return _dbSet.Where(w => w.IsActive == true).FirstOrDefault(x => x.OrderCode == OrderCode);
        }
    }
}
