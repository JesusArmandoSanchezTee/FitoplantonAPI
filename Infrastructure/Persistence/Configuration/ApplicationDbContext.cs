using System.Reflection;
using Application.Interfaces;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.Configuration;

public class ApplicationDbContext : DbContext
{
    private readonly IDateTimeService _dateTimeService;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTimeService) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        _dateTimeService = dateTimeService;
    }
    
    public DbSet<Species> Species { get; set; }
    public DbSet<ClasificationSpecies> ClasificationSpecies { get; set; }
    public DbSet<CommonNames> CommonNames { get; set; }
    public DbSet<Detail> Details { get; set; }
    public DbSet<Family> Families { get; set; }
    public DbSet<LocationSpecies> LocationSpecies { get; set; }
    public DbSet<PlantonInventory> PlantonInventory { get; set; }
    public DbSet<References> References { get; set; }
    public DbSet<Synonyms> Synonyms { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableBaseEntry>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = _dateTimeService.NowUtc;
                    break;
                case EntityState.Modified:
                    entry.Entity.Modified = _dateTimeService.NowUtc;
                    break;
            }
        }
        
        return await base.SaveChangesAsync(cancellationToken);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the entity properties, relationships, etc.
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}