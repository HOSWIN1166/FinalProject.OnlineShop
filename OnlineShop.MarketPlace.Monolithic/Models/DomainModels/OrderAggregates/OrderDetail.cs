using OnlineShop.Saas.Monolithic.Models.DomainModels.ProductAggregates;

namespace OnlineShop.MarketPlace.Monolithic.Models.DomainModels.OrderAggregates
{
    public class OrderDetail
    {
        public Guid Id { get; set; }
        public Guid? OrderHeaderId { get; set; }
        public Guid? ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get { return Quantity * UnitPrice; } }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }
        public bool IsDelete { get; set; }
        

        public OrderHeader? OrderHeader { get; set; }
        public Product? Product { get; set; }
     
    }
}
