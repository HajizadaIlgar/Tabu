namespace Tabu.Exceptions.Language
{
    public class LanguageExistException : Exception, IBaseException
    {
        public string ErrorMessage { get; }
        public LanguageExistException()
        {
            ErrorMessage = "Language Already aded database";
        }
        public LanguageExistException(string message) : base(message)
        {
            ErrorMessage = message;
        }
        public int StatusCode => StatusCodes.Status409Conflict;
    }
}
