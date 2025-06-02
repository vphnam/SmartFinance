using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SF.Domain.Customers.CustomerAggregate;
using SF.Infrastructure.Data.Repositories;

namespace SF.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(IServiceCollection services, IConfiguration configuration)
        {
            RegisterDbContext(services, configuration);

            RegisterRepository(services);
            return services;
        }

        private static void RegisterRepository(IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }

        private static void RegisterDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Data.DbContexts.CustomerOracleDbContext>(options =>
               options.UseOracle(
                    configuration.GetConnectionString("CustomerOracleDb"),
                    b => b.MigrationsAssembly(typeof(Data.DbContexts.CustomerOracleDbContext).Assembly.FullName)));
        }
    }
}
