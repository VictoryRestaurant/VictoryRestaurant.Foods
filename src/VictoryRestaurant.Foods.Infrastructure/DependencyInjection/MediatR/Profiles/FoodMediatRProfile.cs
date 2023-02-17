namespace VictoryRestaurant.Foods.Infrastructure.DependencyInjection.MediatR.Profiles;

internal static class FoodMediatRProfile
{
    /// <summary> Add <see cref="FoodEntity"/> commands and queries to IoC. </summary>
    /// <param name="services"> IoC. </param>
    public static void AddFoodMediatRProfile(this IServiceCollection services)
    {
        // Commands
        services.AddScoped<IRequest<FoodEntity?>, CreateFoodCommand>();
        services.AddScoped<IRequestHandler<CreateFoodCommand, FoodEntity?>, CreateFoodCommand.Handler>();

        services.AddScoped<IRequest<Unit>, DeleteFoodCommand>();
        services.AddScoped<IRequestHandler<DeleteFoodCommand, Unit>, DeleteFoodCommand.Handler>();

        services.AddScoped<IRequest<FoodEntity?>, UpdateFoodCommand>();
        services.AddScoped<IRequestHandler<UpdateFoodCommand, FoodEntity?>, UpdateFoodCommand.Handler>();

        // Queries
        services.AddScoped<IRequest<IEnumerable<FoodEntity>>, GetAllFoodListQuery>();
        services.AddScoped<IRequestHandler<GetAllFoodListQuery, IEnumerable<FoodEntity>>, GetAllFoodListQuery.Handler>();

        services.AddScoped<IRequest<FoodEntity?>, GetFoodByConditionQuery>();
        services.AddScoped<IRequestHandler<GetFoodByConditionQuery, FoodEntity?>, GetFoodByConditionQuery.Handler>();

        services.AddScoped<IRequest<IEnumerable<FoodEntity>>, GetFoodListByConditionQuery>();
        services.AddScoped<IRequestHandler<GetFoodListByConditionQuery, IEnumerable<FoodEntity>>, GetFoodListByConditionQuery.Handler>();
    }
}