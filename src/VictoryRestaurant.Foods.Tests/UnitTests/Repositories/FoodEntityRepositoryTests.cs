namespace VictoryRestaurant.Foods.Tests.UnitTests.Repositories;

public sealed class FoodEntityRepositoryTests
{
    [Fact]
    public async ValueTask GetAllAsync()
    {
        // Arrange
        using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodEntityRepository(context);

        var generatedFood = FoodEntityGenerator.Generate();

        await repository.CreateAsync(entity: generatedFood);

        // Act
        var foodsFromStorage = await repository.GetAllAsync();

        // Assert
        foodsFromStorage.Should().HaveCount(expected: 1);
    }

    [Fact]
    public async ValueTask GetAllAsync_Predicate()
    {
        // Arrange
        using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodEntityRepository(context);

        var generatedFood = FoodEntityGenerator.Generate();

        await repository.CreateAsync(entity: generatedFood);

        // Act
        var foodsFromStorage = await repository.GetAllAsync(
            predicate: food => 
                food.Id == generatedFood.Id &&
                food.CreatedDate == generatedFood.CreatedDate &&
                food.Name == generatedFood.Name &&
                food.Description == generatedFood.Description &&
                food.Cost == generatedFood.Cost &&
                food.ImagePath == generatedFood.ImagePath &&
                food.FoodTypeId == generatedFood.FoodTypeId &&
                food.FoodType == generatedFood.FoodType);

        // Assert
        foodsFromStorage.Should().HaveCount(expected: 1);
    }

    [Fact]
    public async ValueTask GetAsync_Id()
    {
        // Arrange
        using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodEntityRepository(context);

        var generatedFood = FoodEntityGenerator.Generate();

        await repository.CreateAsync(entity: generatedFood);

        // Act
        var foodFromStorage = await repository.GetAsync(id: generatedFood.Id);

        // Assert
        foodFromStorage.Should().NotBeNull().And.BeEquivalentTo(expectation: generatedFood);
    }

    [Fact]
    public async ValueTask GetAsync_Predicate()
    {
        // Arrange
        using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodEntityRepository(context);

        var generatedFood = FoodEntityGenerator.Generate();

        await repository.CreateAsync(entity: generatedFood);

        // Act
        var foodFromStorage = await repository.GetAsync(
            predicate: food => 
                food.Id == generatedFood.Id &&
                food.CreatedDate == generatedFood.CreatedDate &&
                food.Name == generatedFood.Name &&
                food.Description == generatedFood.Description &&
                food.Cost == generatedFood.Cost &&
                food.ImagePath == generatedFood.ImagePath &&
                food.FoodTypeId == generatedFood.FoodTypeId &&
                food.FoodType == generatedFood.FoodType);

        // Assert
        foodFromStorage.Should().NotBeNull().And.BeEquivalentTo(expectation: generatedFood);
    }

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

    [Fact]
    public async ValueTask UpdateAsync()
    {
        // Arrange
        using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodEntityRepository(context);

        var generatedFood = FoodEntityGenerator.Generate();

        var createdFood = await repository.CreateAsync(entity: generatedFood);

        // Act
        createdFood!.Description = "Updated!";

        await repository.UpdateAsync(entity: createdFood);

        // Assert
        var foodFromStorage = await repository.GetAsync(
            predicate: food => food.Description == "Updated!");

        foodFromStorage.Should().NotBeNull().And.BeEquivalentTo(expectation: createdFood);
    }

    [Fact]
    public async ValueTask DeleteAsync()
    {
        // Arrange
        using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodEntityRepository(context);

        var generatedFood = FoodEntityGenerator.Generate();

        var createdFood = await repository.CreateAsync(entity: generatedFood);

        // Act
        await repository.DeleteAsync(id: createdFood!.Id);

        // Assert
        createdFood.Should().BeNull();

        var foodsFromStorage = await repository.GetAllAsync();

        foodsFromStorage.Should().NotBeNull().And.BeEmpty();
    }
}