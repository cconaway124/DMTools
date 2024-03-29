using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMTools.Database.Migrations
{
    /// <inheritdoc />
    public partial class Stuffs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monster_ArmorClass_ArmorClassAcId",
                schema: "monster",
                table: "Monster");

            migrationBuilder.DropIndex(
                name: "IX_Skills_MonsterId",
                schema: "monster",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Monster_ArmorClassAcId",
                schema: "monster",
                table: "Monster");

            migrationBuilder.DropIndex(
                name: "IX_Languages_MonsterId",
                schema: "monster",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "ArmorClassAcId",
                schema: "monster",
                table: "Monster");

            migrationBuilder.AlterColumn<bool>(
                name: "Hover",
                schema: "monster",
                table: "Speeds",
                type: "bit",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Blind",
                schema: "monster",
                table: "Senses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ActionType",
                schema: "monster",
                table: "MonsterActions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UnderstandsBut",
                schema: "monster",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "monster",
                table: "DamageTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MonsterId",
                schema: "monster",
                table: "ArmorClass",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_MonsterId",
                schema: "monster",
                table: "Skills",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_MonsterId",
                schema: "monster",
                table: "Languages",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmorClass_MonsterId",
                schema: "monster",
                table: "ArmorClass",
                column: "MonsterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArmorClass_Monster_MonsterId",
                schema: "monster",
                table: "ArmorClass",
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
                name: "FK_ArmorClass_Monster_MonsterId",
                schema: "monster",
                table: "ArmorClass");

            migrationBuilder.DropIndex(
                name: "IX_Skills_MonsterId",
                schema: "monster",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Languages_MonsterId",
                schema: "monster",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_ArmorClass_MonsterId",
                schema: "monster",
                table: "ArmorClass");

            migrationBuilder.DropColumn(
                name: "Blind",
                schema: "monster",
                table: "Senses");

            migrationBuilder.DropColumn(
                name: "ActionType",
                schema: "monster",
                table: "MonsterActions");

            migrationBuilder.DropColumn(
                name: "UnderstandsBut",
                schema: "monster",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "monster",
                table: "DamageTypes");

            migrationBuilder.DropColumn(
                name: "MonsterId",
                schema: "monster",
                table: "ArmorClass");

            migrationBuilder.AlterColumn<int>(
                name: "Hover",
                schema: "monster",
                table: "Speeds",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArmorClassAcId",
                schema: "monster",
                table: "Monster",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_MonsterId",
                schema: "monster",
                table: "Skills",
                column: "MonsterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Monster_ArmorClassAcId",
                schema: "monster",
                table: "Monster",
                column: "ArmorClassAcId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_MonsterId",
                schema: "monster",
                table: "Languages",
                column: "MonsterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Monster_ArmorClass_ArmorClassAcId",
                schema: "monster",
                table: "Monster",
                column: "ArmorClassAcId",
                principalSchema: "monster",
                principalTable: "ArmorClass",
                principalColumn: "AcId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
