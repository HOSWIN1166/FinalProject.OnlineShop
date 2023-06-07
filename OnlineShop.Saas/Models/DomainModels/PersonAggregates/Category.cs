using OnlineShop.Saas.Models.DomainModels.ProductAggregates;

namespace OnlineShop.Saas.Models.DomainModels.PersonAggregates
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Person>? Products { get; set; }
        public bool IsDelete { get; set; }
    }
}
