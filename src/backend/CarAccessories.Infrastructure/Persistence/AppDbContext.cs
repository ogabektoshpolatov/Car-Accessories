using CarAccessories.Application.Interfaces.InfrastructureAdapters;
using CarAccessories.Domain.Common;
using CarAccessories.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CarAccessories.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options):DbContext(options), IApplicationDbContext
{
    // #region MyRegion
    // public DbSet<AuthUser> AuthUsers => Set<AuthUser>();
    // public DbSet<AuthRole> AuthRoles => Set<AuthRole>();
    // public DbSet<AuthUserRole> AuthUserRoles => Set<AuthUserRole>();
    // public DbSet<AuthUserRefreshToken> AuthUserRefreshTokens => Set<AuthUserRefreshToken>();
    // #endregion
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductImage> ProductImages => Set<ProductImage>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<CartItem> CartItems => Set<CartItem>();
    public DbSet<TEntity> SetEntity<TEntity>() where TEntity : BaseEntity => Set<TEntity>();
    public IQueryable<TEntity> SetEntityNoTracking<TEntity>() where TEntity : BaseEntity => Set<TEntity>().AsNoTracking();
    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default) => Database.BeginTransactionAsync(cancellationToken);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}