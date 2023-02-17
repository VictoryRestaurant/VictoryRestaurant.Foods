namespace VictoryRestaurant.Foods.Infrastructure.DependencyInjection.MediatR;

public static class MediatRConfiguration
{
    /// <summary> Add MediatR, all commands and queries to IoC. </summary>
    /// <param name="services"> IoC. </param>
    public static void AddMediatRConfiguration(this IServiceCollection services)
    {
        services.AddMediatR(assemblies: Assembly.GetExecutingAssembly());

        services.AddFoodMediatRProfile();

        services.AddFoodTypeMediatRProfile();
    }
}