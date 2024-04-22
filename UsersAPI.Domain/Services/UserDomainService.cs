using System.ComponentModel.Design;
using UsersAPI.Domain.Entities;
using UsersAPI.Domain.Exceptions;
using UsersAPI.Domain.Interfaces.Repositories;
using UsersAPI.Domain.Interfaces.Services;

namespace UsersAPI.Domain.Services
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUnitOfWork? _unitOfWork;

        public UserDomainService(IUnitOfWork? unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(User user)
        {
            if (Get(user.Email) != null)
                throw new EmailAlreadyExistsException(user.Email);

            if (_unitOfWork.CompanyRepository.GetById(user.CompanyId) == null)
                throw new CompanyIsNotExistsException(user.CompanyId);

            if (_unitOfWork.RoleRepository.GetById(user.RoleId) == null)
                throw new RoleIsNotExistsException(user.RoleId);

            _unitOfWork?.UserRepository.Add(user);
            _unitOfWork?.SaveChanges();
        }

        public void Update(User user)
        {
            if (GetByCompanyId(user.CompanyId) != null)
                throw new CompanyIsNotExistsException(user.CompanyId);

            if (GetByRoleId(user.RoleId) != null)
                throw new RoleIsNotExistsException(user.RoleId);

            _unitOfWork?.UserRepository.Update(user);
            _unitOfWork?.SaveChanges();
        }

        public void Delete(User user)
        {
            _unitOfWork?.UserRepository.Delete(user);
            _unitOfWork?.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _unitOfWork?.UserRepository.GetAll().ToList();
        }

        public List<User> GetAll(Guid companyId)
        {
            return _unitOfWork?.UserRepository.GetAll(companyId).ToList();
        }

        public User? Get(Guid id)
        {
            return _unitOfWork?.UserRepository.GetById(id);
        }

        public User? Get(string email)
        {
            return _unitOfWork?.UserRepository.Get(u => u.Email.Equals(email));
        }

        public User? Get(string email, string password)
        {
            return _unitOfWork?.UserRepository.Get(u => u.Email.Equals(email) && u.Password.Equals(password));
        }

        public User? GetByCompanyId(Guid companyId)
        {
            return _unitOfWork?.UserRepository.Get(u => u.CompanyId.Equals(companyId));
        }

        public User? GetByRoleId(Guid roleId)
        {
            return _unitOfWork?.UserRepository.Get(u => u.RoleId.Equals(roleId));
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
