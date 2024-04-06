namespace UsersAPI.Domain.Exceptions
{
    public class CnpjAlreadyExistsException : Exception
    {
        public CnpjAlreadyExistsException(string cnpj, string companyName)
            : base($"O Cnpj '{cnpj}' está cadastrado para a empresa '{companyName}'. Informe outro Cnpj.")
        {

        }
    }
}
