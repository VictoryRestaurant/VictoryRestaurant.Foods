namespace VictoryRestaurant.Foods.Tests.UnitTests.Commands.FoodTypes;

public sealed class UpdateFoodTypeCommandTests
{
    [Fact]
    public async ValueTask Handle()
    {
        // Arrange
        await using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodTypeEntityRepository(context);

        var handler = new UpdateFoodTypeCommand.Handler(repository);

        var generatedFoodType = FoodTypeEntityGenerator.Generate();

        await context.FoodTypes.AddAsync(entity: generatedFoodType);

        await context.SaveChangesAsync();

        context.Entry(entity: generatedFoodType).State = EntityState.Detached;

        generatedFoodType.Name = "Updated!";

        var command = new UpdateFoodTypeCommand(foodType: generatedFoodType);

        // Act
        await handler.Handle(request: command, cancellationToken: default);

        // Assert
        var foodTypeFromStorage = await context.FoodTypes.SingleOrDefaultAsync(
            predicate: entity =>
                entity.Id == generatedFoodType.Id &&
                entity.Name == "Updated!");

        foodTypeFromStorage.Should().NotBeNull();
    }
}