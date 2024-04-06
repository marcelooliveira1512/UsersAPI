using Microsoft.EntityFrameworkCore;
using UsersAPI.Domain.Entities;
using UsersAPI.Infra.Data.Mappings;

namespace UsersAPI.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        //método construtor
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        //adicionando as configurações de modelos de entidade do banco de dados (ORM)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new ModuleMap());
            modelBuilder.ApplyConfiguration(new PermissionMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new SubModuleMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //mapeando os modelos de domínio deste contexto 
        public DbSet<Company> Company { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<SubModule> SubModule { get; set; }
        public DbSet<User> User { get; set; }
    }
}
