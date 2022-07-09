using Dapper;
using Discount.Grpc.Entities;
using Npgsql;

namespace Discount.Grpc.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> Create(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var isAdded = await connection.ExecuteAsync
                ("INSERT INTO Coupon (ProductId, Description, Amount) VALUES (@ProductId, @Description, @Amount)",
                new { ProductId = coupon.ProductId, Description = coupon.Description, Amount = coupon.Amount });

            if(isAdded == 0)
                return false;

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var isDeleted = await connection.ExecuteAsync("DELETE FROM Coupon WHERE Id = @Id",new { Id = id });

            if (isDeleted == 0)
                return false;

            return true;
        }

        public async Task<Coupon> Get(string productId)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Coupon WHERE ProductId = @ProductId", new { ProductId = productId });

            if(coupon == null)
                return new Coupon { ProductId = productId, Description = "Nosuch coupon", Amount = 0 };

            return coupon;
        }

        public async Task<bool> Update(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var isUpdated = await connection.ExecuteAsync
                ("UPDATE Coupon SET ProductId = @ProductId, Description = @Description, Amount = @Amount WHERE Id = @Id",
                new {Id = coupon.Id, ProductId = coupon.ProductId, Description = coupon.Description, Amount = coupon.Amount });

            if (isUpdated == 0)
                return false;

            return true;
        }
    }
}
