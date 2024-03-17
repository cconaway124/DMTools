using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMTools.Database.Migrations
{
    /// <inheritdoc />
    public partial class MonsterUpload3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Skills_MonsterId",
                schema: "monster",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_ChallengeRating_MonsterId",
                schema: "monster",
                table: "ChallengeRating");

            migrationBuilder.CreateTable(
                name: "DamageTypes",
                schema: "monster",
                columns: table => new
                {
                    DamageTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    MonsterId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageTypes", x => x.DamageTypeId);
                    table.ForeignKey(
                        name: "FK_DamageTypes_Monster_MonsterId",
                        column: x => x.MonsterId,
                        principalSchema: "monster",
                        principalTable: "Monster",
                        principalColumn: "MonsterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_MonsterId",
                schema: "monster",
                table: "Skills",
                column: "MonsterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeRating_MonsterId",
                schema: "monster",
                table: "ChallengeRating",
                column: "MonsterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DamageTypes_MonsterId",
                schema: "monster",
                table: "DamageTypes",
                column: "MonsterId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DamageTypes",
                schema: "monster");

            migrationBuilder.DropIndex(
                name: "IX_Skills_MonsterId",
                schema: "monster",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_ChallengeRating_MonsterId",
                schema: "monster",
                table: "ChallengeRating");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_MonsterId",
                schema: "monster",
                table: "Skills",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeRating_MonsterId",
                schema: "monster",
                table: "ChallengeRating",
                column: "MonsterId");
        }
    }
}
