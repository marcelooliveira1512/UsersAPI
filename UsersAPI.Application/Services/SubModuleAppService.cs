using AutoMapper;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;
using UsersAPI.Application.Interfaces.Application;
using UsersAPI.Domain.Entities;
using UsersAPI.Domain.Interfaces.Services;

namespace UsersAPI.Application.Services
{
    public class SubModuleAppService : ISubModuleAppService
    {
        private readonly ISubModuleDomainService? _subModuleDomainService;
        private readonly IMapper? _mapper;

        public SubModuleAppService(ISubModuleDomainService? subModuleDomainService, IMapper? mapper)
        {
            _subModuleDomainService = subModuleDomainService;
            _mapper = mapper;
        }

        public SubModuleResponseDto Add(SubModuleAddRequestDto dto)
        {
            var subModule = new SubModule
            {
                Id = Guid.NewGuid(),
                SubModuleName = dto.SubModuleName,
                CreatedAt = DateTime.Now
            };

            _subModuleDomainService?.Add(subModule);
            return _mapper.Map<SubModuleResponseDto>(subModule);
        }

        public SubModuleResponseDto Update(Guid id, SubModuleUpdateRequestDto dto)
        {
            var subModule = _subModuleDomainService?.GetById(id);
            subModule.SubModuleName = dto.SubModuleName;


            _subModuleDomainService?.Update(subModule);

            return _mapper.Map<SubModuleResponseDto>(subModule);
        }

        public SubModuleResponseDto Delete(Guid id)
        {
            var subModule = _subModuleDomainService?.GetById(id);

            _subModuleDomainService?.Delete(subModule);

            return _mapper.Map<SubModuleResponseDto>(subModule);
        }

        public List<SubModuleResponseDto> GetAll()
        {
            var subModules = _subModuleDomainService?.GetAll().ToList();
            return _mapper.Map<List<SubModuleResponseDto>>(subModules);
        }

        public List<SubModuleResponseDto> GetAll(Guid moduleId)
        {
            var subModules = _subModuleDomainService?.GetAll(moduleId).ToList();
            return _mapper.Map<List<SubModuleResponseDto>>(subModules);
        }

        public SubModuleResponseDto Get(Guid id)
        {
            var subModule = _subModuleDomainService?.GetById(id);
            return _mapper.Map<SubModuleResponseDto>(subModule);
        }

        public void Dispose()
        {
            _subModuleDomainService?.Dispose();
        }
    }
}
