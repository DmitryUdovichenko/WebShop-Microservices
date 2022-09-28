using Ordering.Domain.Common;

namespace Ordering.Domain.Entities.Payment;

public partial class Payment : BaseEntity
{
    public string CardName { get; set; }
    public string CardNumber { get; set; }
    public string Expiration { get; set; }
    public string CVV { get; set; }
    public int PaymentMethod { get; set; }
}