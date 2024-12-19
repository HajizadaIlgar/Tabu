namespace Tabu.Exceptions.Language
{
    public class LanguageNotFoundException : Exception, IBaseException
    {
        public string ErrorMessage { get; }
        public int StatusCode => StatusCodes.Status404NotFound;
        public LanguageNotFoundException()
        {
            ErrorMessage = "Language not found !";
        }
        public LanguageNotFoundException(string message) : base(message)
        {
            ErrorMessage = message;
        }

    }
}
