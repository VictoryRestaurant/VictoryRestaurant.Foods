namespace VictoryRestaurant.Foods.Infrastructure.Context.Configurations;

internal static class FoodTypeEntityConfiguration
{
    /// <summary> Create configuration for <see cref="FoodTypeEntity"/>. </summary>
    public static void AddFoodTypeEntityConfiguration(
        this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<FoodTypeEntity>(buildAction: entity =>
        {
            entity.ToTable(name: "food_types");

            entity.HasKey(keyExpression: entity => entity.Id);

            entity.Property(propertyExpression: entity => entity.Id)
                .HasColumnName(name: "id")
                .HasColumnType(typeName: "uuid")
                .HasDefaultValueSql(sql: "uuid_generate_v4()")
                .IsRequired();

            entity.Property(propertyExpression: entity => entity.Name)
                .IsRequired()
                .HasMaxLength(maxLength: 50)
                .HasColumnName(name: "name")
                .HasColumnType(typeName: "text");

            entity.HasData(data: GetDefaultValues());
        });

    private static IEnumerable<FoodTypeEntity> GetDefaultValues() =>
        new FoodTypeEntity[]
        {
            new()
            {
                Id = Guid.Parse(input: "07b99162-3f42-4ba3-a3a5-f371c2439f3e"),
                Name = "Breakfast"
            },
            new()
            {
                Id = Guid.Parse(input: "bec4597e-cf4d-4ee8-b25c-938a7b008843"),
                Name = "Lunch"
            },
            new()
            {
                Id = Guid.Parse(input: "c96a0d80-70cd-4cae-b30d-e4258d500660"),
                Name = "Dinner"
            },
            new()
            {
                Id = Guid.Parse(input: "e8cfab89-854a-4899-8ffd-59b6048de3cf"),
                Name = "Desert"
            }
        };
}