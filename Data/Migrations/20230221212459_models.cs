using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinksWebApp.Data.Migrations
{
    public partial class models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlcoholIngredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    AlcoholVolume = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlcoholIngredient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Recipe = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drink_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AlcoholIngredientDrink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlcoholIngredientId = table.Column<int>(type: "INTEGER", nullable: false),
                    DrinkId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlcoholIngredientDrink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlcoholIngredientDrink_AlcoholIngredient",
                        column: x => x.AlcoholIngredientId,
                        principalTable: "AlcoholIngredient",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AlcoholIngredientDrink_Drink",
                        column: x => x.DrinkId,
                        principalTable: "Drink",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IngredientDrink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IngredientId = table.Column<int>(type: "INTEGER", nullable: false),
                    DrinkId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientDrink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientDrink_Drink",
                        column: x => x.DrinkId,
                        principalTable: "Drink",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IngredientDrink_Ingredient",
                        column: x => x.IngredientId,
                        principalTable: "Ingredient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Opinion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    Rate = table.Column<int>(type: "INTEGER", nullable: false),
                    DrinkId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opinion_Drink",
                        column: x => x.DrinkId,
                        principalTable: "Drink",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Opinion_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IXFK_AlcoholIngredientDrink_Drink",
                table: "AlcoholIngredientDrink",
                column: "DrinkId");

            migrationBuilder.CreateIndex(
                name: "IXFK_AlcoholIngredientDrink_Ingredient",
                table: "AlcoholIngredientDrink",
                column: "AlcoholIngredientId");

            migrationBuilder.CreateIndex(
                name: "UQ_AlcoholIngredientDrink_IngredientDrinkId",
                table: "AlcoholIngredientDrink",
                columns: new[] { "DrinkId", "AlcoholIngredientId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IXFK_Drink_User",
                table: "Drink",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IXFK_IngredientDrink_Drink",
                table: "IngredientDrink",
                column: "DrinkId");

            migrationBuilder.CreateIndex(
                name: "IXFK_IngredientDrink_Ingredient",
                table: "IngredientDrink",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "UQ_IngredientDrink_IngredientDrinkId",
                table: "IngredientDrink",
                columns: new[] { "DrinkId", "IngredientId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IXFK_Opinion_Drink",
                table: "Opinion",
                column: "DrinkId");

            migrationBuilder.CreateIndex(
                name: "IXFK_Opinion_User",
                table: "Opinion",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlcoholIngredientDrink");

            migrationBuilder.DropTable(
                name: "IngredientDrink");

            migrationBuilder.DropTable(
                name: "Opinion");

            migrationBuilder.DropTable(
                name: "AlcoholIngredient");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Drink");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
