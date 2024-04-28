﻿using System.ComponentModel.Design;
using UsersAPI.Domain.Entities;
using UsersAPI.Domain.Exceptions;
using UsersAPI.Domain.Interfaces.Messages;
using UsersAPI.Domain.Interfaces.Repositories;
using UsersAPI.Domain.Interfaces.Services;
using UsersAPI.Domain.ValueObjects;

namespace UsersAPI.Domain.Services
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUnitOfWork? _unitOfWork;
        private readonly IUserMessageProducer? userMessageProducer;

        public UserDomainService(IUnitOfWork? unitOfWork, IUserMessageProducer? userMessageProducer)
        {
            _unitOfWork = unitOfWork;
            this.userMessageProducer = userMessageProducer;
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

            userMessageProducer?.Send(new UserMessageVO
            {
                Id = user.Id,
                SendedAt = DateTime.Now,
                To = user.Email,
                Subject = "Parabéns, sua conta de usuário foi criado com sucesso",
                Body = @$"Olá {user.FirstName}, clique no link abaixo para ativar seu Usuário em nosso sistema.<br><a href='http://ativarcadastro.com?{user.Id}'>Clique aqui para ativar seu usuário</a>"
            });
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
