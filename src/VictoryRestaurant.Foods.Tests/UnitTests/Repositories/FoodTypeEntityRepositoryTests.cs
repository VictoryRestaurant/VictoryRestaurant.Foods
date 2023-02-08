namespace VictoryRestaurant.Foods.Tests.UnitTests.Repositories;

public class FoodTypeEntityRepositoryTests
{
    [Fact]
    public async ValueTask CreateAsync()
    {
        // Arrange
        using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodTypeEntityRepository(context);

        var generatedFoodType = FoodTypeEntityGenerator.Generate();

        // Act
        var createdFoodType = await repository.CreateAsync(entity: generatedFoodType);

        // Assert
        createdFoodType.Should().NotBeNull();

        var foodTypeFromStorage = context.FoodTypes.SingleOrDefaultAsync(
            predicate: food => food.Id == createdFoodType!.Id);

        createdFoodType.Should().BeEquivalentTo(expectation: foodTypeFromStorage);
    }
}