namespace VictoryRestaurant.Foods.Infrastructure.Mapping;

public static class MappingDependencyInjectionConfiguration {
    public static IServiceCollection AddMapping(this IServiceCollection services)
    {
        services.AddMapster();

        return services;
    }
}