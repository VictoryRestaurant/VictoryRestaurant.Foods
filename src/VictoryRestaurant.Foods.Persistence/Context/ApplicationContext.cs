namespace VictoryRestaurant.Foods.Persistence.Context;

public sealed class ApplicationContext : DbContext
{
    /// <summary> Foods collection. </summary>
    public DbSet<FoodEntity> Foods => Set<FoodEntity>();

    /// <summary> Food types collection. </summary>
    public DbSet<FoodTypeEntity> FoodTypes => Set<FoodTypeEntity>();

    public ApplicationContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddFoodEntityConfiguration();

        modelBuilder.AddFoodTypeEntityConfiguration();

        base.OnModelCreating(modelBuilder);
    }
}