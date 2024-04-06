using UsersAPI.Domain.Entities;

namespace UsersAPI.Domain.Interfaces.Services
{
    public interface ICompanyDomainService : IDisposable
    {
        void Add(Company company);
        void Update(Company company);
        void Delete(Company company);
        List<Company> GetAll();        
        Company? Get(Guid id);
        Company? Get(string cnpj);
    }
}
