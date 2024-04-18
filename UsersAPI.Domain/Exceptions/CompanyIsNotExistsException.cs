namespace UsersAPI.Domain.Exceptions
{
    public class CompanyIsNotExistsException : Exception
    {
        public CompanyIsNotExistsException(Guid id)
            : base($"O ID '{id}' não está vinculado a nenhuma empresa. Informe outra Empresa.")
        {

        }
    }
}
