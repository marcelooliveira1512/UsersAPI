using UsersAPI.Domain.Entities;

namespace UsersAPI.Domain.Interfaces.Services
{
    public interface IUserDomainService : IDisposable
    {
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        List<User> GetAll();
        List<User> GetAll(Guid companyId);
        User? Get(Guid id);
        User? Get(string email);
        User? Get(string email, string password);
    }
}
