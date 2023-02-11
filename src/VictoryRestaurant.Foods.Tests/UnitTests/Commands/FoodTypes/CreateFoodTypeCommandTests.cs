namespace VictoryRestaurant.Foods.Tests.UnitTests.Commands.FoodTypes;

public sealed class CreateFoodTypeCommandTests
{
    [Fact]
    public async ValueTask Handle()
    {
        // Arrange
        await using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodTypeEntityRepository(context);

        var handler = new CreateFoodTypeCommand.Handler(repository);

        var generatedFoodType = FoodTypeEntityGenerator.Generate();

        var command = new CreateFoodTypeCommand(foodType: generatedFoodType);

        // Act
        await handler.Handle(request: command, cancellationToken: default);

        // Assert
        var foodTypeFromStorage = await context.Foods.SingleOrDefaultAsync(
            predicate: entity =>
                entity.Id == generatedFoodType.Id &&
                entity.Name == generatedFoodType.Name);

        foodTypeFromStorage.Should().BeEquivalentTo(expectation: generatedFoodType);
    }
}