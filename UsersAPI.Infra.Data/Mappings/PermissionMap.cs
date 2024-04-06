using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersAPI.Domain.Entities;

namespace UsersAPI.Infra.Data.Mappings
{
    public class PermissionMap : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(p => new { p.RoleId, p.SubModuleId});

            builder.Property(p => p.Create).HasColumnType("bit");
            builder.Property(p => p.Update).HasColumnType("bit");
            builder.Property(p => p.Delete).HasColumnType("bit");
            builder.Property(p => p.Read).HasColumnType("bit");

            //mapeamento do relacionamento (N para N)
            builder.HasMany(p => p.SubModules) // N SubModules tem N Permissions
                .WithMany(p => p.Permissions); // N Permissions tem N SubModules

            builder.HasMany(p => p.Roles) // N Roles tem N Permissions
                .WithMany(p => p.Permissions); // N Permissions tem N Roles

        }
    }
}
