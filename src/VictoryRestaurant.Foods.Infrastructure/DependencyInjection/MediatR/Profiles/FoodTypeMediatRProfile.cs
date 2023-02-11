namespace VictoryRestaurant.Foods.Infrastructure.DependencyInjection.MediatR.Profiles;

internal static class FoodTypeMediatRProfile
{
    public static void AddFoodTypeMediatRProfile(this IServiceCollection services)
    {
        // Commands
        services.AddScoped<IRequest<FoodTypeEntity?>, CreateFoodTypeCommand>();
        services.AddScoped<IRequestHandler<CreateFoodTypeCommand, FoodTypeEntity?>, CreateFoodTypeCommand.Handler>();

        services.AddScoped<IRequest<Unit>, DeleteFoodTypeCommand>();
        services.AddScoped<IRequestHandler<DeleteFoodTypeCommand, Unit>, DeleteFoodTypeCommand.Handler>();

        services.AddScoped<IRequest<FoodTypeEntity?>, UpdateFoodTypeCommand>();
        services.AddScoped<IRequestHandler<UpdateFoodTypeCommand, FoodTypeEntity?>, UpdateFoodTypeCommand.Handler>();

        // Queries
        services.AddScoped<IRequest<IEnumerable<FoodTypeEntity>>, GetAllFoodTypeListQuery>();
        services.AddScoped<IRequestHandler<GetAllFoodListQuery, IEnumerable<FoodEntity>>, GetAllFoodListQuery.Handler>();

        services.AddScoped<IRequest<FoodTypeEntity?>, GetFoodTypeByConditionQuery>();
        services.AddScoped<IRequestHandler<GetFoodTypeByConditionQuery, FoodTypeEntity?>, GetFoodTypeByConditionQuery.Handler>();

        services.AddScoped<IRequest<IEnumerable<FoodTypeEntity>>, GetFoodTypeListByConditionQuery>();
        services.AddScoped<IRequestHandler<GetFoodTypeListByConditionQuery, IEnumerable<FoodTypeEntity>>, GetFoodTypeListByConditionQuery.Handler>();
    }
}