using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public static class ConfigureServices 
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
                options.UseSnakeCaseNamingConvention();
            });


            return services;
        }
    }
}
