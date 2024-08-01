
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Reflection.Emit;

using Taurob.Api.Domain.Entities;

namespace Taurob.Api.Infra.Data.Context;


public class TaurobDBContext : DbContext
{
    public TaurobDBContext(DbContextOptions<TaurobDBContext> options) : base(options)
    {
    }

    public DbSet<Robot> Robots { get; set; }
    public DbSet<Mission> Missions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        new RobotEntityTypeConfiguration().Configure(modelBuilder.Entity<Robot>());
        new MissionEntityTypeConfiguration().Configure(modelBuilder.Entity<Mission>());

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaurobDBContext).Assembly); base.OnModelCreating(modelBuilder);
    }


    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreateDateTime") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreateDateTime").CurrentValue = DateTime.Now;
                continue;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("CreateDateTime").IsModified = false;
                entry.Property("UpdateDateTime").CurrentValue = DateTime.Now;
            }
        }

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreateDateTime") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreateDateTime").CurrentValue = DateTime.Now;
                continue;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("CreateDateTime").IsModified = false;
                entry.Property("UpdateDateTime").CurrentValue = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }


}