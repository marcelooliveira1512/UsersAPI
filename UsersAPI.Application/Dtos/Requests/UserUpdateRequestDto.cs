using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Application.Dtos.Requests
{
    public class UserUpdateRequestDto
    {
        [Required(ErrorMessage = "Informe uma Empresa.")]
        public Guid CompanyId { get; set; }

        [Required(ErrorMessage = "Informe um Perfil.")]
        public Guid RoleId { get; set; }

        [Required(ErrorMessage = "Informe o Nome.")]
        [MinLength(2, ErrorMessage = "Informe o Nome com pelo menos {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe o Nome com no máximo {1} caracteres.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Informe o Sobrenome.")]
        [MinLength(2, ErrorMessage = "Informe o Sobrenome com pelo menos {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe o Sobrenome com no máximo {1} caracteres.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Informe se o usuário está Ativo.")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "Informe se o email foi Confirmado.")]
        public bool EmailConfirmed { get; set; }
    }
}
