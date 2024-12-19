namespace Tabu.Exceptions.Language
{
    public class LanguageAlreadyDelete : Exception, IBaseException
    {
        public string ErrorMessage { get; }
        public LanguageAlreadyDelete()
        {
            ErrorMessage = "Data already removed !";
        }
        public LanguageAlreadyDelete(string message) : base(message)
        {
            ErrorMessage = message;
        }
        public int StatusCode => StatusCodes.Status404NotFound;

    }
}
