using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;

namespace UsersAPI.Application.Interfaces.Application
{
    public interface IPermissionAppService : IDisposable
    {
        PermissionResponseDto Add(PermissionAddRequestDto dto);
        PermissionResponseDto Update(Guid subModuleId, Guid roleId, PermissionUpdateRequestDto dto);
        PermissionResponseDto Delete(Guid subModuleId, Guid roleId);
        List<PermissionResponseDto> GetAll();
        PermissionResponseDto? Get(Guid subModuleId, Guid roleId);
    }
}
