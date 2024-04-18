using AutoMapper;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;
using UsersAPI.Application.Interfaces.Application;
using UsersAPI.Domain.Entities;
using UsersAPI.Domain.Exceptions;
using UsersAPI.Domain.Interfaces.Services;

namespace UsersAPI.Application.Services
{
    public class CompanyAppService : ICompanyAppService
    {
        private readonly ICompanyDomainService _companyDomainService;
        private readonly IMapper? _mapper;

        public CompanyAppService(ICompanyDomainService companyDomainService, IMapper? mapper)
        {
            _companyDomainService = companyDomainService;
            _mapper = mapper;
        }

        public CompanyResponseDto Add(CompanyAddRequestDto dto)
        {
            try
            {
                var company = new Company
                {
                    Id = Guid.NewGuid(),
                    CompanyType = dto.CompanyType,
                    ParentCompanyId = dto.ParentCompanyId,
                    CompanyName = dto.CompanyName,
                    FantasyName = dto.FantasyName,
                    ImgLogo = dto.ImgLogo,
                    Cnpj = dto.Cnpj,
                    InscMunicipal = dto.InscMunicipal,
                    InscEstadual = dto.InscEstadual,
                    Cnae = dto.Cnae,
                    Crt = dto.Crt,
                    Email = dto.Email,
                    Url = dto.Url,
                    FoneNumber1 = dto.FoneNumber1,
                    FoneNumber2 = dto.FoneNumber2,
                    Zipcode = dto.Zipcode,
                    Address = dto.Address,
                    Complement = dto.Complement,
                    Number = dto.Number,
                    Neighbourhood = dto.Neighbourhood,
                    City = dto.City,
                    State = dto.State,
                    CreatedAt = DateTime.Now
                };

                _companyDomainService?.Add(company);
                return _mapper.Map<CompanyResponseDto>(company);

            }
            catch (CnpjAlreadyExistsException e)
            {
                throw new ApplicationException(e.Message);
            }
            catch (CnpjIsNotValidException e)
            {
                throw new ApplicationException(e.Message);
            }
            catch (CompanyIsNotExistsException e)
            {
                throw new ApplicationException(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception($"Error: {e.Message}, reporte ao Administrador do sistema o erro informado.");
            }
        }

        public CompanyResponseDto Update(Guid id, CompanyUpdateRequestDto dto)
        {
            try
            {
                var company = _companyDomainService?.Get(id);
                company.FantasyName = dto.FantasyName;
                company.ImgLogo = dto.ImgLogo;
                company.InscMunicipal = dto.InscMunicipal;
                company.InscEstadual = dto.InscEstadual;
                company.Cnae = dto.Cnae;
                company.Crt = dto.Crt;
                company.Email = dto.Email;
                company.Url = dto.Url;
                company.FoneNumber1 = dto.FoneNumber1;
                company.FoneNumber2 = dto.FoneNumber2;
                company.Zipcode = dto.Zipcode;
                company.Address = dto.Address;
                company.Complement = dto.Complement;
                company.Number = dto.Number;
                company.Neighbourhood = dto.Neighbourhood;
                company.City = dto.City;
                company.State = dto.State;

                _companyDomainService?.Update(company);

                return _mapper.Map<CompanyResponseDto>(company);
            }
            catch (CompanyIsNotExistsException e)
            {
                throw new ApplicationException(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception($"Error: {e.Message}, reporte ao Administrador do sistema o erro informado.");
            }

        }

        public CompanyResponseDto Delete(Guid id)
        {
            try
            {
                var company = _companyDomainService?.Get(id);

                _companyDomainService?.Delete(company);

                return _mapper.Map<CompanyResponseDto>(company);
            }
            catch (Exception e)
            {
                throw new Exception($"Error: {e.Message}, reporte ao Administrador do sistema o erro informado.");
            }
        }

        public List<CompanyResponseDto> GetAll()
        {
            var company = _companyDomainService?.GetAll().ToList();

            return _mapper.Map<List<CompanyResponseDto>>(company);
        }

        public CompanyResponseDto Get(Guid id)
        {
            var user = _companyDomainService?.Get(id);
            return _mapper.Map<CompanyResponseDto>(user);
        }

        public void Dispose()
        {
            _companyDomainService.Dispose();
        }
    }
}
