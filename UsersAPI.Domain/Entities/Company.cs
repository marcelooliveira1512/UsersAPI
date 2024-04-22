using UsersAPI.Domain.Enums;

namespace UsersAPI.Domain.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string? CompanyType { get; set; }
        public Guid ParentCompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? FantasyName { get; set; }
        public string? ImgLogo { get; set; }
        public string? Cnpj { get; set; }
        public string? InscMunicipal { get; set; }
        public string? InscEstadual { get; set; }
        public string? Cnae { get; set; }
        public string? Crt { get; set; }
        public string? Email { get; set; }
        public string? Url { get; set; }
        public string? FoneNumber1 { get; set; }
        public string? FoneNumber2 { get; set; }
        public string? Zipcode { get; set; }
        public string? Address { get; set; }
        public string? Complement { get; set; }
        public string? Number { get; set; }
        public string? Neighbourhood { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Relacionamento entre Entidades
        /// </summary>
        public List<User>? User { get; set; }
    }
}
