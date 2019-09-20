using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entity.Entity
{
    [Table("OrderDetail")]
    public class OrderDetail:EntityBase
    {
        private int _count;
        private decimal _unitPrice;
        private decimal _amount;

        [Required]
        [Column(Order = 3)]
        public int Count { get => _count; set => _count = value; }
        [Required]
        [Column(Order = 4)]
        public decimal UnitPrice { get => _unitPrice; set => _unitPrice = value; }
        [Required]
        [Column(Order = 5)]
        public decimal Amount { get => _amount; set => _amount = value; }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
