using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kuharica.Data.Migrations
{
    public partial class AddedRestOfDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meal_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NutritionalValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kcal = table.Column<int>(type: "int", nullable: false),
                    Fat = table.Column<double>(type: "float", nullable: false),
                    Protein = table.Column<double>(type: "float", nullable: false),
                    Carbohydrates = table.Column<double>(type: "float", nullable: false),
                    Sugar = table.Column<double>(type: "float", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionalValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutritionalValue_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConvertMeasurementUnit",
                columns: table => new
                {
                    UnitFromId = table.Column<int>(type: "int", nullable: false),
                    UnitToId = table.Column<int>(type: "int", nullable: false),
                    Factor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConvertMeasurementUnit", x => new { x.UnitFromId, x.UnitToId });
                    table.ForeignKey(
                        name: "FK_ConvertMeasurementUnit_MeasurementUnits_UnitToId",
                        column: x => x.UnitToId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MealIngredient",
                columns: table => new
                {
                    MealId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    MeasurementUnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealIngredient", x => new { x.MealId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_MealIngredient_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealIngredient_Meal_MealId",
                        column: x => x.MealId,
                        principalTable: "Meal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealIngredient_MeasurementUnits_MeasurementUnitId",
                        column: x => x.MeasurementUnitId,
                        principalTable: "MeasurementUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConvertMeasurementUnit_UnitToId",
                table: "ConvertMeasurementUnit",
                column: "UnitToId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_CategoryId",
                table: "Meal",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MealIngredient_IngredientId",
                table: "MealIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_MealIngredient_MeasurementUnitId",
                table: "MealIngredient",
                column: "MeasurementUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionalValue_IngredientId",
                table: "NutritionalValue",
                column: "IngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConvertMeasurementUnit");

            migrationBuilder.DropTable(
                name: "MealIngredient");

            migrationBuilder.DropTable(
                name: "NutritionalValue");

            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropTable(
                name: "MeasurementUnits");

            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}
