using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VictoryRestaurant.Foods.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "food_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "text", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_food_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "foods",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp", nullable: false, defaultValueSql: "now()"),
                    name = table.Column<string>(type: "text", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", maxLength: 100, nullable: true),
                    cost = table.Column<decimal>(type: "decimal", nullable: false, defaultValue: 0m),
                    imagepath = table.Column<string>(name: "image_path", type: "text", nullable: true),
                    foodtypeid = table.Column<Guid>(name: "food_type_id", type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_foods", x => x.id);
                    table.ForeignKey(
                        name: "FK_foods_food_types_food_type_id",
                        column: x => x.foodtypeid,
                        principalTable: "food_types",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "food_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("07b99162-3f42-4ba3-a3a5-f371c2439f3e"), "Breakfast" },
                    { new Guid("bec4597e-cf4d-4ee8-b25c-938a7b008843"), "Lunch" },
                    { new Guid("c96a0d80-70cd-4cae-b30d-e4258d500660"), "Dinner" },
                    { new Guid("e8cfab89-854a-4899-8ffd-59b6048de3cf"), "Desert" }
                });

            migrationBuilder.InsertData(
                table: "foods",
                columns: new[] { "id", "cost", "created_date", "description", "food_type_id", "image_path", "name" },
                values: new object[,]
                {
                    { new Guid("077d0979-0509-4f7d-9177-2e4265ac9455"), 10m, new DateTime(2023, 2, 4, 16, 0, 48, 846, DateTimeKind.Local).AddTicks(3067), "So tasty!", new Guid("bec4597e-cf4d-4ee8-b25c-938a7b008843"), "", "Pilaf" },
                    { new Guid("0af0ca02-3490-4d94-8f4b-3166fc776fad"), 7m, new DateTime(2023, 2, 6, 16, 0, 48, 846, DateTimeKind.Local).AddTicks(3063), "So tasty!", new Guid("bec4597e-cf4d-4ee8-b25c-938a7b008843"), "", "Soup" },
                    { new Guid("0ba1411c-5ec2-4ed3-9c14-b4509f7a45df"), 6m, new DateTime(2023, 1, 25, 16, 0, 48, 846, DateTimeKind.Local).AddTicks(3088), "So tasty!", new Guid("e8cfab89-854a-4899-8ffd-59b6048de3cf"), "", "Muesli" },
                    { new Guid("2d8ae5bc-91d6-4fbf-a26e-f47bfd66878d"), 5m, new DateTime(2023, 2, 7, 16, 0, 48, 846, DateTimeKind.Local).AddTicks(3060), "So tasty!", new Guid("07b99162-3f42-4ba3-a3a5-f371c2439f3e"), "", "Cornflakes" },
                    { new Guid("4e3bbbf4-e6e1-4914-9125-215237e76404"), 6m, new DateTime(2023, 1, 26, 16, 0, 48, 846, DateTimeKind.Local).AddTicks(3086), "So tasty!", new Guid("e8cfab89-854a-4899-8ffd-59b6048de3cf"), "", "Cheesecake" },
                    { new Guid("74e9d378-61cd-4fa2-9845-60585e68d4de"), 15m, new DateTime(2023, 2, 5, 16, 0, 48, 846, DateTimeKind.Local).AddTicks(3065), "So tasty!", new Guid("bec4597e-cf4d-4ee8-b25c-938a7b008843"), "", "Beef steak" },
                    { new Guid("776509a9-a398-4e6e-98e9-84f7d3d9ca73"), 30m, new DateTime(2023, 2, 1, 16, 0, 48, 846, DateTimeKind.Local).AddTicks(3074), "So tasty!", new Guid("c96a0d80-70cd-4cae-b30d-e4258d500660"), "", "Kutab" },
                    { new Guid("8ad21ff8-43c4-45b6-b2fa-6a2e4c8e31a6"), 10m, new DateTime(2023, 2, 3, 16, 0, 48, 846, DateTimeKind.Local).AddTicks(3070), "So tasty!", new Guid("bec4597e-cf4d-4ee8-b25c-938a7b008843"), "", "Fried potatoes" },
                    { new Guid("9fb0dd01-f428-401c-8ef5-487c1e696148"), 100m, new DateTime(2023, 2, 2, 16, 0, 48, 846, DateTimeKind.Local).AddTicks(3072), "So tasty!", new Guid("c96a0d80-70cd-4cae-b30d-e4258d500660"), "", "Pizza" },
                    { new Guid("a49e8820-e12c-4143-a3bb-f34438cb16fc"), 15m, new DateTime(2023, 1, 29, 16, 0, 48, 846, DateTimeKind.Local).AddTicks(3079), "So tasty!", new Guid("c96a0d80-70cd-4cae-b30d-e4258d500660"), "", "Bruschetta" },
                    { new Guid("b4cb3838-eef3-4055-9bd0-a1cb6c44359a"), 5m, new DateTime(2023, 1, 28, 16, 0, 48, 846, DateTimeKind.Local).AddTicks(3082), "So tasty!", new Guid("e8cfab89-854a-4899-8ffd-59b6048de3cf"), "", "Ice cream" },
                    { new Guid("bcd425c5-b34d-4e81-a3f7-43d2a2bcfe39"), 2.5m, new DateTime(2023, 2, 9, 16, 0, 48, 846, DateTimeKind.Local).AddTicks(3054), "So tasty!", new Guid("07b99162-3f42-4ba3-a3a5-f371c2439f3e"), "", "Yogurt" },
                    { new Guid("bfef12be-cb69-4bde-afb1-0be5138d2d56"), 5m, new DateTime(2023, 2, 10, 16, 0, 48, 846, DateTimeKind.Local).AddTicks(3028), "So tasty!", new Guid("07b99162-3f42-4ba3-a3a5-f371c2439f3e"), "", "Omelet" },
                    { new Guid("c393991e-ec78-4820-a1bb-22d965955d87"), 3m, new DateTime(2023, 2, 8, 16, 0, 48, 846, DateTimeKind.Local).AddTicks(3058), "So tasty!", new Guid("07b99162-3f42-4ba3-a3a5-f371c2439f3e"), "", "Porridge" },
                    { new Guid("dff85745-bf12-4aa9-b449-745cea831894"), 10m, new DateTime(2023, 1, 27, 16, 0, 48, 846, DateTimeKind.Local).AddTicks(3084), "So tasty!", new Guid("e8cfab89-854a-4899-8ffd-59b6048de3cf"), "", "Cake" },
                    { new Guid("ea04611a-8bdf-4971-a64f-fc2c937e2bb6"), 15m, new DateTime(2023, 1, 30, 16, 0, 48, 846, DateTimeKind.Local).AddTicks(3077), "So tasty!", new Guid("c96a0d80-70cd-4cae-b30d-e4258d500660"), "", "Tar-tar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_foods_food_type_id",
                table: "foods",
                column: "food_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "foods");

            migrationBuilder.DropTable(
                name: "food_types");
        }
    }
}
