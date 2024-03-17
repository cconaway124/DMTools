using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMTools.Database.Migrations
{
    /// <inheritdoc />
    public partial class MonsterUpload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "monster");

            migrationBuilder.CreateTable(
                name: "ArmorClass",
                schema: "monster",
                columns: table => new
                {
                    AcId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArmorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllowsDexMod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmorClass", x => x.AcId);
                });

            migrationBuilder.CreateTable(
                name: "Monster",
                schema: "monster",
                columns: table => new
                {
                    MonsterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCustomCr = table.Column<bool>(type: "bit", nullable: false),
                    CustomCr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfBonus = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomHp = table.Column<bool>(type: "bit", nullable: false),
                    CustomSpeed = table.Column<bool>(type: "bit", nullable: false),
                    IsLegendary = table.Column<bool>(type: "bit", nullable: false),
                    LegendariesDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsLair = table.Column<bool>(type: "bit", nullable: false),
                    LairDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LairDescriptionEnd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMythic = table.Column<bool>(type: "bit", nullable: false),
                    MythicDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRegional = table.Column<bool>(type: "bit", nullable: false),
                    RegionalDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionalDescriptionEnd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PluralName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoubleColumns = table.Column<bool>(type: "bit", nullable: false),
                    SeparationPoint = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    ArmorClassAcId = table.Column<int>(type: "int", nullable: false),
                    HitPoints = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Alignment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monster", x => x.MonsterId);
                    table.ForeignKey(
                        name: "FK_Monster_ArmorClass_ArmorClassAcId",
                        column: x => x.ArmorClassAcId,
                        principalSchema: "monster",
                        principalTable: "ArmorClass",
                        principalColumn: "AcId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChallengeRating",
                schema: "monster",
                columns: table => new
                {
                    ChallengeRatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonsterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Cr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Xp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomCr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeRating", x => x.ChallengeRatingId);
                    table.ForeignKey(
                        name: "FK_ChallengeRating_Monster_MonsterId",
                        column: x => x.MonsterId,
                        principalSchema: "monster",
                        principalTable: "Monster",
                        principalColumn: "MonsterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConditionImmunity",
                schema: "monster",
                columns: table => new
                {
                    ConditionImmunityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonsterId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionImmunity", x => x.ConditionImmunityId);
                    table.ForeignKey(
                        name: "FK_ConditionImmunity_Monster_MonsterId",
                        column: x => x.MonsterId,
                        principalSchema: "monster",
                        principalTable: "Monster",
                        principalColumn: "MonsterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HitDie",
                schema: "monster",
                columns: table => new
                {
                    HitDieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    HitDieType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConMod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AverageHp = table.Column<int>(type: "int", nullable: false),
                    MonsterId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HitDie", x => x.HitDieId);
                    table.ForeignKey(
                        name: "FK_HitDie_Monster_MonsterId",
                        column: x => x.MonsterId,
                        principalSchema: "monster",
                        principalTable: "Monster",
                        principalColumn: "MonsterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "monster",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageLevel = table.Column<int>(type: "int", nullable: false),
                    MonsterId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                    table.ForeignKey(
                        name: "FK_Languages_Monster_MonsterId",
                        column: x => x.MonsterId,
                        principalSchema: "monster",
                        principalTable: "Monster",
                        principalColumn: "MonsterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonsterActions",
                schema: "monster",
                columns: table => new
                {
                    MonsterActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonsterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterActions", x => x.MonsterActionId);
                    table.ForeignKey(
                        name: "FK_MonsterActions_Monster_MonsterId",
                        column: x => x.MonsterId,
                        principalSchema: "monster",
                        principalTable: "Monster",
                        principalColumn: "MonsterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavingThrows",
                schema: "monster",
                columns: table => new
                {
                    SavingThrowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfBonus = table.Column<int>(type: "int", nullable: false),
                    Str = table.Column<int>(type: "int", nullable: true),
                    Dex = table.Column<int>(type: "int", nullable: true),
                    Con = table.Column<int>(type: "int", nullable: true),
                    Int = table.Column<int>(type: "int", nullable: true),
                    Wis = table.Column<int>(type: "int", nullable: true),
                    Cha = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonsterId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingThrows", x => x.SavingThrowId);
                    table.ForeignKey(
                        name: "FK_SavingThrows_Monster_MonsterId",
                        column: x => x.MonsterId,
                        principalSchema: "monster",
                        principalTable: "Monster",
                        principalColumn: "MonsterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Senses",
                schema: "monster",
                columns: table => new
                {
                    SenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlindSight = table.Column<int>(type: "int", nullable: true),
                    Darkvision = table.Column<int>(type: "int", nullable: true),
                    Tremorsense = table.Column<int>(type: "int", nullable: true),
                    Truesight = table.Column<int>(type: "int", nullable: true),
                    Telepathy = table.Column<int>(type: "int", nullable: true),
                    PassivePerception = table.Column<int>(type: "int", nullable: false),
                    MonsterId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senses", x => x.SenseId);
                    table.ForeignKey(
                        name: "FK_Senses_Monster_MonsterId",
                        column: x => x.MonsterId,
                        principalSchema: "monster",
                        principalTable: "Monster",
                        principalColumn: "MonsterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                schema: "monster",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bonus = table.Column<int>(type: "int", nullable: false),
                    MonsterId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_Skills_Monster_MonsterId",
                        column: x => x.MonsterId,
                        principalSchema: "monster",
                        principalTable: "Monster",
                        principalColumn: "MonsterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Speeds",
                schema: "monster",
                columns: table => new
                {
                    SpeedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Speed = table.Column<int>(type: "int", nullable: true),
                    Burrow = table.Column<int>(type: "int", nullable: true),
                    Climb = table.Column<int>(type: "int", nullable: true),
                    Fly = table.Column<int>(type: "int", nullable: true),
                    Swim = table.Column<int>(type: "int", nullable: true),
                    Hover = table.Column<int>(type: "int", nullable: true),
                    MonsterId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speeds", x => x.SpeedId);
                    table.ForeignKey(
                        name: "FK_Speeds_Monster_MonsterId",
                        column: x => x.MonsterId,
                        principalSchema: "monster",
                        principalTable: "Monster",
                        principalColumn: "MonsterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                schema: "monster",
                columns: table => new
                {
                    StatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Str = table.Column<int>(type: "int", nullable: false),
                    Dex = table.Column<int>(type: "int", nullable: false),
                    Con = table.Column<int>(type: "int", nullable: false),
                    Int = table.Column<int>(type: "int", nullable: false),
                    Wis = table.Column<int>(type: "int", nullable: false),
                    Cha = table.Column<int>(type: "int", nullable: false),
                    MonsterId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.StatId);
                    table.ForeignKey(
                        name: "FK_Stats_Monster_MonsterId",
                        column: x => x.MonsterId,
                        principalSchema: "monster",
                        principalTable: "Monster",
                        principalColumn: "MonsterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monsters_x_ConditionImmunity",
                schema: "monster",
                columns: table => new
                {
                    Monsters_ConditionImmunitiesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonsterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConditionImmunityId = table.Column<int>(type: "int", nullable: false)
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Monsters_x_ConditionImmunity_Monster_MonsterId",
                        column: x => x.MonsterId,
                        principalSchema: "monster",
                        principalTable: "Monster",
                        principalColumn: "MonsterId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                schema: "monster",
                columns: table => new
                {
                    ActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionRules = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonsterActionId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Actions_MonsterActionId",
                schema: "monster",
                table: "Actions",
                column: "MonsterActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChallengeRating_MonsterId",
                schema: "monster",
                table: "ChallengeRating",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionImmunity_MonsterId",
                schema: "monster",
                table: "ConditionImmunity",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_HitDie_MonsterId",
                schema: "monster",
                table: "HitDie",
                column: "MonsterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_MonsterId",
                schema: "monster",
                table: "Languages",
                column: "MonsterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Monster_ArmorClassAcId",
                schema: "monster",
                table: "Monster",
                column: "ArmorClassAcId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterActions_MonsterId",
                schema: "monster",
                table: "MonsterActions",
                column: "MonsterId");

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

            migrationBuilder.CreateIndex(
                name: "IX_SavingThrows_MonsterId",
                schema: "monster",
                table: "SavingThrows",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_Senses_MonsterId",
                schema: "monster",
                table: "Senses",
                column: "MonsterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_MonsterId",
                schema: "monster",
                table: "Skills",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_Speeds_MonsterId",
                schema: "monster",
                table: "Speeds",
                column: "MonsterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stats_MonsterId",
                schema: "monster",
                table: "Stats",
                column: "MonsterId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actions",
                schema: "monster");

            migrationBuilder.DropTable(
                name: "ChallengeRating",
                schema: "monster");

            migrationBuilder.DropTable(
                name: "HitDie",
                schema: "monster");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "monster");

            migrationBuilder.DropTable(
                name: "Monsters_x_ConditionImmunity",
                schema: "monster");

            migrationBuilder.DropTable(
                name: "SavingThrows",
                schema: "monster");

            migrationBuilder.DropTable(
                name: "Senses",
                schema: "monster");

            migrationBuilder.DropTable(
                name: "Skills",
                schema: "monster");

            migrationBuilder.DropTable(
                name: "Speeds",
                schema: "monster");

            migrationBuilder.DropTable(
                name: "Stats",
                schema: "monster");

            migrationBuilder.DropTable(
                name: "MonsterActions",
                schema: "monster");

            migrationBuilder.DropTable(
                name: "ConditionImmunity",
                schema: "monster");

            migrationBuilder.DropTable(
                name: "Monster",
                schema: "monster");

            migrationBuilder.DropTable(
                name: "ArmorClass",
                schema: "monster");
        }
    }
}
