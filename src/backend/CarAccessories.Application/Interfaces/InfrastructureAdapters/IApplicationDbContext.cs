using CarAccessories.Domain.Common;
using CarAccessories.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CarAccessories.Application.Interfaces.InfrastructureAdapters;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Role> Roles { get; }
    DbSet<UserRole> UserRoles { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken);
    DbSet<TEntity> SetEntity<TEntity>() where TEntity : BaseEntity;
    IQueryable<TEntity> SetEntityNoTracking<TEntity>() where TEntity : BaseEntity;
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
}