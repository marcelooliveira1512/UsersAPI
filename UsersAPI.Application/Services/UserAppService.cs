using AutoMapper;
using System.ComponentModel.Design;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;
using UsersAPI.Application.Interfaces.Application;
using UsersAPI.Domain.Entities;
using UsersAPI.Domain.Exceptions;
using UsersAPI.Domain.Interfaces.Services;

namespace UsersAPI.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserDomainService? _userDomainService;
        private readonly IMapper? _mapper;

        public UserAppService(IUserDomainService? userDomainService, IMapper? mapper)
        {
            _userDomainService = userDomainService;
            _mapper = mapper;
        }

        public UserResponseDto Add(UserAddRequestDto dto)
        {
            try
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    CompanyId = dto.CompanyId,
                    RoleId = dto.RoleId,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    Password = dto.Password,
                    Active = true,
                    EmailConfirmed = false,
                    CreatedAt = DateTime.Now
                };

                _userDomainService?.Add(user);
                return _mapper.Map<UserResponseDto>(user);
            }
            catch(EmailAlreadyExistsException e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public UserResponseDto Update(Guid id, UserUpdateRequestDto dto)
        {
            var user = _userDomainService?.Get(id);
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Active = dto.Active;
            user.EmailConfirmed = dto.EmailConfirmed;

            _userDomainService?.Update(user);

            return _mapper.Map<UserResponseDto>(user);
        }

        public UserResponseDto Delete(Guid id)
        {
            var user = _userDomainService?.Get(id);
            _userDomainService?.Delete(user);

            return _mapper.Map<UserResponseDto>(user);
        }
        
        public List<UserResponseDto> GetAll()
        {
            
            var users = _userDomainService?.GetAll().ToList();
            return _mapper.Map<List<UserResponseDto>>(users);
        }

        public List<UserResponseDto> GetAll(Guid companyId)
        {
            
            var users = _userDomainService?.GetAll(companyId).ToList();
            return _mapper.Map<List<UserResponseDto>>(users);
        }

        public UserResponseDto Get(Guid id)
        {
            var user = _userDomainService?.Get(id);
            return _mapper.Map<UserResponseDto>(user);
        }

        public void Dispose()
        {
            _userDomainService?.Dispose();
        }
    }
}
