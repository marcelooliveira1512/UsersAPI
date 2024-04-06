using AutoMapper;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;
using UsersAPI.Application.Interfaces.Application;
using UsersAPI.Domain.Entities;
using UsersAPI.Domain.Interfaces.Services;
using UsersAPI.Domain.Services;

namespace UsersAPI.Application.Services
{
    public class RoleAppService : IRoleAppService
    {
        private readonly IRoleDomainService? _roleDomainService;
        private readonly IMapper? _mapper;

        public RoleAppService(IRoleDomainService? roleDomainService, IMapper? mapper)
        {
            _roleDomainService = roleDomainService;
            _mapper = mapper;
        }

        public RoleResponseDto Add(RoleAddRequestDto dto)
        {

            var role = new Role
            {
                Id = Guid.NewGuid(),
                RoleName = dto.RoleName,
                CreatedAt = DateTime.Now
            };

            _roleDomainService?.Add(role);
            return _mapper.Map<RoleResponseDto>(role);
        }
        public RoleResponseDto Update(Guid id, RoleUpdateRequestDto dto)
        {
            var role = _roleDomainService?.Get(id);
            role.RoleName = dto.RoleName;


            _roleDomainService?.Update(role);

            return _mapper.Map<RoleResponseDto>(role);
        }

        public RoleResponseDto Delete(Guid id)
        {
            var role = _roleDomainService?.Get(id);

            _roleDomainService?.Delete(role);

            return _mapper.Map<RoleResponseDto>(role);
        }

        public List<RoleResponseDto> GetAll()
        {
            var roles = _roleDomainService?.GetAll().ToList();
            return _mapper.Map<List<RoleResponseDto>>(roles);
        }

        public RoleResponseDto Get(Guid id)
        {
            var role = _roleDomainService?.Get(id);
            return _mapper.Map<RoleResponseDto>(role);
        }

        public void Dispose()
        {
            _roleDomainService.Dispose();
        }
    }
}
