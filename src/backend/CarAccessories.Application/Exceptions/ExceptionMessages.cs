namespace CarAccessories.Application.Exceptions;

public class ExceptionMessages
{
    public const string MessageNotFound = "Объект не найден в системе.";
    public const string MessageInvalidLogin = "Неправильный логин или пароль.";
    public const string MessageNotAllowedGeneric = "Вызов не был проведен.";
    public const string MessageBadRequest = "Неожиданная ошибка или неправильные данные были отправлены.";

    public const string MessageGenericError =
        "Что то произошло на сервере. Пожалуйста обратитесь администратору системы.";

    public const string MessageEmpowLimitExceeded =
        "Ограничение была достигнута у выбранного доверенности. Текущий лимит у выбранного доверенности: ";

    public const int CodeGenericError = -1;
    public const int CodeNotFoundError = 1;
    public const int CodeBadRequestError = 3;
    public const int CodeInvalidUserError = 2;
    public const int CodeTheRequestIsNotProcessed = 4;
}