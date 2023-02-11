namespace VictoryRestaurant.Foods.Tests.UnitTests.Queries.FoodTypes;

public sealed class GetAllFoodTypeListQueryTests
{
    [Fact]
    public async ValueTask Handle()
    {
        // Arrange
        await using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodTypeEntityRepository(context);

        var handler = new GetAllFoodTypeListQuery.Handler(repository);

        var generatedFoodType = FoodTypeEntityGenerator.Generate();

        await context.FoodTypes.AddAsync(entity: generatedFoodType);

        await context.SaveChangesAsync();

        var query = new GetAllFoodTypeListQuery();

        // Act
        var foodTypes = await handler.Handle(request: query, cancellationToken: default);

        // Assert
        foodTypes.Should().Contain(expected: generatedFoodType);
    }
}