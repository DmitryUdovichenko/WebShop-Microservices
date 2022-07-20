using Npgsql;

namespace Discount.Grpc.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase(this IHost host, int? retry = 0)
        {
            int retryAvailability = retry.Value;
            using var scope = host.Services.CreateScope();

            var sp = scope.ServiceProvider;
            var configuration = sp.GetRequiredService<IConfiguration>();            

            try
            {
                using var connection = new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

                connection.Open();

                using var command = connection.CreateCommand();

                command.CommandText = "DROP TABLE IF EXISTS Coupon";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE Coupon(Id SERIAL PRIMARY KEY, ProductId VARCHAR(24) NOT NULL, Description TEXT, Amount INT)";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Coupon(ProductId, Description, Amount) VALUES('123456789','Test Discount', 20)";
                command.ExecuteNonQuery();

            }
            catch (NpgsqlException ex)
            {
                if(retryAvailability <= 50)
                {
                    retryAvailability++;
                    System.Threading.Thread.Sleep(1000);
                    MigrateDatabase(host, retryAvailability);
                }
            }

            return host;
        }
    }
}
