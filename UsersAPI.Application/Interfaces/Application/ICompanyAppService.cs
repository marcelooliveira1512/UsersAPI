using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;

namespace UsersAPI.Application.Interfaces.Application
{
    public interface ICompanyAppService : IDisposable
    {
        CompanyResponseDto Add(CompanyAddRequestDto dto);
        CompanyResponseDto Update(Guid id, CompanyUpdateRequestDto dto);
        CompanyResponseDto Delete(Guid id);
        List<CompanyResponseDto> GetAll();
        CompanyResponseDto Get(Guid id);
    }
}
