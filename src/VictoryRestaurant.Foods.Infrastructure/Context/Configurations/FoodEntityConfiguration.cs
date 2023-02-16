namespace VictoryRestaurant.Foods.Infrastructure.Context.Configurations;

internal static class FoodEntityConfiguration
{
    /// <summary> Create configuration for <see cref="FoodEntity"/>. </summary>
    public static void AddFoodEntityConfiguration(
        this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<FoodEntity>(buildAction: entity =>
        {
            entity.ToTable(name: "foods");

            entity.HasKey(keyExpression: entity => entity.Id);

            entity.Property(propertyExpression: entity => entity.Id)
                .HasColumnName(name: "id")
                .HasColumnType(typeName: "uuid")
                .HasDefaultValueSql(sql: "uuid_generate_v4()")
                .IsRequired();

            entity.Property(propertyExpression: entity => entity.CreatedDate)
                .IsRequired()
                .HasColumnName(name: "created_date")
                .HasColumnType(typeName: "timestamp")
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
                .HasColumnType(typeName: "uuid");

            entity.HasData(data: GetDefaultValues());
        });

    private static IEnumerable<FoodEntity> GetDefaultValues() =>
        new FoodEntity[]
        {
            // Breakfast
            new()
            {
                Id = Guid.Parse(input: "bfef12be-cb69-4bde-afb1-0be5138d2d56"),
                Name = "Omelet",
                Cost = 5,
                CreatedDate = DateTime.Now.AddDays(value: -1),
                Description = "So tasty!",
                ImagePath = string.Empty,
                FoodTypeId = Guid.Parse(input: "07b99162-3f42-4ba3-a3a5-f371c2439f3e")
            },
            new()
            {
                Id = Guid.Parse(input: "bcd425c5-b34d-4e81-a3f7-43d2a2bcfe39"),
                Name = "Yogurt",
                Cost = 2.5m,
                CreatedDate = DateTime.Now.AddDays(value: -2),
                Description = "So tasty!",
                ImagePath = string.Empty,
                FoodTypeId = Guid.Parse(input: "07b99162-3f42-4ba3-a3a5-f371c2439f3e")
            },
            new()
            {
                Id = Guid.Parse(input: "c393991e-ec78-4820-a1bb-22d965955d87"),
                Name = "Porridge",
                Cost = 3,
                CreatedDate = DateTime.Now.AddDays(value: -3),
                Description = "So tasty!",
                ImagePath = string.Empty,
                FoodTypeId = Guid.Parse(input: "07b99162-3f42-4ba3-a3a5-f371c2439f3e")
            },
            new()
            {
                Id = Guid.Parse(input: "2d8ae5bc-91d6-4fbf-a26e-f47bfd66878d"),
                Name = "Cornflakes",
                Cost = 5,
                CreatedDate = DateTime.Now.AddDays(value: -4),
                Description = "So tasty!",
                ImagePath = string.Empty,
                FoodTypeId = Guid.Parse(input: "07b99162-3f42-4ba3-a3a5-f371c2439f3e")
            },
            // Lunch
            new()
            {
                Id = Guid.Parse(input: "0af0ca02-3490-4d94-8f4b-3166fc776fad"),
                Name = "Soup",
                Cost = 7,
                CreatedDate = DateTime.Now.AddDays(value: -5),
                Description = "So tasty!",
                ImagePath = string.Empty,
                FoodTypeId = Guid.Parse(input: "bec4597e-cf4d-4ee8-b25c-938a7b008843")
            },
            new()
            {
                Id = Guid.Parse(input: "74e9d378-61cd-4fa2-9845-60585e68d4de"),
                Name = "Beef steak",
                Cost = 15,
                CreatedDate = DateTime.Now.AddDays(value: -6),
                Description = "So tasty!",
                ImagePath = string.Empty,
                FoodTypeId = Guid.Parse(input: "bec4597e-cf4d-4ee8-b25c-938a7b008843")
            },
            new()
            {
                Id = Guid.Parse(input: "077d0979-0509-4f7d-9177-2e4265ac9455"),
                Name = "Pilaf",
                Cost = 10,
                CreatedDate = DateTime.Now.AddDays(value: -7),
                Description = "So tasty!",
                ImagePath = string.Empty,
                FoodTypeId = Guid.Parse(input: "bec4597e-cf4d-4ee8-b25c-938a7b008843")
            },
            new()
            {
                Id = Guid.Parse(input: "8ad21ff8-43c4-45b6-b2fa-6a2e4c8e31a6"),
                Name = "Fried potatoes",
                Cost = 10,
                CreatedDate = DateTime.Now.AddDays(value: -8),
                Description = "So tasty!",
                ImagePath = string.Empty,
                FoodTypeId = Guid.Parse(input: "bec4597e-cf4d-4ee8-b25c-938a7b008843")
            },
            // Dinner
            new()
            {
                Id = Guid.Parse(input: "9fb0dd01-f428-401c-8ef5-487c1e696148"),
                Name = "Pizza",
                Cost = 100,
                CreatedDate = DateTime.Now.AddDays(value: -9),
                Description = "So tasty!",
                ImagePath = string.Empty,
                FoodTypeId = Guid.Parse(input: "c96a0d80-70cd-4cae-b30d-e4258d500660")
            },
            new()
            {
                Id = Guid.Parse(input: "776509a9-a398-4e6e-98e9-84f7d3d9ca73"),
                Name = "Kutab",
                Cost = 30,
                CreatedDate = DateTime.Now.AddDays(value: -10),
                Description = "So tasty!",
                ImagePath = string.Empty,
                FoodTypeId = Guid.Parse(input: "c96a0d80-70cd-4cae-b30d-e4258d500660")
            },
            new()
            {
                Id = Guid.Parse(input: "ea04611a-8bdf-4971-a64f-fc2c937e2bb6"),
                Name = "Tar-tar",
                Cost = 15,
                CreatedDate = DateTime.Now.AddDays(value: -12),
                Description = "So tasty!",
                ImagePath = string.Empty,
                FoodTypeId = Guid.Parse(input: "c96a0d80-70cd-4cae-b30d-e4258d500660")
            },
            new()
            {
                Id = Guid.Parse(input: "a49e8820-e12c-4143-a3bb-f34438cb16fc"),
                Name = "Bruschetta",
                Cost = 15,
                CreatedDate = DateTime.Now.AddDays(value: -13),
                Description = "So tasty!",
                ImagePath = string.Empty,
                FoodTypeId = Guid.Parse(input: "c96a0d80-70cd-4cae-b30d-e4258d500660")
            },
            // Desert
            new()
            {
                Id = Guid.Parse(input: "b4cb3838-eef3-4055-9bd0-a1cb6c44359a"),
                Name = "Ice cream",
                Cost = 5,
                CreatedDate = DateTime.Now.AddDays(value: -14),
                Description = "So tasty!",
                ImagePath = string.Empty,
                FoodTypeId = Guid.Parse(input: "e8cfab89-854a-4899-8ffd-59b6048de3cf")
            },
            new()
            {
                Id = Guid.Parse(input: "dff85745-bf12-4aa9-b449-745cea831894"),
                Name = "Cake",
                Cost = 10,
                CreatedDate = DateTime.Now.AddDays(value: -15),
                Description = "So tasty!",
                ImagePath = string.Empty,
                FoodTypeId = Guid.Parse(input: "e8cfab89-854a-4899-8ffd-59b6048de3cf")
            },
            new()
            {
                Id = Guid.Parse(input: "4e3bbbf4-e6e1-4914-9125-215237e76404"),
                Name = "Cheesecake",
                Cost = 6,
                CreatedDate = DateTime.Now.AddDays(value: -16),
                Description = "So tasty!",
                ImagePath = string.Empty,
                FoodTypeId = Guid.Parse(input: "e8cfab89-854a-4899-8ffd-59b6048de3cf")
            },
            new()
            {
                Id = Guid.Parse(input: "0ba1411c-5ec2-4ed3-9c14-b4509f7a45df"),
                Name = "Muesli",
                Cost = 6,
                CreatedDate = DateTime.Now.AddDays(value: -17),
                Description = "So tasty!",
                ImagePath = string.Empty,
                FoodTypeId = Guid.Parse(input: "e8cfab89-854a-4899-8ffd-59b6048de3cf")
            }
        };
}