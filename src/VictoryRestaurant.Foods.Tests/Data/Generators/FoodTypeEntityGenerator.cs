namespace VictoryRestaurant.Foods.Tests.Data.Generators;

public static class FoodTypeEntityGenerator
{
    public static FoodTypeEntity GenerateFoodTypeEntity()
    {
        var faker = new Faker();

        FoodTypeEntity foodType = new()
        {
            Id = faker.Random.Guid(),
            Name = faker.Commerce.FoodType()
        };

        return foodType;
    }
}