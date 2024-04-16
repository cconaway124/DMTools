using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Reflection.PortableExecutable;
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
    public DbSet<MonsterActions> MonsterActions { get; set; }
    public DbSet<ChallengeRating> ChallengeRating { get; set; }
    public DbSet<ConditionImmunity> ConditionImmunity { get; set; }
    public DbSet<DamageTypes> DamageTypes { get; set; }
    public DbSet<Languages> Languages { get; set; }
    public DbSet<Monster> Monster { get; set; }
    public DbSet<SavingThrows> SavingThrows { get; set; }
    public DbSet<Senses> Senses { get; set; }
    public DbSet<Skills> Skills { get; set; }
    public DbSet<Speeds> Speeds { get; set; }
    public DbSet<Stats> stats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string password = Environment.GetEnvironmentVariable("DbAdminPassword");
        if (password == null)
        {
            using (Stream stream = File.Open("C:\\Users\\chase\\Desktop\\dbPassword.txt", FileMode.Open))
            {
                StreamReader reader = new StreamReader(stream);
                password = reader.ReadToEnd();
                reader.Close();
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("No password");
            }
        }

        optionsBuilder.UseSqlServer($"Server=tcp:dmtoolsdbserver.database.windows.net,1433;Initial Catalog=dmtoolsdb;Persist Security Info=False;User ID=CloudSA044b5b56;Password={password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"); 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
