using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMTools.Database.Migrations
{
    /// <inheritdoc />
    public partial class fixfucktDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actions",
                schema: "monster");

            migrationBuilder.DropIndex(
                name: "IX_SavingThrows_MonsterId",
                schema: "monster",
                table: "SavingThrows");

            migrationBuilder.CreateIndex(
                name: "IX_SavingThrows_MonsterId",
                schema: "monster",
                table: "SavingThrows",
                column: "MonsterId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SavingThrows_MonsterId",
                schema: "monster",
                table: "SavingThrows");

            migrationBuilder.CreateTable(
                name: "Actions",
                schema: "monster",
                columns: table => new
                {
                    ActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonsterActionId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionRules = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.ActionId);
                    table.ForeignKey(
                        name: "FK_Actions_MonsterActions_MonsterActionId",
                        column: x => x.MonsterActionId,
                        principalSchema: "monster",
                        principalTable: "MonsterActions",
                        principalColumn: "MonsterActionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavingThrows_MonsterId",
                schema: "monster",
                table: "SavingThrows",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_MonsterActionId",
                schema: "monster",
                table: "Actions",
                column: "MonsterActionId");
        }
    }
}
