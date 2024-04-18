using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersAPI.Domain.Entities;

namespace UsersAPI.Infra.Data.Mappings
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CompanyType).HasColumnType("char").HasMaxLength(1).IsRequired();
            builder.Property(c => c.ParentCompanyId).HasDefaultValue(Guid.Empty);
            builder.Property(c => c.Cnpj).HasMaxLength(14).IsRequired();
            builder.Property(c => c.CompanyName).HasMaxLength(100).IsRequired();
            builder.Property(c => c.FantasyName).HasMaxLength(100);
            builder.Property(c => c.ImgLogo).HasMaxLength(20);
            builder.Property(c => c.InscMunicipal).HasMaxLength(20);
            builder.Property(c => c.InscEstadual).HasMaxLength(20);
            builder.Property(c => c.Cnae).HasMaxLength(15);
            builder.Property(c => c.Crt).HasMaxLength(20);
            builder.Property(c => c.Email).HasMaxLength(80).IsRequired();
            builder.Property(c => c.Url).HasMaxLength(50);
            builder.Property(c => c.FoneNumber1).HasMaxLength(11).IsRequired();
            builder.Property(c => c.FoneNumber2).HasMaxLength(11);
            builder.Property(c => c.Zipcode).HasMaxLength(8).IsRequired();
            builder.Property(c => c.Address).HasMaxLength(70).IsRequired();
            builder.Property(c => c.Complement).HasMaxLength(30);
            builder.Property(c => c.Number).HasMaxLength(7).IsRequired();
            builder.Property(c => c.Neighbourhood).HasMaxLength(40).IsRequired();
            builder.Property(c => c.City).HasMaxLength(40).IsRequired();
            builder.Property(c => c.State).HasMaxLength(2).IsRequired();
            builder.Property(c => c.CreatedAt).IsRequired();

            builder.HasIndex(c => c.Cnpj).IsUnique();

            //mapeamento do relacionamento (1 para 1)
            builder.HasOne(c => c.User) //1 User TEM 1 Company
                .WithOne(c => c.Company) //1 Company TEM 1 User
                .HasForeignKey<User>(c => c.CompanyId); //definindo o campo CHAVE ESTRANGEIRA

        }
    }
}
