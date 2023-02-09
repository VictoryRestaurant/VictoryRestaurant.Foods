namespace VictoryRestaurant.Foods.Infrastructure.Context.Configurations;

internal static class FoodTypeEntityConfiguration
{
    /// <summary> Create configuration for <see cref="FoodTypeEntity"/>. </summary>
    public static void AddFoodTypeEntityConfiguration(
        this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<FoodTypeEntity>(buildAction: entity =>
        {
            entity.ToTable(name: "FoodTypes");

            entity.HasKey(keyExpression: entity => entity.Id);

            entity.Property(propertyExpression: entity => entity.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName(name: "id")
                .HasColumnType(typeName: "text")
                .HasValueGenerator<GuidValueGenerator>();

            entity.Property(propertyExpression: entity => entity.Name)
                .IsRequired()
                .HasMaxLength(maxLength: 50)
                .HasColumnName(name: "name")
                .HasColumnType(typeName: "text");
        });
}