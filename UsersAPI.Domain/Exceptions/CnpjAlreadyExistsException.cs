namespace UsersAPI.Domain.Exceptions
{
    public class CnpjAlreadyExistsException : Exception
    {
        public CnpjAlreadyExistsException(string cnpj)
            : base($"O Cnpj '{cnpj}' já está cadastrado. Informe outro Cnpj.")
        {

        }
    }
}
