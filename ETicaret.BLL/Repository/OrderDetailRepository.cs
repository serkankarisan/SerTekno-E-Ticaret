using ETicaret.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BLL.Repository
{
    public class OrderDetailRepository:BaseRepository<OrderDetail>
    {
        public List<OrderDetail> ListByOrderId(int OrderID)
        {
            return _dbSet.Where(w => w.IsActive == true && w.OrderId == OrderID).ToList();
        }
    }
}
