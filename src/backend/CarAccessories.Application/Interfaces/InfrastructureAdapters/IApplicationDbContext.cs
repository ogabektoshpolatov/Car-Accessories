using CarAccessories.Domain.Common;
using CarAccessories.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace CarAccessories.Application.Interfaces.InfrastructureAdapters;

public interface IApplicationDbContext
{
    // #region Auth
    // DbSet<AuthUser> AuthUsers { get; }
    // DbSet<AuthRole> AuthRoles { get; }
    // DbSet<AuthUserRole> AuthUserRoles { get; }
    // DbSet<AuthUserRefreshToken> AuthUserRefreshTokens { get; }
    // #endregion
    DbSet<Product> Products { get; }
    DbSet<ProductImage> ProductImages { get; }
    public DbSet<Category> Categories { get; }
    public DbSet<Cart> Carts { get; }
    public DbSet<CartItem> CartItems { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken);
    DbSet<TEntity> SetEntity<TEntity>() where TEntity : BaseEntity;
    IQueryable<TEntity> SetEntityNoTracking<TEntity>() where TEntity : BaseEntity;
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
}