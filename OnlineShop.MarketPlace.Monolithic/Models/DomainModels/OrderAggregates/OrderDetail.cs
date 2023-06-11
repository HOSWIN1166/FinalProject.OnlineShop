using OnlineShop.Saas.Monolithic.Models.DomainModels.ProductAggregates;

namespace OnlineShop.MarketPlace.Monolithic.Models.DomainModels.OrderAggregates
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
