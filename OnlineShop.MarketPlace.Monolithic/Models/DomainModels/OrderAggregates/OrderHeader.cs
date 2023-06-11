using OnlineShop.Saas.Monolithic.Models.DomainModels.PersonAggregates;

namespace OnlineShop.MarketPlace.Monolithic.Models.DomainModels.OrderAggregates
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
