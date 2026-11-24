using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TabletopMuster.Migrations
{
    /// <inheritdoc />
    public partial class AddSystemDefinitions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoriesJson",
                table: "GameSystems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StatDefinitionsJson",
                table: "GameSystems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriesJson",
                table: "GameSystems");

            migrationBuilder.DropColumn(
                name: "StatDefinitionsJson",
                table: "GameSystems");
        }
    }
}
