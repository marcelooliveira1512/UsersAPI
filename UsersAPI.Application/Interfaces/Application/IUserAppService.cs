using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;
using UsersAPI.Domain.Entities;

namespace UsersAPI.Application.Interfaces.Application
{
    public interface IUserAppService : IDisposable
    {
        UserResponseDto Add(UserAddRequestDto dto);
        UserResponseDto Update(Guid id, UserUpdateRequestDto dto);
        UserResponseDto Delete(Guid id);
        List<UserResponseDto> GetAll();
        List<UserResponseDto> GetAll(Guid companyId);
        UserResponseDto Get(Guid id);
/*
        UserResponseDto? GetByCompanyId(Guid companyId);
        UserResponseDto? GetByRoleId(Guid roleId);
*/
    }
}
