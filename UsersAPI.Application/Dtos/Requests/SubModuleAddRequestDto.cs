using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Application.Dtos.Requests
{
    public class SubModuleAddRequestDto
    {
        //[Required(ErrorMessage = "Informe o ID do Módulo.")]
        public Guid ModuleId { get; set; }

        public Guid ParentSubModuleId { get; set; } = Guid.Empty;

        [Required(ErrorMessage = "Informe o Nome do SubMódulo.")]
        [MinLength(2, ErrorMessage = "Informe o Nome do SubMódulo com pelo menos {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe o Nome do SubMódulo com no máximo {1} caracteres.")]
        public string? SubModuleName { get; set; }
    }
}
