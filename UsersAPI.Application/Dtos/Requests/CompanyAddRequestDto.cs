using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UsersAPI.Domain.Enums;

namespace UsersAPI.Application.Dtos.Requests
{
    public class CompanyAddRequestDto
    {
        [Range(1, 2)]
        [Required(ErrorMessage = "Informe o Tipo da empresa (1-Sede ou 2-Filial).")]
        public string? CompanyType { get; set; }

        [DefaultValue("00000000-0000-0000-0000-000000000000")]
        public Guid ParentCompanyId { get; set; }

        [Required(ErrorMessage = "Informe a Razão Social.")]
        [MinLength(8, ErrorMessage = "Informe a Razão Social com pelo menos {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Informe a Razão Social com no máximo {1} caracteres.")]
        public string? CompanyName { get; set; }

        [Required(ErrorMessage = "Informe o Nome Fantasia.")]
        [MinLength(8, ErrorMessage = "Informe o Nome Fantasia com pelo menos {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Informe o Nome Fantasia com no máximo {1} caracteres.")]
        public string? FantasyName { get; set; }

        [MaxLength(20, ErrorMessage = "Informe o Nome da imagem do logo da empresa com no máximo {1} caracteres.")]
        public string? ImgLogo { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Informe somente os números do CNPJ da empresa.")]
        [Required(ErrorMessage = "Informe somente os números do CNPJ da empresa.")]
        [StringLength(14, ErrorMessage = "O CNPJ tem que ter {1} números.")]
        public string? Cnpj { get; set; }

        [MaxLength(20, ErrorMessage = "Informe a Inscrição Municipal da empresa com no máximo {1} caracteres.")]
        public string? InscMunicipal { get; set; }

        [MaxLength(20, ErrorMessage = "Informe a Inscrição Estadual da empresa com no máximo {1} caracteres.")]
        public string? InscEstadual { get; set; }

        [MaxLength(15, ErrorMessage = "Informe o CNAE da empresa com no máximo {1} caracteres.")]
        public string? Cnae { get; set; }

        [MaxLength(20, ErrorMessage = "Informe o CRT da empresa com no máximo {1} caracteres.")]
        public string? Crt { get; set; }

        [Required(ErrorMessage = "Informe o Email da empresa.")]
        [EmailAddress(ErrorMessage = "Informe um email válido.")]
        [MaxLength(80, ErrorMessage = "Informe um email válido com no máximo {1} caracteres.")]
        public string? Email { get; set; }

        [MaxLength(50, ErrorMessage = "Informe a Url da empresa com no máximo {1} caracteres.")]
        public string? Url { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Informe somente os números do Telefone da empresa, sem espaço.")]
        [Required(ErrorMessage = "Informe o Telefone da empresa com DDD sem espaço.")]
        [MinLength(10, ErrorMessage = "Informe o Telefone da empresa com pelo menos {1} números.")]
        [MaxLength(11, ErrorMessage = "Informe o Telefone da empresa com no máximo {1} números.")]
        public string? FoneNumber1 { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Informe somente os números do Telefone da empresa, sem espaço.")]
        [MaxLength(11, ErrorMessage = "Informe o Telefone da empresa com no máximo {1} números.")]
        public string? FoneNumber2 { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Informe somente os números do CEP do logradouro da empresa.")]
        [Required(ErrorMessage = "Informe somente os números do CEP do logradouro da empresa.")]
        [StringLength(8, ErrorMessage = "O CEP do logradouro da empresa tem que ter {1} números.")]
        public string? Zipcode { get; set; }

        [Required(ErrorMessage = "Informe o Logradouro da empresa.")]
        [MinLength(5, ErrorMessage = "Informe o Logradouro da empresa com no mínimo {1} caracteres.")]
        [MaxLength(70, ErrorMessage = "Informe o Logradouro da empresa com no máximo {1} caracteres.")]
        public string? Address { get; set; }

        [MaxLength(30, ErrorMessage = "Informe o Nome da imagem do logo com no máximo {1} caracteres.")]
        public string? Complement { get; set; }

        [Required(ErrorMessage = "Informe o Número do logradouro da empresa.")]
        [MaxLength(7, ErrorMessage = "Informe o Número do logradouro da empresa com no máximo {1} caracteres.")]
        public string? Number { get; set; }

        [Required(ErrorMessage = "Informe o Bairro do logradouro da empresa.")]
        [MinLength(5, ErrorMessage = "Informe o Bairro do logradouro da empresa com no mínimo {1} caracteres.")]
        [MaxLength(40, ErrorMessage = "Informe o Bairro do logradouro da empresa com no máximo {1} caracteres.")]
        public string? Neighbourhood { get; set; }

        [Required(ErrorMessage = "Informe a Cidade do logradouro da empresa.")]
        [MinLength(5, ErrorMessage = "Informe a Cidade do logradouro da empresa com no mínimo {1} caracteres.")]
        [MaxLength(40, ErrorMessage = "Informe a Cidade do logradouro da empresa com no máximo {1} caracteres.")]
        public string? City { get; set; }

        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "Informe somente letras para a UF do logradouro da empresa.")]
        [Required(ErrorMessage = "Informe a UF do logradouro da empresa.")]
        [StringLength(2, ErrorMessage = "A UF do logradouro da empresa tem que ter {1} letras.")]
        public string? State { get; set; }
    }
}
