namespace VictoryRestaurant.Foods.Infrastructure.DependencyInjection;

public static class DependencyInjectionConfiguration
{
    /// <summary> Add all repositories to IoC. </summary>
    /// <param name="services"> IoC. </param>
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IFoodEntityRepository, FoodEntityRepository>();

        services.AddScoped<IFoodTypeEntityRepository, FoodTypeEntityRepository>();
    }
}