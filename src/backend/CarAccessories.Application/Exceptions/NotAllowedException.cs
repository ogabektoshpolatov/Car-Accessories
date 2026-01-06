namespace CarAccessories.Application.Exceptions;

public class NotAllowedException(string message = ExceptionMessages.MessageNotAllowedGeneric) : Exception (message)
{
    
}