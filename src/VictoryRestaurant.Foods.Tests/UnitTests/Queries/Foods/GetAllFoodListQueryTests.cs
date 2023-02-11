namespace VictoryRestaurant.Foods.Tests.UnitTests.Queries.Foods;

public sealed class GetAllFoodListQueryTests
{
    [Fact]
    public async ValueTask Handle()
    {
        // Arrange
        await using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodEntityRepository(context);

        var handler = new GetAllFoodListQuery.Handler(repository);

        var generatedFood = FoodEntityGenerator.Generate();

        await context.Foods.AddAsync(entity: generatedFood);

        await context.SaveChangesAsync();

        var query = new GetAllFoodListQuery();

        // Act
        var foods = await handler.Handle(request: query, cancellationToken: default);

        // Assert
        foods.Should().Contain(expected: generatedFood);
    }
}