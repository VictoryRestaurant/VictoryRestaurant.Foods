namespace VictoryRestaurant.Foods.Tests.UnitTests.Queries.FoodTypes;

public sealed class GetFoodTypeByConditionQueryTests
{
    [Fact]
    public async ValueTask Handle()
    {
        // Arrange
        await using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodTypeEntityRepository(context);

        var handler = new GetFoodTypeByConditionQuery.Handler(repository);

        var generatedFoodType = FoodTypeEntityGenerator.Generate();

        await context.FoodTypes.AddAsync(entity: generatedFoodType);

        await context.SaveChangesAsync();

        Expression<Func<FoodTypeEntity, bool>> condition =
            foodType => foodType.Equals(generatedFoodType);

        var query = new GetFoodTypeByConditionQuery(predicate: condition);

        // Act
        var foodType = await handler.Handle(request: query, cancellationToken: default);

        // Assert
        foodType.Should().BeEquivalentTo(expectation: generatedFoodType);
    }
}