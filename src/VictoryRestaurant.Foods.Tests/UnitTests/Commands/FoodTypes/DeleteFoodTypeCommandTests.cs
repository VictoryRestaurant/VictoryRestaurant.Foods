namespace VictoryRestaurant.Foods.Tests.UnitTests.Commands.FoodTypes;

public sealed class DeleteFoodTypeCommandTests
{
    [Fact]
    public async ValueTask Handle()
    {
        // Arrange
        await using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodTypeEntityRepository(context);

        var handler = new DeleteFoodTypeCommand.Handler(repository);

        var generatedFoodType = FoodTypeEntityGenerator.Generate();

        await context.FoodTypes.AddAsync(entity: generatedFoodType);

        await context.SaveChangesAsync();

        var command = new DeleteFoodTypeCommand(id: generatedFoodType.Id);

        // Act
        await handler.Handle(request: command, cancellationToken: default);

        // Assert
        var foodTypeFromStorage = await context.FoodTypes.SingleOrDefaultAsync(
            predicate: entity =>
                entity.Id == generatedFoodType.Id &&
                entity.Name == generatedFoodType.Name);

        foodTypeFromStorage.Should().BeNull();
    }
}