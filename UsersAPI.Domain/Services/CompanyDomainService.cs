﻿using UsersAPI.Domain.Entities;
using UsersAPI.Domain.Exceptions;
using UsersAPI.Domain.Interfaces.Repositories;
using UsersAPI.Domain.Interfaces.Services;
using UsersAPI.Domain.Validations;

namespace UsersAPI.Domain.Services
{
    public class CompanyDomainService : ICompanyDomainService
    {
        private readonly IUnitOfWork? _unitOfWork;

        public CompanyDomainService(IUnitOfWork? unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Company company)
        {

            if (Get(company.Cnpj) != null)
                throw new CnpjAlreadyExistsException(company.Cnpj);

            if (!CnpjIValidation.IsCnpj(company.Cnpj))
                throw new CnpjIsNotValidException(company.Cnpj);

            if (company.CompanyType == "1")
            {
                var bytes = new Byte[16];
                company.ParentCompanyId = new Guid(bytes);
            } 
            else
            {
                if (Get(company.ParentCompanyId) == null)
                    throw new CompanyIsNotExistsException(company.ParentCompanyId);
            }

            _unitOfWork?.CompanyRepository.Add(company);
            _unitOfWork?.SaveChanges();
        }

        public void Update(Company company)
        {
            if (company.CompanyType == "1")
            {
                var bytes = new Byte[16];
                company.ParentCompanyId = new Guid(bytes);
            }
            else
            {
                if (Get(company.ParentCompanyId) == null)
                    throw new CompanyIsNotExistsException(company.ParentCompanyId);
            }

            _unitOfWork?.CompanyRepository.Update(company);
            _unitOfWork?.SaveChanges();
        }

        public void Delete(Company company)
        {
            if(_unitOfWork?.UserRepository.GetByCompanyId(company.Id) != null)
                throw new CompanyIsNotDeleteException(company.CompanyName);

            _unitOfWork?.CompanyRepository.Delete(company);
            _unitOfWork?.SaveChanges();
        }

        public List<Company> GetAll()
        {
            return _unitOfWork?.CompanyRepository.GetAll().ToList();
        }

        public Company? Get(Guid id)
        {
            return _unitOfWork?.CompanyRepository.GetById(id);
        }

        public Company? Get(string cnpj)
        {
            return _unitOfWork?.CompanyRepository.Get(c => c.Cnpj.Equals(cnpj));
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
