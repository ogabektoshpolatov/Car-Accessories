using CarAccessories.Application.Interfaces.InfrastructureAdapters;
using CarAccessories.Domain.Common;
using CarAccessories.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CarAccessories.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options):DbContext(options), IApplicationDbContext
{
    public DbSet<AuthUser> AuthUsers => Set<AuthUser>();
    public DbSet<AuthRole> AuthRoles => Set<AuthRole>();
    public DbSet<AuthUserRole> AuthUserRoles => Set<AuthUserRole>();
    public DbSet<AuthUserRefreshToken> AuthUserRefreshTokens => Set<AuthUserRefreshToken>();
    public DbSet<TEntity> SetEntity<TEntity>() where TEntity : BaseEntity => Set<TEntity>();
    public IQueryable<TEntity> SetEntityNoTracking<TEntity>() where TEntity : BaseEntity => Set<TEntity>().AsNoTracking();
    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default) => Database.BeginTransactionAsync(cancellationToken);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}