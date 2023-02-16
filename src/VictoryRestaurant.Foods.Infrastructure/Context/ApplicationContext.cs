namespace VictoryRestaurant.Foods.Infrastructure.Context;

public sealed class ApplicationContext : DbContext
{
    /// <summary> Foods collection. </summary>
    public DbSet<FoodEntity> Foods => Set<FoodEntity>();

    /// <summary> Food types collection. </summary>
    public DbSet<FoodTypeEntity> FoodTypes => Set<FoodTypeEntity>();

    public ApplicationContext(DbContextOptions options) : base(options)
    {
        AppContext.SetSwitch(switchName: "Npgsql.EnableLegacyTimestampBehavior", isEnabled: true);

        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension(name: "uuid-ossp");

        modelBuilder.AddFoodTypeEntityConfiguration();

        modelBuilder.AddFoodEntityConfiguration();

        base.OnModelCreating(modelBuilder);
    }
}