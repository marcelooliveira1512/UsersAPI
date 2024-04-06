using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersAPI.Domain.Entities;

namespace UsersAPI.Infra.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.CompanyId).IsRequired();
            builder.Property(u => u.RoleId).IsRequired();
            builder.Property(u => u.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(80).IsRequired();
            builder.Property(u => u.Password).HasMaxLength(40).IsRequired();
            builder.Property(u => u.Active).HasColumnType("bit").IsRequired();
            builder.Property(u => u.EmailConfirmed).HasColumnType("bit").IsRequired();
            builder.Property(u => u.CreatedAt).IsRequired();

            builder.HasIndex(u => u.Email).IsUnique();

            
            //mapeamento do relacionamento (1 para 1)
            builder.HasOne(u => u.Role) //1 User TEM 1 Role
                .WithOne(u => u.User) //1 Role TEM 1 User
                .HasForeignKey<User>(u => u.RoleId); //definindo o campo CHAVE ESTRANGEIRA

            //mapeamento do relacionamento (1 para 1)
            builder.HasOne(u => u.Company) //1 User TEM 1 Company
                .WithOne(u => u.User) //1 Company TEM 1 User
                .HasForeignKey<User>(u => u.CompanyId); //definindo o campo CHAVE ESTRANGEIRA
        }
    }
}
