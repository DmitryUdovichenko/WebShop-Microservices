﻿namespace Basket.API.Entities
{
    public class CartItem
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Options { get; set; }
        public int Quantity { get; set; }
    }
}
