using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entity.Entity
{
    public class OrderDetail:EntityBase
    {
        private int _count;
        private decimal _unitPrice;
        private decimal _amount;

        public int Count { get => _count; set => _count = value; }
        public decimal UnitPrice { get => _unitPrice; set => _unitPrice = value; }
        public decimal Amount { get => _amount; set => _amount = value; }
    }
}
