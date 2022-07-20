using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;
using Discount.Grpc.Repositories;
using Grpc.Core;

namespace Discount.Grpc.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountRepository _repository;
        private readonly ILogger<DiscountService> _logger;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository repository, ILogger<DiscountService> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public override async Task<CouponModel> Get(GetRequest request, ServerCallContext context)
        {
            var coupon = await _repository.Get(request.ProductId);
            if(coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount {request.ProductId} not found"));
            }
            _logger.LogInformation("Discount is retrived");
            return _mapper.Map<CouponModel>(coupon);
        }

        public override async Task<CouponModel> Create(CreateRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request);
            await _repository.Create(coupon);
            _logger.LogInformation("Coupon has been created");
            return _mapper.Map<CouponModel>(coupon);
        }

        public override async Task<CouponModel> Update(UpdateRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request);
            await _repository.Update(coupon);
            _logger.LogInformation("Coupon has been updated");
            return _mapper.Map<CouponModel>(coupon);
        }

        public override async Task<DeleteResponse> Delete(DeleteRequest request, ServerCallContext context)
        {
            var deleted = await _repository.Delete(request.Id);
            var response = new DeleteResponse
            {
                Result = deleted
            };
            return response;
        }
    }
}
