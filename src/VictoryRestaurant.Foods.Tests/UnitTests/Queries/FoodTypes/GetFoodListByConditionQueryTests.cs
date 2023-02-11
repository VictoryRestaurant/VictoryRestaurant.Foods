namespace VictoryRestaurant.Foods.Tests.UnitTests.Queries.FoodTypes;

public sealed class GetFoodListByConditionQueryTests
{
    [Fact]
    public async ValueTask Handle()
    {
        // Arrange
        await using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodTypeEntityRepository(context);

        var handler = new GetFoodTypeListByConditionQuery.Handler(repository);

        var generatedFoodType = FoodTypeEntityGenerator.Generate();

        await context.FoodTypes.AddAsync(entity: generatedFoodType);

        await context.SaveChangesAsync();

        Func<FoodTypeEntity, bool> condition = foodType => foodType.Equals(obj: generatedFoodType);

        var query = new GetFoodTypeListByConditionQuery(predicate: condition);

        // Act
        var foodTypes = await handler.Handle(request: query, cancellationToken: default);

        // Assert
        foodTypes.Should().Contain(expected: generatedFoodType);
    }
}