namespace CarAccessories.Domain.Exceptions;

public class NotAllowedException(string message = ExceptionMessages.MessageNotAllowedGeneric) : Exception (message)
{
    
}