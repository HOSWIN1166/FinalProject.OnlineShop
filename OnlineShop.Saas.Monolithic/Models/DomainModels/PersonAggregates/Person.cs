﻿namespace OnlineShop.Saas.Monolithic.Models.DomainModels.PersonAggregates
{
    public class Person
    {
        public Guid Id { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public bool IsDelete { get; set; }
    }
}
