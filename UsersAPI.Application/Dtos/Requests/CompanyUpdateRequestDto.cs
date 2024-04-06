using System.ComponentModel.DataAnnotations;
using UsersAPI.Domain.Enums;

namespace UsersAPI.Application.Dtos.Requests
{
    public class CompanyUpdateRequestDto
    {
        [Required(ErrorMessage = "Informe o Tipo da empresa (1-Sede ou 2-Filial).")]
        public string? CompanyType { get; set; }

        //[Required(ErrorMessage = "Informe o ID da Matriz.")]
        public Guid ParentCompanyId { get; set; } = Guid.Empty;

        [Required(ErrorMessage = "Informe a Razão Social.")]
        [MinLength(8, ErrorMessage = "Informe a Razão Social com pelo menos {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe a Razão Social com no máximo {1} caracteres.")]
        public string? CompanyName { get; set; }

        [Required(ErrorMessage = "Informe o Nome Fantasia.")]
        [MinLength(8, ErrorMessage = "Informe o Nome Fantasia com pelo menos {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe o Nome Fantasia com no máximo {1} caracteres.")]
        public string? FantasyName { get; set; }
        public string? ImgLogo { get; set; }

        [Required(ErrorMessage = "Informe o CNPJ da empresa.")]
        [StringLength(18, ErrorMessage = "O CNPJ tem que ter {1} caracteres.")]
        public string? Cnpj { get; set; }
        public string? InscMunicipal { get; set; }
        public string? InscEstadual { get; set; }
        public string? Cnae { get; set; }
        public string? Crt { get; set; }

        [Required(ErrorMessage = "Informe o Email da empresa.")]
        [EmailAddress(ErrorMessage = "Informe um email válido.")]
        public string? Email { get; set; }
        public string? Url { get; set; }

        [Required(ErrorMessage = "Informe o Telefone da empresa com DDD.")]
        [StringLength(11, ErrorMessage = "O Telefone da empresa tem que ter {1} caracteres.")]
        public string? FoneNumber1 { get; set; }
        public string? FoneNumber2 { get; set; }

        [Required(ErrorMessage = "Informe o CEP do logradouro da empresa.")]
        [StringLength(11, ErrorMessage = "O CEP do logradouro da empresa tem que ter {1} caracteres.")]
        public string? Zipcode { get; set; }

        [Required(ErrorMessage = "Informe o Logradouro da empresa.")]
        [MinLength(5, ErrorMessage = "Informe o Logradouro da empresa com no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe o Logradouro da empresa com no máximo {1} caracteres.")]
        public string? Address { get; set; }
        public string? Complement { get; set; }

        [Required(ErrorMessage = "Informe o Número do logradouro da empresa.")]
        [MaxLength(7, ErrorMessage = "Informe o Número do logradouro da empresa com no máximo {1} caracteres.")]
        public string? Number { get; set; }

        [Required(ErrorMessage = "Informe o Bairro do logradouro da empresa.")]
        [MinLength(5, ErrorMessage = "Informe o Bairro do logradouro da empresa com no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Informe o Bairro do logradouro da empresa com no máximo {1} caracteres.")]
        public string? Neighbourhood { get; set; }

        [Required(ErrorMessage = "Informe a Cidade do logradouro da empresa.")]
        [MinLength(5, ErrorMessage = "Informe a Cidade do logradouro da empresa com no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Informe a Cidade do logradouro da empresa com no máximo {1} caracteres.")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Informe o Estado do logradouro da empresa.")]
        [StringLength(2, ErrorMessage = "O Estado do logradouro da empresa tem que ter {1} caracteres.")]
        public string? State { get; set; }
    }

}
