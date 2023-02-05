namespace VictoryRestaurant.Foods.Persistence.Context.Configurations;

internal static class FoodEntityConfiguration
{
    /// <summary> Create configuration for <see cref="FoodEntity"/>. </summary>
    public static void AddFoodEntityConfiguration(
        this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<FoodEntity>(buildAction: entity =>
        {
            entity.ToTable(name: "Foods");

            entity.HasKey(keyExpression: entity => entity.Id);

            entity.Property(propertyExpression: entity => entity.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName(name: "id")
                .HasColumnType(typeName: "text")
                .HasValueGenerator<GuidValueGenerator>();

            entity.Property(propertyExpression: entity => entity.CreatedDate)
                .IsRequired()
                .HasColumnName(name: "created_date")
                .HasColumnType(typeName: "timestamp without time zone")
                .HasDefaultValueSql(sql: "now()");

            entity.Property(propertyExpression: entity => entity.Name)
                .IsRequired()
                .HasMaxLength(maxLength: 50)
                .HasColumnName(name: "name")
                .HasColumnType(typeName: "text");

            entity.Property(propertyExpression: entity => entity.Description)
                .HasMaxLength(maxLength: 100)
                .HasColumnName(name: "description")
                .HasColumnType(typeName: "text");

            entity.Property(propertyExpression: entity => entity.Cost)
                .IsRequired()
                .HasColumnName(name: "cost")
                .HasColumnType(typeName: "decimal")
                .HasDefaultValue(value: 0);

            entity.Property(propertyExpression: entity => entity.ImagePath)
                .HasColumnName(name: "image_path")
                .HasColumnType(typeName: "text");

            entity.Property(propertyExpression: entity => entity.FoodTypeId)
                .HasColumnName(name: "food_type_id")
                .HasColumnType(typeName: "text");
        });
}