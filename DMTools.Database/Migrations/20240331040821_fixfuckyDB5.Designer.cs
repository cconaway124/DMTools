﻿// <auto-generated />
using System;
using DMTools.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DMTools.Database.Migrations
{
    [DbContext(typeof(DmtoolsContext))]
    [Migration("20240331040821_fixfuckyDB5")]
    partial class fixfuckyDB5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DMTools.Database.Entities.AC", b =>
                {
                    b.Property<int>("AcId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AcId"));

                    b.Property<int>("AllowsDexMod")
                        .HasColumnType("int");

                    b.Property<string>("ArmorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MonsterId")
                        .HasColumnType("int");

                    b.HasKey("AcId");

                    b.HasIndex("MonsterId")
                        .IsUnique();

                    b.ToTable("ArmorClass", "monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.ChallengeRating", b =>
                {
                    b.Property<int>("ChallengeRatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChallengeRatingId"));

                    b.Property<string>("Cr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomCr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MonsterId")
                        .HasColumnType("int");

                    b.Property<string>("Xp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChallengeRatingId");

                    b.HasIndex("MonsterId")
                        .IsUnique();

                    b.ToTable("ChallengeRating", "monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.ConditionImmunity", b =>
                {
                    b.Property<int>("ConditionImmunityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConditionImmunityId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MonsterId")
                        .HasColumnType("int");

                    b.HasKey("ConditionImmunityId");

                    b.HasIndex("MonsterId");

                    b.ToTable("ConditionImmunity", "monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.DamageTypes", b =>
                {
                    b.Property<int>("DamageTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DamageTypeId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MonsterId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("DamageTypeId");

                    b.HasIndex("MonsterId");

                    b.ToTable("DamageTypes", "monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.HitDie", b =>
                {
                    b.Property<int>("HitDieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HitDieId"));

                    b.Property<int>("AverageHp")
                        .HasColumnType("int");

                    b.Property<string>("ConMod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("HitDieType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MonsterId")
                        .HasColumnType("int");

                    b.HasKey("HitDieId");

                    b.HasIndex("MonsterId")
                        .IsUnique();

                    b.ToTable("HitDie", "monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.Languages", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LanguageId"));

                    b.Property<int>("LanguageLevel")
                        .HasColumnType("int");

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MonsterId")
                        .HasColumnType("int");

                    b.Property<string>("UnderstandsBut")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageId");

                    b.HasIndex("MonsterId");

                    b.ToTable("Languages", "monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.Monster", b =>
                {
                    b.Property<int>("MonsterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MonsterId"));

                    b.Property<string>("Alignment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomCr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CustomHp")
                        .HasColumnType("bit");

                    b.Property<bool>("CustomSpeed")
                        .HasColumnType("bit");

                    b.Property<bool>("DoubleColumns")
                        .HasColumnType("bit");

                    b.Property<int>("HitPoints")
                        .HasColumnType("int");

                    b.Property<bool>("IsCustomCr")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLair")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLegendary")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMythic")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRegional")
                        .HasColumnType("bit");

                    b.Property<string>("LairDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LairDescriptionEnd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LegendariesDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MythicDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PluralName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfBonus")
                        .HasColumnType("int");

                    b.Property<string>("RegionalDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionalDescriptionEnd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeparationPoint")
                        .HasColumnType("int");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserGuid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MonsterId");

                    b.ToTable("Monster", "monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.MonsterActions", b =>
                {
                    b.Property<int>("MonsterActionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MonsterActionId"));

                    b.Property<string>("ActionDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ActionType")
                        .HasColumnType("int");

                    b.Property<int>("MonsterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MonsterActionId");

                    b.HasIndex("MonsterId");

                    b.ToTable("MonsterActions", "monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.SavingThrows", b =>
                {
                    b.Property<int>("SavingThrowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SavingThrowId"));

                    b.Property<int?>("Cha")
                        .HasColumnType("int");

                    b.Property<int?>("Con")
                        .HasColumnType("int");

                    b.Property<int?>("Dex")
                        .HasColumnType("int");

                    b.Property<int?>("Int")
                        .HasColumnType("int");

                    b.Property<int>("MonsterId")
                        .HasColumnType("int");

                    b.Property<int>("ProfBonus")
                        .HasColumnType("int");

                    b.Property<int?>("Str")
                        .HasColumnType("int");

                    b.Property<int?>("Wis")
                        .HasColumnType("int");

                    b.HasKey("SavingThrowId");

                    b.HasIndex("MonsterId")
                        .IsUnique();

                    b.ToTable("SavingThrows", "monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.Senses", b =>
                {
                    b.Property<int>("SenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SenseId"));

                    b.Property<bool>("Blind")
                        .HasColumnType("bit");

                    b.Property<int?>("BlindSight")
                        .HasColumnType("int");

                    b.Property<int?>("Darkvision")
                        .HasColumnType("int");

                    b.Property<int>("MonsterId")
                        .HasColumnType("int");

                    b.Property<int>("PassivePerception")
                        .HasColumnType("int");

                    b.Property<int?>("Telepathy")
                        .HasColumnType("int");

                    b.Property<int?>("Tremorsense")
                        .HasColumnType("int");

                    b.Property<int?>("Truesight")
                        .HasColumnType("int");

                    b.HasKey("SenseId");

                    b.HasIndex("MonsterId")
                        .IsUnique();

                    b.ToTable("Senses", "monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.Skills", b =>
                {
                    b.Property<int>("SkillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillId"));

                    b.Property<int>("Bonus")
                        .HasColumnType("int");

                    b.Property<int>("MonsterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkillId");

                    b.HasIndex("MonsterId");

                    b.ToTable("Skills", "monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.Speeds", b =>
                {
                    b.Property<int>("SpeedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpeedId"));

                    b.Property<int?>("Burrow")
                        .HasColumnType("int");

                    b.Property<int?>("Climb")
                        .HasColumnType("int");

                    b.Property<int?>("Fly")
                        .HasColumnType("int");

                    b.Property<bool?>("Hover")
                        .HasColumnType("bit");

                    b.Property<int>("MonsterId")
                        .HasColumnType("int");

                    b.Property<int?>("Speed")
                        .HasColumnType("int");

                    b.Property<int?>("Swim")
                        .HasColumnType("int");

                    b.HasKey("SpeedId");

                    b.HasIndex("MonsterId")
                        .IsUnique();

                    b.ToTable("Speeds", "monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.Stats", b =>
                {
                    b.Property<int>("StatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatId"));

                    b.Property<int>("Cha")
                        .HasColumnType("int");

                    b.Property<int>("Con")
                        .HasColumnType("int");

                    b.Property<int>("Dex")
                        .HasColumnType("int");

                    b.Property<int>("Int")
                        .HasColumnType("int");

                    b.Property<int>("MonsterId")
                        .HasColumnType("int");

                    b.Property<int>("Str")
                        .HasColumnType("int");

                    b.Property<int>("Wis")
                        .HasColumnType("int");

                    b.HasKey("StatId");

                    b.HasIndex("MonsterId")
                        .IsUnique();

                    b.ToTable("Stats", "monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("UserGuid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DMTools.Database.Entities.AC", b =>
                {
                    b.HasOne("DMTools.Database.Entities.Monster", "Monster")
                        .WithOne("ArmorClass")
                        .HasForeignKey("DMTools.Database.Entities.AC", "MonsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.ChallengeRating", b =>
                {
                    b.HasOne("DMTools.Database.Entities.Monster", "Monster")
                        .WithOne("Cr")
                        .HasForeignKey("DMTools.Database.Entities.ChallengeRating", "MonsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.ConditionImmunity", b =>
                {
                    b.HasOne("DMTools.Database.Entities.Monster", "Monster")
                        .WithMany("ConditionImmunity")
                        .HasForeignKey("MonsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.DamageTypes", b =>
                {
                    b.HasOne("DMTools.Database.Entities.Monster", "Monster")
                        .WithMany("DamageTypes")
                        .HasForeignKey("MonsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.HitDie", b =>
                {
                    b.HasOne("DMTools.Database.Entities.Monster", "Monster")
                        .WithOne("HitDie")
                        .HasForeignKey("DMTools.Database.Entities.HitDie", "MonsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.Languages", b =>
                {
                    b.HasOne("DMTools.Database.Entities.Monster", "Monster")
                        .WithMany("Languages")
                        .HasForeignKey("MonsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.MonsterActions", b =>
                {
                    b.HasOne("DMTools.Database.Entities.Monster", "Monster")
                        .WithMany()
                        .HasForeignKey("MonsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.SavingThrows", b =>
                {
                    b.HasOne("DMTools.Database.Entities.Monster", "Monster")
                        .WithOne("Sthrows")
                        .HasForeignKey("DMTools.Database.Entities.SavingThrows", "MonsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.Senses", b =>
                {
                    b.HasOne("DMTools.Database.Entities.Monster", "Monster")
                        .WithOne("Senses")
                        .HasForeignKey("DMTools.Database.Entities.Senses", "MonsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.Skills", b =>
                {
                    b.HasOne("DMTools.Database.Entities.Monster", "Monster")
                        .WithMany("Mskills")
                        .HasForeignKey("MonsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.Speeds", b =>
                {
                    b.HasOne("DMTools.Database.Entities.Monster", "Monster")
                        .WithOne("Speeds")
                        .HasForeignKey("DMTools.Database.Entities.Speeds", "MonsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.Stats", b =>
                {
                    b.HasOne("DMTools.Database.Entities.Monster", "Monster")
                        .WithOne("Stats")
                        .HasForeignKey("DMTools.Database.Entities.Stats", "MonsterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monster");
                });

            modelBuilder.Entity("DMTools.Database.Entities.Monster", b =>
                {
                    b.Navigation("ArmorClass")
                        .IsRequired();

                    b.Navigation("ConditionImmunity");

                    b.Navigation("Cr")
                        .IsRequired();

                    b.Navigation("DamageTypes");

                    b.Navigation("HitDie")
                        .IsRequired();

                    b.Navigation("Languages");

                    b.Navigation("Mskills");

                    b.Navigation("Senses")
                        .IsRequired();

                    b.Navigation("Speeds")
                        .IsRequired();

                    b.Navigation("Stats")
                        .IsRequired();

                    b.Navigation("Sthrows")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
