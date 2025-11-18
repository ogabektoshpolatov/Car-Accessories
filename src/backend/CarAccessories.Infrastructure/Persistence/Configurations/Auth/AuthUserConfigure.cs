using CarAccessories.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarAccessories.Infrastructure.Persistence.Configurations.Auth;

public class AuthUserConfigure:IEntityTypeConfiguration<AuthUserRole>
{
    public void Configure(EntityTypeBuilder<AuthUserRole> builder)
    {
        builder.HasKey(ur => ur.Id);

        builder.HasOne(ur => ur.AuthUser)
            .WithMany(u => u.AuthUserRoles)
            .HasForeignKey(ur => ur.UserId);

        builder.HasOne(ur => ur.AuthRole)
            .WithMany(r => r.AuthUserRoles)
            .HasForeignKey(ur => ur.RoleId);
    }
}