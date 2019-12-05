namespace ETicaret.PL.Models
{
    public class OrderDetailView
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public int DifferentProductCount { get; set; }
    }
}