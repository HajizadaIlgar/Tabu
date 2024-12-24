namespace Tabu.Exceptions;

public class EntityNullReferenceException : Exception, IBaseException
{
    public string ErrorMessage { get; }
    public int StatusCode => StatusCodes.Status404NotFound;
    public EntityNullReferenceException()
    {
        ErrorMessage = "Data not fount";
    }
    public EntityNullReferenceException(string message) : base(message)
    {
        ErrorMessage = message;
    }

}
