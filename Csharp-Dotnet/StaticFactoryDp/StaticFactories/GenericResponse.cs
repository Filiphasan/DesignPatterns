using StaticFactoryDp.Common.Constants;

namespace StaticFactoryDp.StaticFactories;

public class GenericResponse<T> where T : class
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    
    private GenericResponse(int statusCode, string? message, T? data)
    {
        StatusCode = statusCode;
        Message = message;
        Data = data;
    }
    
    public static GenericResponse<T> Success(T? data)
    {
        return new GenericResponse<T>(StatusCodeConstant.Ok, MessageConstant.Success, data);
    }
    
    public static GenericResponse<T> Success(string? message, T? data)
    {
        return new GenericResponse<T>(StatusCodeConstant.Ok, message, data);
    }
    
    public static GenericResponse<T> Success(int statusCode, string? message, T? data)
    {
        return new GenericResponse<T>(statusCode, message, data);
    }

    public static GenericResponse<T> Fail(int statusCode, string? message)
    {
        return new GenericResponse<T>(statusCode, message, null);
    }
}