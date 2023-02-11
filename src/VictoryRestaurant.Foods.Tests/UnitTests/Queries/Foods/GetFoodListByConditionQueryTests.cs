namespace VictoryRestaurant.Foods.Tests.UnitTests.Queries.Foods;

public sealed class GetFoodListByConditionQueryTests
{
    [Fact]
    public async ValueTask Handle()
    {
        // Arrange
        await using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodEntityRepository(context);

        var handler = new GetFoodListByConditionQuery.Handler(repository);

        var generatedFood = FoodEntityGenerator.Generate();

        await context.Foods.AddAsync(entity: generatedFood);

        await context.SaveChangesAsync();

        Func<FoodEntity, bool> condition = food => food.Equals(obj: generatedFood);

        var query = new GetFoodListByConditionQuery(predicate: condition);

        // Act
        var foods = await handler.Handle(request: query, cancellationToken: default);

        // Assert
        foods.Should().Contain(expected: generatedFood);
    }
}