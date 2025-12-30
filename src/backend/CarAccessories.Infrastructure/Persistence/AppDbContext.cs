using CarAccessories.Application.Interfaces.InfrastructureAdapters;
using CarAccessories.Domain.Common;
using CarAccessories.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarAccessories.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options):DbContext(options), IApplicationDbContext
{
    // #region MyRegion
    // public DbSet<AuthUser> AuthUsers => Set<AuthUser>();
    // public DbSet<AuthRole> AuthRoles => Set<AuthRole>();
    // public DbSet<AuthUserRole> AuthUserRoles => Set<AuthUserRole>();
    // public DbSet<AuthUserRefreshToken> AuthUserRefreshTokens => Set<AuthUserRefreshToken>();
    // #endregion
    public DbSet<MediaFile> MediaFiles => Set<MediaFile>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<CartItem> CartItems => Set<CartItem>();
    public DbSet<TEntity> SetEntity<TEntity>() where TEntity : BaseEntity => Set<TEntity>();
    public IQueryable<TEntity> SetEntityNoTracking<TEntity>() where TEntity : BaseEntity => Set<TEntity>().AsNoTracking();
    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default) => Database.BeginTransactionAsync(cancellationToken);
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseAuditableEntity && 
                        (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            var entity = (BaseAuditableEntity)entityEntry.Entity;
        
            if (entityEntry.State == EntityState.Added)
            {
                entity.Created = DateTimeOffset.UtcNow;
            }
        
            entity.LastModified = DateTimeOffset.UtcNow;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        
        modelBuilder.Entity<Product>()
            .Property(x => x.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Product>()
            .Property(x => x.OldPrice)
            .HasPrecision(18, 2);

        modelBuilder.Entity<CartItem>()
            .Property(x => x.Price)
            .HasPrecision(18, 2);
        
        modelBuilder.Entity<Category>()
            .HasMany(e => e.Children)
            .WithOne(e => e.Parent)
            .HasForeignKey(e => e.ParentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(DateTimeOffset)
                                                                               || p.PropertyType == typeof(DateTimeOffset?));
                foreach (var property in properties)
                {
                    modelBuilder
                        .Entity(entityType.Name)
                        .Property(property.Name)
                        .HasConversion(new DateTimeOffsetToBinaryConverter());
                }
            }
        }

    }
}