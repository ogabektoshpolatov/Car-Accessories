namespace CarAccessories.Domain.Exceptions;

public class BadRequestException(string message = ExceptionMessages.MessageBadRequest) : Exception (message)
{
    
}