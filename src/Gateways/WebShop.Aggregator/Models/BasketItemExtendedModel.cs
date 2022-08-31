namespace WebShop.Aggregator.Models
{
    public class BasketItemExtendedModel
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Options { get; set; }
        public int Quantity { get; set; }

        //additional fields

        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
    }
}
