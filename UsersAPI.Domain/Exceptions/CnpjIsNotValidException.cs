namespace UsersAPI.Domain.Exceptions
{
    public class CnpjIsNotValidException : Exception
    {
        public CnpjIsNotValidException(string cnpj)
            : base($"O Cnpj '{cnpj}' não é válido. Informe outro Cnpj.")
        {

        }
    }
}
