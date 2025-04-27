using HelpApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using HelpApp.Domain.Interfaces;
using HelpApp.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;



namespace HelpApp.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}

