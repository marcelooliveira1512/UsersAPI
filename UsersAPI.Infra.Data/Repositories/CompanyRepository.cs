using UsersAPI.Domain.Entities;
using UsersAPI.Domain.Interfaces.Repositories;
using UsersAPI.Infra.Data.Contexts;

namespace UsersAPI.Infra.Data.Repositories
{
    public class CompanyRepository : BaseRepository<Company, Guid>, ICompanyRepository
    {
        private readonly DataContext? _dataContext;

        public CompanyRepository(DataContext? dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Company> GetAll()
        {
            return _dataContext.Set<Company>().ToList();
        }
    }
}
