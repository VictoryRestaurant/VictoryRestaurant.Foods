namespace VictoryRestaurant.Foods.Infrastructure.Validation;

public static class ValidationDependencyInjectionConfiguration
{
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();

        services.AddValidatorsFromAssemblyContaining<CreateFoodRequestValidator>();

        return services;
    }
}