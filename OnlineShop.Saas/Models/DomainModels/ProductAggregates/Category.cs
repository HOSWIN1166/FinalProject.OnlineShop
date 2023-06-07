namespace OnlineShop.Saas.Models.DomainModels.ProductAggregates
{
    public class Category
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public List<Product>? Products { get; set; }
        public bool IsDelete { get; set; }
    }
}
