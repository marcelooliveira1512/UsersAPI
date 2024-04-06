namespace UsersAPI.Domain.Exceptions
{
    public class CompanyIsNotDeleteException : Exception
    {
        public CompanyIsNotDeleteException(string companyName)
            : base($"A empresa '{companyName}' não pode ser excluída, existe(m) usuário(s) vinculado(s) a ela.")
        {

        }
    }
}
