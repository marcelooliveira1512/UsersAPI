using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using UsersAPI.Domain.Entities;
using UsersAPI.Domain.Interfaces.Repositories;
using UsersAPI.Infra.Data.Contexts;

namespace UsersAPI.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {
        private readonly DataContext? _dataContext;

        public UserRepository(DataContext? dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public List<User> GetAll()
        {
            return _dataContext.User.Include(c => c.Company).Include(r => r.Role).ToList();
        }

        public List<User> GetAll(Guid companyId)
        {
            return _dataContext.User.Include(c => c.Company).Include(r => r.Role).Where(u => u.CompanyId.Equals(companyId)).ToList();
        }

        public User GetById(Guid id)
        {
            return _dataContext?.User.Include(c => c.Company).Include(r => r.Role).Where(u => u.Id.Equals(id)).FirstOrDefault();
        }

        public User? GetByCompanyId(Guid companyId)
        {
            return _dataContext?.Set<User>().FirstOrDefault(u => u.CompanyId.Equals(companyId));
        }

        public User? GetByRoleId(Guid roleId)
        {
            return _dataContext?.Set<User>().FirstOrDefault(u => u.RoleId.Equals(roleId));
        }
    }
}
