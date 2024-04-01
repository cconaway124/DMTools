using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMTools.Database.Migrations
{
    /// <inheritdoc />
    public partial class fixfuckyDB5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConditionImmunity_Monster_MonsterId",
                schema: "monster",
                table: "ConditionImmunity");

            migrationBuilder.DropTable(
                name: "Monsters_x_ConditionImmunity",
                schema: "monster");

            migrationBuilder.AlterColumn<int>(
                name: "MonsterId",
                schema: "monster",
                table: "ConditionImmunity",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionImmunity_Monster_MonsterId",
                schema: "monster",
                table: "ConditionImmunity",
                column: "MonsterId",
                principalSchema: "monster",
                principalTable: "Monster",
                principalColumn: "MonsterId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConditionImmunity_Monster_MonsterId",
                schema: "monster",
                table: "ConditionImmunity");

            migrationBuilder.AlterColumn<int>(
                name: "MonsterId",
                schema: "monster",
                table: "ConditionImmunity",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Monsters_x_ConditionImmunity",
                schema: "monster",
                columns: table => new
                {
                    Monsters_ConditionImmunitiesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionImmunityId = table.Column<int>(type: "int", nullable: false),
                    MonsterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters_x_ConditionImmunity", x => x.Monsters_ConditionImmunitiesId);
                    table.ForeignKey(
                        name: "FK_Monsters_x_ConditionImmunity_ConditionImmunity_ConditionImmunityId",
                        column: x => x.ConditionImmunityId,
                        principalSchema: "monster",
                        principalTable: "ConditionImmunity",
                        principalColumn: "ConditionImmunityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Monsters_x_ConditionImmunity_Monster_MonsterId",
                        column: x => x.MonsterId,
                        principalSchema: "monster",
                        principalTable: "Monster",
                        principalColumn: "MonsterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_x_ConditionImmunity_ConditionImmunityId",
                schema: "monster",
                table: "Monsters_x_ConditionImmunity",
                column: "ConditionImmunityId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_x_ConditionImmunity_MonsterId",
                schema: "monster",
                table: "Monsters_x_ConditionImmunity",
                column: "MonsterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionImmunity_Monster_MonsterId",
                schema: "monster",
                table: "ConditionImmunity",
                column: "MonsterId",
                principalSchema: "monster",
                principalTable: "Monster",
                principalColumn: "MonsterId");
        }
    }
}
