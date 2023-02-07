namespace VictoryRestaurant.Foods.Tests.Data.Generators;

public static class FoodEntityGenerator
{
    public static FoodEntity Generate()
    {
        var faker = new Faker();

        var foodType = FoodTypeEntityGenerator.GenerateFoodTypeEntity();

        FoodEntity food = new()
        {
            Id = faker.Random.Guid(),
            CreatedDate = faker.Date.Between(start: DateTime.Now.AddDays(value: -7), end: DateTime.Now),
            Name = faker.Lorem.Word(),
            Description = faker.Lorem.Text(),
            ImagePath = string.Empty,
            Cost = faker.Random.Int(min: 0),
            FoodTypeId = foodType.Id,
            FoodType = foodType
        };

        return food;
    }
}