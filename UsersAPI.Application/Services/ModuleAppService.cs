using AutoMapper;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;
using UsersAPI.Application.Interfaces.Application;
using UsersAPI.Domain.Entities;
using UsersAPI.Domain.Interfaces.Services;
using UsersAPI.Domain.Services;

namespace UsersAPI.Application.Services
{
    public class ModuleAppService : IModuleAppService
    {
        private readonly IModuleDomainService? _moduleDomainService;
        private readonly IMapper? _mapper;

        public ModuleAppService(IModuleDomainService? moduleDomainService, IMapper? mapper)
        {
            _moduleDomainService = moduleDomainService;
            _mapper = mapper;
        }

        public ModuleResponseDto Add(ModuleAddRequestDto dto)
        {
            var module = new Module
            {
                Id = Guid.NewGuid(),
                ModuleName = dto.ModuleName,
                CreatedAt = DateTime.Now
            };

            _moduleDomainService?.Add(module);
            return _mapper.Map<ModuleResponseDto>(module);
        }

        public ModuleResponseDto Update(Guid id, ModuleUpdateRequestDto dto)
        {
            var module = _moduleDomainService?.Get(id);
            module.ModuleName = dto.ModuleName;


            _moduleDomainService?.Update(module);

            return _mapper.Map<ModuleResponseDto>(module);
        }

        public ModuleResponseDto Delete(Guid id)
        {
            var module = _moduleDomainService?.Get(id);

            _moduleDomainService?.Delete(module);

            return _mapper.Map<ModuleResponseDto>(module);
        }

        public List<ModuleResponseDto> GetAll()
        {
            var modules = _moduleDomainService?.GetAll().ToList();
            return _mapper.Map<List<ModuleResponseDto>>(modules);
        }

        public ModuleResponseDto Get(Guid id)
        {
            var module = _moduleDomainService?.Get(id);
            return _mapper.Map<ModuleResponseDto>(module);
        }

        public void Dispose()
        {
            _moduleDomainService?.Dispose();
        }
    }
}
