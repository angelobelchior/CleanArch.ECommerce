using ECommerce.Application.UseCases.Vitrine;
using ECommerce.Infrastructure.Repositories.Vitrine;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IVitrineReadOnlyRepository, VitrineReadOnlyRepository>();
        
        return services;
    }
}
