using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrinksWebApp.Data.Migrations
{
    public partial class newUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_User",
                table: "Drink");

            migrationBuilder.DropForeignKey(
                name: "FK_Opinion_User",
                table: "Opinion");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IXFK_Opinion_User",
                table: "Opinion");

            migrationBuilder.DropIndex(
                name: "IXFK_Drink_User",
                table: "Drink");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Opinion",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Opinion",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Drink",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Opinion");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Opinion",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Drink",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IXFK_Opinion_User",
                table: "Opinion",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IXFK_Drink_User",
                table: "Drink",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_User",
                table: "Drink",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Opinion_User",
                table: "Opinion",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
