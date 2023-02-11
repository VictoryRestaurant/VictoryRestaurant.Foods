namespace VictoryRestaurant.Foods.Tests.UnitTests.Commands.Foods;

public sealed class UpdateFoodCommandTests
{
    [Fact]
    public async ValueTask Handle()
    {
        // Arrange
        await using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodEntityRepository(context);

        var handler = new UpdateFoodCommand.Handler(repository);

        var generatedFood = FoodEntityGenerator.Generate();

        await context.Foods.AddAsync(entity: generatedFood);

        await context.SaveChangesAsync();

        context.Entry(entity: generatedFood).State = EntityState.Detached;

        generatedFood.Name = "Updated!";

        var command = new UpdateFoodCommand(food: generatedFood);

        // Act
        await handler.Handle(request: command, cancellationToken: default);

        // Assert
        var foodFromStorage = await context.Foods.SingleOrDefaultAsync(
            predicate: entity =>
                entity.Id == generatedFood.Id &&
                entity.CreatedDate == generatedFood.CreatedDate &&
                entity.Cost == generatedFood.Cost &&
                entity.ImagePath == generatedFood.ImagePath &&
                entity.Description == generatedFood.Description &&
                entity.FoodTypeId == generatedFood.FoodTypeId &&
                entity.FoodType == generatedFood.FoodType &&
                entity.Name == "Updated!");

        foodFromStorage.Should().NotBeNull();
    }
}