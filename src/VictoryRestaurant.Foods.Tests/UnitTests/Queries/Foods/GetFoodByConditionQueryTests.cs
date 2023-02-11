namespace VictoryRestaurant.Foods.Tests.UnitTests.Queries.Foods;

public sealed class GetFoodByConditionQueryTests
{
    [Fact]
    public async ValueTask Handle()
    {
        // Arrange
        await using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodEntityRepository(context);

        var handler = new GetFoodByConditionQuery.Handler(repository);

        var generatedFood = FoodEntityGenerator.Generate();

        await context.Foods.AddAsync(entity: generatedFood);

        await context.SaveChangesAsync();

        Expression<Func<FoodEntity, bool>> condition =
            food => food.Equals(generatedFood);

        var query = new GetFoodByConditionQuery(predicate: condition);

        // Act
        var food = await handler.Handle(request: query, cancellationToken: default);

        // Assert
        food.Should().BeEquivalentTo(expectation: generatedFood);
    }
}