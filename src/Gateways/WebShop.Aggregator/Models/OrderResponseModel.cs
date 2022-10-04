namespace WebShop.Aggregator.Models
{
    public class OrderResponseModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }

        public int AddressId { get; set; }
        public int Payment { get; set; }
    }
}
