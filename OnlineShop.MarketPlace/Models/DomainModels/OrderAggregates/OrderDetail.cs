using OnlineShop.Saas.Models.DomainModels.ProductAggregates;

namespace OnlineShop.MarketPlace.Models.DomainModels.OrderAggregate
{
    public class OrderDetail
    {
        public Guid? OrderHeaderId { get; set; }
        public Guid? ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public OrderHeader? OrderHeader { get; set; }
        public Product? Product { get; set; }
        public bool IsDelete { get; set; }
    }
}
