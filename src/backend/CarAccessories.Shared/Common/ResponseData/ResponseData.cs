using System.Net;

namespace CarAccessories.Shared.Common.ResponseData;

public class ResponseData<T>
{
    public T? Result { get; set; }
    public ResponseError? Error { get; set; }

    public ResponseData(T result) => Result = result;

    public ResponseData(string error)
    {
        Error = new ResponseError
        {
            StatusCode = (int)HttpStatusCode.BadRequest,
            Message = error
        };
    }

    public ResponseData(string error, HttpStatusCode statusCode)
    {
        Error = new ResponseError
        {
            StatusCode = (int)statusCode,
            Message = error
        };
    }

    public ResponseData() { }

    public ResponseData(Exception ex)
    {
        Error = new ResponseError
        {
            StatusCode = (int)HttpStatusCode.InternalServerError,
            Message = ex.Message + (ex.InnerException != null ? "; " + ex.InnerException.Message : "")
        };
    }

    public ResponseData(HttpStatusCode code)
    {
        int statusCode = (int)code;
        if (statusCode < 200 || statusCode > 300)
        {
            Error = code switch
            {
                HttpStatusCode.Unauthorized => new ResponseError { StatusCode = statusCode, Message = "Unauthorized" },
                HttpStatusCode.BadRequest => new ResponseError { StatusCode = statusCode, Message = "Invalid parameters" },
                HttpStatusCode.Forbidden => new ResponseError { StatusCode = statusCode, Message = "Forbidden" },
                HttpStatusCode.NotFound => new ResponseError { StatusCode = statusCode, Message = "Not found" },
                HttpStatusCode.InternalServerError => new ResponseError { StatusCode = statusCode, Message = "Internal server error" },
                _ => throw new ArgumentOutOfRangeException(nameof(code), code, "Invalid status code")
            };
        }
        else
        {
            Result = (T)(object)true!;
        }
    }
    
    public static implicit operator ResponseData<T>(T value) => new(value);
    public static implicit operator ResponseData<T>(string error) => new(error);
    public static implicit operator ResponseData<T>(Exception ex) => new(ex);
    public static implicit operator ResponseData<T>(HttpStatusCode code) => new(code);
}
