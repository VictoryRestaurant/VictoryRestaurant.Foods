namespace VictoryRestaurant.Foods.Infrastructure.DependencyInjection.MediatR;

public static class MediatRConfiguration
{
    public static void AddMediatRConfiguration(this IServiceCollection services)
    {
        services.AddMediatR(assemblies: Assembly.GetExecutingAssembly());

        services.AddFoodMediatRProfile();

        services.AddFoodTypeMediatRProfile();
    }
}