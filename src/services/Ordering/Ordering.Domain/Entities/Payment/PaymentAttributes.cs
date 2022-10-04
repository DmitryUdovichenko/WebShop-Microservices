using Ordering.Domain.Common;

namespace Ordering.Domain.Entities.Payment;

public class PaymentAttributes : BaseEntity
{
    public string UserId { get; private set; }
    public string CardName { get; private set; }
    public string CardNumber { get; private set; }
    public string Expiration { get; private set; }
    public string Cvv { get; private set; }
    
    public PaymentAttributes(string userId, string cardName, string cardNumber, string expiration, string cvv)
    {
        UserId = userId;
        CardName = cardName;

        Update(cardNumber, expiration, cvv);
    }

    public void Update(string cardNumber, string expiration, string cvv)
    {
        CardNumber = cardNumber;
        Expiration = expiration;
        Cvv = cvv;
    }
}