using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Domain.Entities;

namespace UsersAPI.Infra.Data.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.RoleName).HasMaxLength(50).IsRequired();
            builder.Property(r => r.CreatedAt).IsRequired();

            //mapeamento do relacionamento (1 para 1)
            builder.HasOne(r => r.User) //1 Role TEM 1 User
                .WithOne(r => r.Role) // 1 User TEM 1 Role
                .HasForeignKey<User>(r => r.RoleId); //definindo o campo CHAVE ESTRANGEIRA

            //mapeamento do relacionamento (N para N)
            builder.HasMany(r => r.Permissions) // N Permissions tem N Roles
                .WithMany(r => r.Roles); // N Roles tem N Permissions

        }
    }
}
