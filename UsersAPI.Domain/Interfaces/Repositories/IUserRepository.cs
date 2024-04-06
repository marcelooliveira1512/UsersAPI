using UsersAPI.Domain.Entities;

namespace UsersAPI.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User, Guid>
    {
        List<User> GetAll();
        List<User> GetAll(Guid companyId);
        User? GetById(Guid id);
        User? GetByCompanyId(Guid companyId);
        User? GetByRoleId(Guid roleId);
    }
}
