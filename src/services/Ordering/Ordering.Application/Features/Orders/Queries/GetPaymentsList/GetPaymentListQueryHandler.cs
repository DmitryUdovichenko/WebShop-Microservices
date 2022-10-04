using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistence;

namespace Ordering.Application.Features.Orders.Queries.GetPaymentsList
{

    public class GetPaymentListQueryHandler : IRequestHandler<GetPaymentListQuery, List<PaymentDto>>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public GetPaymentListQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<List<PaymentDto>> Handle(GetPaymentListQuery request, CancellationToken cancellationToken)
        {
            var paymentList = await _paymentRepository.GetPaymentsByUserId(request.UserId);
            return _mapper.Map<List<PaymentDto>>(paymentList);
        }
    }
}