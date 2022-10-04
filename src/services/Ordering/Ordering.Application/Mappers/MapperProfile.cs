using AutoMapper;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using Ordering.Application.Features.Orders.Commands.CreateAddress;
using Ordering.Application.Features.Orders.Commands.CreatePayment;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Queries.GetAddresesList;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;
using Ordering.Application.Features.Orders.Queries.GetPaymentsList;
using Ordering.Domain.Entities;
using Ordering.Domain.Entities.BillingAddress;
using Ordering.Domain.Entities.Payment;

namespace Ordering.Application.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
            CreateMap<PaymentAttributes, PaymentDto>().ReverseMap();
            CreateMap<PaymentAttributes, CreatePaymentCommand>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Address, CreateAddressCommand>().ReverseMap();
        }
    }
}
