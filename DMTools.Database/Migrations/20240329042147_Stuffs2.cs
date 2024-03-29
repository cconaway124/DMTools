using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMTools.Database.Migrations
{
    /// <inheritdoc />
    public partial class Stuffs2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DamageTypes_MonsterId",
                schema: "monster",
                table: "DamageTypes");

            migrationBuilder.CreateIndex(
                name: "IX_DamageTypes_MonsterId",
                schema: "monster",
                table: "DamageTypes",
                column: "MonsterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DamageTypes_MonsterId",
                schema: "monster",
                table: "DamageTypes");

            migrationBuilder.CreateIndex(
                name: "IX_DamageTypes_MonsterId",
                schema: "monster",
                table: "DamageTypes",
                column: "MonsterId",
                unique: true);
        }
    }
}
