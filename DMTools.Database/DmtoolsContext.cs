using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using DMTools.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace DMTools.Database;

public partial class DmtoolsContext : DbContext
{
    public DmtoolsContext()
    {
    }

    public DmtoolsContext(DbContextOptions<DmtoolsContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<AC> ArmorClass { get; set; }
    public DbSet<Actions> Actions { get; set; }
    public DbSet<ChallengeRating> ChallengeRating { get; set; }
    public DbSet<ConditionImmunity> ConditionImmunity { get; set; }
    public DbSet<DamageTypes> DamageTypes { get; set; }
    public DbSet<Languages> Languages { get; set; }
    public DbSet<Monster> Monster { get; set; }
    public DbSet<Monsters_ConditionImmunity> Monsters_x_ConditionImmunity { get; set; }
    public DbSet<SavingThrows> SavingThrows { get; set; }
    public DbSet<Senses> Senses { get; set; }
    public DbSet<Skills> Skills { get; set; }
    public DbSet<Speeds> Speeds { get; set; }
    public DbSet<Stats> stats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:dmtools-dbserver.database.windows.net,1433;Initial Catalog=DMTools;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=\"Active Directory Default\";");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
