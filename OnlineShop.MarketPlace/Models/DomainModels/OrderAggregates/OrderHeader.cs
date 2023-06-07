using OnlineShop.Saas.Models.DomainModels.PersonAggregates;

namespace OnlineShop.MarketPlace.Models.DomainModels.OrderAggregate
{
    public class OrderHeader
    {
        public Guid Id { get; set; }
        public Guid SellerRef { get; set; }
        public Guid BuyerRef { get; set; }
        public Person? Seller { get; set; }
        public Person? Buyer { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
        public bool IsDelete { get; set; }
    }
}
