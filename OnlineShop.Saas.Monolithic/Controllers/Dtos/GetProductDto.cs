namespace OnlineShop.Saas.Monolithic.Controllers.Dtos
{
    public class GetProductDto
    {

        public Guid Id { get; set; }
        public int ProductCode { get; set; }
        public string? Title { get; set; }
        public int UnitPrice { get; set; }
    }
}
