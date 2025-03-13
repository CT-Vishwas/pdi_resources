using System.Collections.Generic;
using FluentValidation.Results;

namespace VKKirana.Models.Responses;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }

    public T Data { get; set; }

    public List<ValidationFailure>? Errors { get; set; }

    public ApiResponse(bool success, string message, T data, List<ValidationFailure>? errors = null)
    {
        Success = success;
        Message = message;
        Data = data;
        Errors = errors;
    }
}