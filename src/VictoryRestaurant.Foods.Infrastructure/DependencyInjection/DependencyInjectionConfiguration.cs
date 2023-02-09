namespace VictoryRestaurant.Foods.Infrastructure.DependencyInjection;

public static class DependencyInjectionConfiguration
{
    public static void AddRepositories(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: nameof(services));

        services.AddScoped<IFoodEntityRepository, FoodEntityRepository>();
        services.AddScoped<IFoodTypeEntityRepository, FoodTypeEntityRepository>();
    }
}