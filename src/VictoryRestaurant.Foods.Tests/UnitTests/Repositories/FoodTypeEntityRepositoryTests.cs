namespace VictoryRestaurant.Foods.Tests.UnitTests.Repositories;

public class FoodTypeEntityRepositoryTests
{
    [Fact]
    public async ValueTask GetAllAsync()
    {
        // Arrange
        using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodTypeEntityRepository(context);

        var generatedFoodType = FoodTypeEntityGenerator.Generate();

        await repository.CreateAsync(entity: generatedFoodType);

        // Act
        var foodTypesFromStorage = await repository.GetAllAsync();

        // Assert
        foodTypesFromStorage.Should().HaveCount(expected: 1);
    }

    [Fact]
    public async ValueTask GetAllAsync_Predicate()
    {
        // Arrange
        using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodTypeEntityRepository(context);

        var generatedFoodType = FoodTypeEntityGenerator.Generate();

        await repository.CreateAsync(entity: generatedFoodType);

        // Act
        var foodTypesFromStorage = await repository.GetAllAsync(
            predicate: foodType =>
                foodType.Id == generatedFoodType.Id &&
                foodType.Name == generatedFoodType.Name);

        // Assert
        foodTypesFromStorage.Should().HaveCount(expected: 1);
    }

    [Fact]
    public async ValueTask GetAsync_Id()
    {
        // Arrange
        using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodTypeEntityRepository(context);

        var generatedFoodType = FoodTypeEntityGenerator.Generate();

        await repository.CreateAsync(entity: generatedFoodType);

        // Act
        var foodTypeFromStorage = await repository.FirstOrDefaultAsync(id: generatedFoodType.Id);

        // Assert
        foodTypeFromStorage.Should().NotBeNull().And.BeEquivalentTo(expectation: generatedFoodType);
    }

    [Fact]
    public async ValueTask GetAsync_Predicate()
    {
        // Arrange
        using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodTypeEntityRepository(context);

        var generatedFoodType = FoodTypeEntityGenerator.Generate();

        await repository.CreateAsync(entity: generatedFoodType);

        // Act
        var foodTypeFromStorage = await repository.FirstOrDefaultAsync(
            predicate: foodType =>
                foodType.Id == generatedFoodType.Id &&
                foodType.Name == generatedFoodType.Name);

        // Assert
        foodTypeFromStorage.Should().NotBeNull().And.BeEquivalentTo(expectation: generatedFoodType);
    }

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

    [Fact]
    public async ValueTask UpdateAsync()
    {
        // Arrange
        using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodTypeEntityRepository(context);

        var generatedFoodType = FoodTypeEntityGenerator.Generate();

        var createdFoodType = await repository.CreateAsync(entity: generatedFoodType);

        // Act
        createdFoodType!.Name = "Updated!";

        await repository.UpdateAsync(entity: createdFoodType);

        // Assert
        var foodTypeFromStorage = await repository.FirstOrDefaultAsync(
            predicate: food => food.Name == "Updated!");

        foodTypeFromStorage.Should().NotBeNull().And.BeEquivalentTo(expectation: createdFoodType);
    }

    [Fact]
    public async ValueTask DeleteAsync()
    {
        // Arrange
        using var context = DbContextFactory.BuildApplicationContext();

        var repository = new FoodTypeEntityRepository(context);

        var generatedFoodType = FoodTypeEntityGenerator.Generate();

        var createdFoodType = await repository.CreateAsync(entity: generatedFoodType);

        // Act
        await repository.DeleteAsync(id: createdFoodType!.Id);

        // Assert
        createdFoodType.Should().BeNull();

        var foodTypesFromStorage = await repository.GetAllAsync();

        foodTypesFromStorage.Should().NotBeNull().And.BeEmpty();
    }
}