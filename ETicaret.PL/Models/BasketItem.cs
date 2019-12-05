using System.Collections.Generic;

namespace ETicaret.PL.Models
{
    public class BasketItem
    {
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public string ProductCoverImages { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }

        public List<BasketItem> EmptyBasket()
        {
            return new List<BasketItem>();
        }
        public int TotalCount(List<BasketItem> basket)
        {
            int TopCount = 0;
            foreach (BasketItem product in basket)
            {
                TopCount += product.Count;
            }
            return TopCount;
        }
        public decimal TotalAnmount(List<BasketItem> basket)
        {
            decimal TopAmount = 0;
            foreach (BasketItem product in basket)
            {
                TopAmount += product.Amount;
            }
            return TopAmount;
        }
    }
}