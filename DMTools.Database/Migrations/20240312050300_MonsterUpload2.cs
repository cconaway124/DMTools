using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMTools.Database.Migrations
{
    /// <inheritdoc />
    public partial class MonsterUpload2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConditionImmunity_Monster_MonsterId",
                schema: "monster",
                table: "ConditionImmunity");

            migrationBuilder.AlterColumn<string>(
                name: "MonsterId",
                schema: "monster",
                table: "ConditionImmunity",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionImmunity_Monster_MonsterId",
                schema: "monster",
                table: "ConditionImmunity",
                column: "MonsterId",
                principalSchema: "monster",
                principalTable: "Monster",
                principalColumn: "MonsterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConditionImmunity_Monster_MonsterId",
                schema: "monster",
                table: "ConditionImmunity");

            migrationBuilder.AlterColumn<string>(
                name: "MonsterId",
                schema: "monster",
                table: "ConditionImmunity",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
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
    }
}
