using UsersAPI.Domain.Entities;
using UsersAPI.Domain.Exceptions;
using UsersAPI.Domain.Interfaces.Repositories;
using UsersAPI.Domain.Interfaces.Services;

namespace UsersAPI.Domain.Services
{
    public class SubModuleDomainService : ISubModuleDomainService
    {
        private readonly IUnitOfWork? _unitOfWork;

        public SubModuleDomainService(IUnitOfWork? unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(SubModule subModule)
        {
            if (Get(subModule.SubModuleName) != null)
                throw new SubModuleAlreadyExistsException(subModule.SubModuleName);

            _unitOfWork?.SubModuleRepository.Add(subModule);
            _unitOfWork?.SaveChanges();
        }

        public void Update(SubModule subModule)
        {
            _unitOfWork?.SubModuleRepository.Update(subModule);
            _unitOfWork?.SaveChanges();
        }

        public void Delete(SubModule subModule)
        {
            if (_unitOfWork?.PermissionRepository.GetBySubModuleId(subModule.Id) != null)
                throw new SubModuleIsNotDeleteException(subModule.SubModuleName);

            _unitOfWork?.SubModuleRepository.Delete(subModule);
            _unitOfWork?.SaveChanges();
        }

        public List<SubModule> GetAll()
        {
            return _unitOfWork?.SubModuleRepository.GetAll().ToList();
        }

        public List<SubModule> GetAll(Guid moduleId)
        {
            return _unitOfWork?.SubModuleRepository.GetAll(moduleId).ToList();
        }
        public SubModule? Get(string subModuleName)
        {
            return _unitOfWork?.SubModuleRepository.Get(s => s.SubModuleName.Equals(subModuleName));
        }

        public SubModule? GetById(Guid id)
        {
            return _unitOfWork?.SubModuleRepository.GetById(id);
        }

        public SubModule? GetByModuleId(Guid moduleId)
        {
            return _unitOfWork?.SubModuleRepository.GetByModuleId(moduleId);
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
