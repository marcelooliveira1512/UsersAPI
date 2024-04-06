using AutoMapper;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;
using UsersAPI.Application.Interfaces.Application;
using UsersAPI.Domain.Entities;
using UsersAPI.Domain.Interfaces.Services;
using UsersAPI.Domain.Services;

namespace UsersAPI.Application.Services
{
    public class PermissionAppService : IPermissionAppService
    {
        private readonly IPermissionDomainService? _permissionDomainService;
        private readonly IMapper? _mapper;

        public PermissionAppService(IPermissionDomainService? permissionDomainService, IMapper? mapper)
        {
            _permissionDomainService = permissionDomainService;
            _mapper = mapper;
        }

        public PermissionResponseDto Add(PermissionAddRequestDto dto)
        {
            var permission = new Permission
            {
                SubModuleId = dto.SubModuleId,
                RoleId = dto.RoleId,
                Create = dto.Create,
                Update = dto.Update, 
                Delete = dto.Delete,
                Read = dto.Read,
                CreatedAt = DateTime.Now
            };

            _permissionDomainService?.Add(permission);
            return _mapper.Map<PermissionResponseDto>(permission);
        }

        public PermissionResponseDto Update(Guid subModuleId, Guid roleId, PermissionUpdateRequestDto dto)
        {
            var permission = _permissionDomainService?.Get(subModuleId, roleId);
            permission.Create = dto.Create;
            permission.Update = dto.Update;
            permission.Delete = dto.Delete;
            permission.Read = dto.Read;


            _permissionDomainService?.Update(permission);

            return _mapper.Map<PermissionResponseDto>(permission);
        }

        public PermissionResponseDto Delete(Guid subModuleId, Guid roleId)
        {
            var permission = _permissionDomainService?.Get(subModuleId, roleId);

            _permissionDomainService?.Delete(permission);

            return _mapper.Map<PermissionResponseDto>(permission);

        }

        public List<PermissionResponseDto> GetAll()
        {
            var permissions = _permissionDomainService?.GetAll().ToList();
            return _mapper.Map<List<PermissionResponseDto>>(permissions);
        }

        public PermissionResponseDto? Get(Guid subModuleId, Guid roleId)
        {
            var permission = _permissionDomainService?.Get(subModuleId, roleId);
            return _mapper.Map<PermissionResponseDto>(permission);
        }

        public void Dispose()
        {
            _permissionDomainService.Dispose();
        }
    }
}
