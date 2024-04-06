using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Application.Dtos.Requests
{
    public class SubModuleUpdateRequestDto
    {
        [Required(ErrorMessage = "Informe o Nome do SubMódulo.")]
        [MinLength(2, ErrorMessage = "Informe o Nome do SubMódulo com pelo menos {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe o Nome do SubMódulo com no máximo {1} caracteres.")]
        public string? SubModuleName { get; set; }

    }
}
