﻿namespace OnlineShop.Saas.Monolithic.Models.DomainModels.ProductAggregates
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }
        public bool IsDeleted { get; set; }
        public Category? Category { get; set; }
        //public List<OrderDetail>? OrderDetails { get; set; }
    }
}
