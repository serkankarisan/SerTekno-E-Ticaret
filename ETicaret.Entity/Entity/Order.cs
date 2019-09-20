using ETicaret.Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entity.Entity
{
    [Table("Order")]
    public class Order:EntityBase
    {
        private int _totalProductCount;
        private decimal _totalPrice;
        private DateTime _deliveryDate;

        [Required]
        [Column(Order = 3)]
        public int TotalProductCount { get => _totalProductCount; set => _totalProductCount = value; }
        [Required]
        [Column(Order = 4)]
        public decimal TotalPrice { get => _totalPrice; set => _totalPrice = value; }
        [Required]
        [Column(Order = 5)]
        public DateTime DeliveryDate { get => _deliveryDate; set => _deliveryDate = value; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
