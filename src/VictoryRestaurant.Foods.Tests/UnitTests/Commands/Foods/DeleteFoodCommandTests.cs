﻿namespace VictoryRestaurant.Foods.Tests.UnitTests.Commands.Foods;

public sealed class DeleteFoodCommandTests
{
    [Fact]
    public async ValueTask Handle()
    {
        // Arrange
        await using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodEntityRepository(context);

        var handler = new DeleteFoodCommand.Handler(repository);

        var generatedFood = FoodEntityGenerator.Generate();

        await context.Foods.AddAsync(entity: generatedFood);

        await context.SaveChangesAsync();

        var command = new DeleteFoodCommand(id: generatedFood.Id);

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
                entity.Name == generatedFood.Name);

        foodFromStorage.Should().BeNull();
    }
}