using OnlineShop.Saas.Monolithic.Models.DomainModels.PersonAggregates;

namespace OnlineShop.MarketPlace.Monolithic.Models.DomainModels.OrderAggregates
{
    public class OrderHeader
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public DateTime? Date { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }
        public bool IsDeleted { get; set; }


        public Person? Person { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
