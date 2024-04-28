
using ECommerce.Repositories;
using ECommerce.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services) =>
        services.AddSingleton<IProductService, DefaultProductService>();

    public static void AddRepositories(this IServiceCollection services) => 
        services.AddSingleton<IProductRepository, DefaultProductRepository>();
}