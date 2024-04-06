using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;
using UsersAPI.Application.Interfaces.Application;

namespace UsersAPI.Services.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanysController : ControllerBase
    {
        private readonly ICompanyAppService? _companyAppService;

        public CompanysController(ICompanyAppService? companyAppService)
        {
            _companyAppService = companyAppService;
        }

        /// <summary>
        /// Cadastrar uma nova empresa
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Add([FromBody] CompanyAddRequestDto dto)
        {
            return StatusCode(201, _companyAppService?.Add(dto));
        }

        /// <summary>
        /// Alterar os dados da empresa informada
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Edit(Guid id, CompanyUpdateRequestDto dto)
        {
            return StatusCode(200, _companyAppService?.Update(id, dto));
        }

        /// <summary>
        /// Excluir a empresa informada
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return StatusCode(200, _companyAppService?.Delete(id));
        }

        /// <summary>
        /// Lista todas as empresas cadastradas
        /// </summary>
        [HttpGet("List/")]
        [ProducesResponseType(typeof(List<CompanyResponseDto>), 200)]
        public IActionResult GetAll()
        {
            return Ok(_companyAppService?.GetAll());
        }

        /// <summary>
        /// Retorna os dados da empresa informada
        /// </summary>
        [HttpGet("Get/{id}")]
        [ProducesResponseType(typeof(List<CompanyResponseDto>), 200)]
        public IActionResult Get(Guid id)
        {
            return Ok(_companyAppService?.Get(id));
        }
    }
}
