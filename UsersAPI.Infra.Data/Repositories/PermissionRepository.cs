using Microsoft.EntityFrameworkCore;
using UsersAPI.Domain.Entities;
using UsersAPI.Domain.Interfaces.Repositories;
using UsersAPI.Infra.Data.Contexts;

namespace UsersAPI.Infra.Data.Repositories
{
    public class PermissionRepository : BaseRepository<Permission, Guid>, IPermissionRepository
    {
        private readonly DataContext? _dataContext;

        public PermissionRepository(DataContext? dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Permission> GetAll()
        {
            return _dataContext.Permission.Include(r => r.Roles).Include(s => s.SubModules).ToList();
        }

        public Permission? Get(Guid subModuleId, Guid roleId)
        {
            return _dataContext?.Permission.Include(r => r.Roles).Include(s => s.SubModules).Where(p => p.SubModuleId == subModuleId && p.RoleId == roleId).FirstOrDefault();
        }

        public Permission? GetBySubModuleId(Guid subModuleId)
        {
            return _dataContext?.Permission.Include(r => r.Roles).Include(s => s.SubModules).Where(p => p.SubModuleId == subModuleId).FirstOrDefault();
        }
    }
}
