using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TabletopMuster.Migrations
{
    /// <inheritdoc />
    public partial class AddGameModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Units",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Units",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Units",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FactionId",
                table: "Units",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StatsJson",
                table: "Units",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    GameSystemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factions_GameSystems_GameSystemId",
                        column: x => x.GameSystemId,
                        principalTable: "GameSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArmyLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PointsLimit = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsImported = table.Column<bool>(type: "INTEGER", nullable: false),
                    OwnerId = table.Column<string>(type: "TEXT", nullable: false),
                    FactionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmyLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArmyLists_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmyLists_Factions_FactionId",
                        column: x => x.FactionId,
                        principalTable: "Factions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArmyListEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArmyListId = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmyListEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArmyListEntries_ArmyLists_ArmyListId",
                        column: x => x.ArmyListId,
                        principalTable: "ArmyLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmyListEntries_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Units_AuthorId",
                table: "Units",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_FactionId",
                table: "Units",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmyListEntries_ArmyListId",
                table: "ArmyListEntries",
                column: "ArmyListId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmyListEntries_UnitId",
                table: "ArmyListEntries",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmyLists_FactionId",
                table: "ArmyLists",
                column: "FactionId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmyLists_OwnerId",
                table: "ArmyLists",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Factions_GameSystemId",
                table: "Factions",
                column: "GameSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_AspNetUsers_AuthorId",
                table: "Units",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Factions_FactionId",
                table: "Units",
                column: "FactionId",
                principalTable: "Factions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_AspNetUsers_AuthorId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Factions_FactionId",
                table: "Units");

            migrationBuilder.DropTable(
                name: "ArmyListEntries");

            migrationBuilder.DropTable(
                name: "ArmyLists");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropTable(
                name: "GameSystems");

            migrationBuilder.DropIndex(
                name: "IX_Units_AuthorId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_FactionId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "FactionId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "StatsJson",
                table: "Units");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Units",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Units",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
