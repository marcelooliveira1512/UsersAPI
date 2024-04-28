using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Application.Dtos.Requests
{
    public class ActivateUserRequestDto
    {
        [Required(ErrorMessage = "Informe o ID do Usuário.")]
        public Guid Id { get; set; }

    }
}
