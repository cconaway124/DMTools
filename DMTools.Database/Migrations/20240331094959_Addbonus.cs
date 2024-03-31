using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMTools.Database.Migrations
{
    /// <inheritdoc />
    public partial class Addbonus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DexBonus",
                schema: "monster",
                table: "ArmorClass",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NaturalArmorBonus",
                schema: "monster",
                table: "ArmorClass",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DexBonus",
                schema: "monster",
                table: "ArmorClass");

            migrationBuilder.DropColumn(
                name: "NaturalArmorBonus",
                schema: "monster",
                table: "ArmorClass");
        }
    }
}
