using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartFinance.Infrastructure.DatabaseContext;

namespace SmartFinance.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterDbContext(services, configuration);

            return services;
        }
        private static void RegisterDbContext(IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<SFDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("CustomerDbConnection"), 
                b => b.MigrationsAssembly(typeof(SFDbContext).Assembly.FullName)));
        }
    }
}
