namespace VictoryRestaurant.Foods.Tests.Data.Factories;

public static class DbContextFactory
{
    public static ApplicationContext BuildApplicationContext()
    {
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        var builder = new DbContextOptionsBuilder<ApplicationContext>();

        var options = builder.UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .UseInternalServiceProvider(serviceProvider).Options;

        ApplicationContext context = new(options);

        return context;
    }
}