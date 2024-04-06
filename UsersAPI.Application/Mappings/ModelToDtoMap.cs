using AutoMapper;
using UsersAPI.Application.Dtos.Responses;
using UsersAPI.Domain.Entities;

namespace UsersAPI.Application.Mappings
{
    public class ModelToDtoMap : Profile
    {
        public ModelToDtoMap()
        {
            CreateMap<Company, CompanyResponseDto>();

            CreateMap<Module, ModuleResponseDto>();

            CreateMap<Role, RoleResponseDto>();

            CreateMap<Permission, PermissionResponseDto>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Roles))
                .ForMember(dest => dest.SubModuleId, opt => opt.MapFrom(src => src.SubModules));

            CreateMap<SubModule, SubModuleResponseDto>()
                .ForMember(dest => dest.ModuleId, opt => opt.MapFrom(src => src.Module));

            CreateMap<User, UserResponseDto>()            
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName));
        }
    }
}
