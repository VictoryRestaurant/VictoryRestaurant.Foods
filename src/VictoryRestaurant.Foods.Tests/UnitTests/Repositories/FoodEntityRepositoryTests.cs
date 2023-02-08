namespace VictoryRestaurant.Foods.Tests.UnitTests.Repositories;

public sealed class FoodEntityRepositoryTests
{
    [Fact]
    public async ValueTask CreateAsync()
    {
        // Arrange
        using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodEntityRepository(context);

        var generatedFood = FoodEntityGenerator.Generate();

        // Act
        var createdFood = await repository.CreateAsync(entity: generatedFood);

        // Assert
        createdFood.Should().NotBeNull();

        var foodFromStorage = context.Foods.SingleOrDefaultAsync(
            predicate: food => food.Id == createdFood!.Id);

        createdFood.Should().BeEquivalentTo(expectation: foodFromStorage);
    }
}