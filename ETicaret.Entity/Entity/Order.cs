using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entity.Entity
{
    public class Order:EntityBase
    {
        private int _totalProductCount;
        private decimal _totalPrice;
        private DateTime _deliveryDate;

        public int TotalProductCount { get => _totalProductCount; set => _totalProductCount = value; }
        public decimal TotalPrice { get => _totalPrice; set => _totalPrice = value; }
        public DateTime DeliveryDate { get => _deliveryDate; set => _deliveryDate = value; }
    }
}
