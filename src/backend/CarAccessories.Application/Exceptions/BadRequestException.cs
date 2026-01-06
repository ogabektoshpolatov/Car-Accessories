namespace CarAccessories.Application.Exceptions;

public class BadRequestException(string message = ExceptionMessages.MessageBadRequest) : Exception (message)
{
    
}