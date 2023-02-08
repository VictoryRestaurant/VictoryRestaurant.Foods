namespace VictoryRestaurant.Foods.Tests.Extensions;

public static class BogusExtensions
{
    public static string FoodType(this Commerce commerce)
    {
        var faker = new Faker();

        var dataSetJson = File.ReadAllText(path: "Data/DataSets/FoodTypeNames.json");

        var dataSet = JsonSerializer.Deserialize<FoodTypeNamesDataSet>(json: dataSetJson);

        var randomItem = faker.PickRandom(items: dataSet?.Names ?? new());

        return randomItem ?? "FoodName";
    }
}