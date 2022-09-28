// namespace Ordering.Domain.Entities;
//
// public partial class Order
// {
//     public Order(string userId, string userName, decimal totalPrice, int addressId, int paymentId)
//     {
//         UserId = userId;
//         UserName = userName;
//
//         this.Update(totalPrice, addressId, paymentId);
//     }
//
//     public void Update(decimal totalPrice, int addressId, int paymentId)
//     {
//         TotalPrice = totalPrice;
//         AddressId = addressId;
//         PaymentId = paymentId;
//     }
//
//     public void ChangeAddress(int addressId)
//     {
//         AddressId = addressId;
//     }
//
//     public void ChangePayment(int paymentId)
//     {
//         PaymentId = paymentId; 
//     }
// }