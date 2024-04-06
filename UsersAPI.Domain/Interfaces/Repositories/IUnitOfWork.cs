namespace UsersAPI.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository CompanyRepository { get; }
        IModuleRepository ModuleRepository { get; }
        IPermissionRepository PermissionRepository { get; }        
        IRoleRepository RoleRepository { get; }
        ISubModuleRepository SubModuleRepository { get; }
        IUserRepository UserRepository { get; }

        void SaveChanges();
    }
}
