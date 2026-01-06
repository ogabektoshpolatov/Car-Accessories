using System.Net;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using CarAccessories.Domain.Exceptions;
using CarAccessories.Shared.Common.ResponseData;

namespace CarAccessories.Middlewares;

public class ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger, IWebHostEnvironment environment)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await LogExceptionAsync(context, ex);
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task LogExceptionAsync(HttpContext context, Exception exception)
    {
        var requestPath = context.Request.Path;
        var requestMethod = context.Request.Method;
        var userId = context.User?.Identity?.Name ?? "Anonymous";

        var logMessage = $@"
                            ═══════════════════════════════════════════════════════════════
                            EXCEPTION OCCURRED
                            ═══════════════════════════════════════════════════════════════
                            Timestamp: {DateTimeOffset.UtcNow:yyyy-MM-dd HH:mm:ss.fff} UTC
                            User: {userId}
                            Request: {requestMethod} {requestPath}
                            Query: {context.Request.QueryString}
                            Exception Type: {exception.GetType().Name}
                            Message: {exception.Message}
                            ═══════════════════════════════════════════════════════════════";

        logger.LogError(exception, logMessage);

        // Log to file or external service in production
        if (!environment.IsDevelopment())
        {
            // You can add additional logging here (e.g., to Serilog, Application Insights, etc.)
            await Task.CompletedTask;
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var (statusCode, errorCode, message) = MapExceptionToResponse(exception);
        context.Response.StatusCode = (int)statusCode;

        var response = BuildErrorResponse(statusCode, errorCode, message, exception);

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = environment.IsDevelopment()
        };

        var jsonResponse = JsonSerializer.Serialize(response, options);
        await context.Response.WriteAsync(jsonResponse);
    }

    private (HttpStatusCode statusCode, int errorCode, string message) MapExceptionToResponse(Exception exception)
    {
        return exception switch
        {
            NotFoundException notFound =>
                (HttpStatusCode.NotFound,
                 ExceptionMessages.CodeNotFoundError,
                 notFound.Message),

            BadRequestException badRequest =>
                (HttpStatusCode.BadRequest,
                 ExceptionMessages.CodeBadRequestError,
                 badRequest.Message),

            AccessDeniedException accessDenied =>
                (HttpStatusCode.Forbidden,
                 ExceptionMessages.CodeTheRequestIsNotProcessed,
                 accessDenied.Message),

            NotAllowedException notAllowed =>
                (HttpStatusCode.MethodNotAllowed,
                 ExceptionMessages.CodeTheRequestIsNotProcessed,
                 notAllowed.Message),

            UnauthorizedAccessException =>
                (HttpStatusCode.Unauthorized,
                 ExceptionMessages.CodeInvalidUserError,
                 "Доступ запрещен. Пожалуйста, войдите в систему."),

            ArgumentException argEx =>
                (HttpStatusCode.BadRequest,
                 ExceptionMessages.CodeBadRequestError,
                 $"Неверные параметры: {argEx.Message}"),

            // ArgumentNullException argNull =>
            //     (HttpStatusCode.BadRequest,
            //      ExceptionMessages.CodeBadRequestError,
            //      $"Обязательный параметр отсутствует: {argNull.ParamName}"),

            InvalidOperationException invalidOp =>
                (HttpStatusCode.BadRequest,
                 ExceptionMessages.CodeBadRequestError,
                 invalidOp.Message),

            FileNotFoundException =>
                (HttpStatusCode.NotFound,
                 ExceptionMessages.CodeNotFoundError,
                 "Файл не найден."),

            DbUpdateException =>
                (HttpStatusCode.InternalServerError,
                 ExceptionMessages.CodeGenericError,
                 "Ошибка при обновлении базы данных. Пожалуйста, проверьте данные и попробуйте снова."),

            TimeoutException =>
                (HttpStatusCode.RequestTimeout,
                 ExceptionMessages.CodeGenericError,
                 "Время ожидания запроса истекло. Пожалуйста, попробуйте еще раз."),

            _ =>
                (HttpStatusCode.InternalServerError,
                 ExceptionMessages.CodeGenericError,
                 ExceptionMessages.MessageGenericError)
        };
    }

    private ResponseData<object> BuildErrorResponse(
        HttpStatusCode statusCode,
        int errorCode,
        string message,
        Exception exception)
    {
        var response = new ResponseData<object>
        {
            Result = null,
            Error = new ResponseError
            {
                StatusCode = (int)statusCode,
                Message = message,
            }
        };
        
        if (environment.IsDevelopment())
        {
            response.Result = new
            {
                ErrorCode = errorCode,
                ExceptionType = exception.GetType().FullName,
                ExceptionMessage = exception.Message,
                StackTrace = exception.StackTrace?.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries),
                InnerException = exception.InnerException != null
                    ? new
                    {
                        Type = exception.InnerException.GetType().FullName,
                        Message = exception.InnerException.Message,
                        StackTrace = exception.InnerException.StackTrace?.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                    }
                    : null,
                Data = exception.Data.Count > 0 ? exception.Data : null
            };
        }

        return response;
    }
}

public static class ErrorHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ErrorHandlingMiddleware>();
    }
}