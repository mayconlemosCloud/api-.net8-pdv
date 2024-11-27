using System;
using Aplicacao.Interfaces;

namespace Aplicacao.Result;

public class Result<T> : IResult<T> where T : class
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public List<string> ValidationErrors { get; set; }

    public IResult<T> ErrorResult(string message)
    {
        return new Result<T> { Success = false, Message = message };
    }

    public IResult<T> SuccessResult(T data)
    {
        return new Result<T> { Success = true, Data = data };
    }

    public IResult<T> ValidationFailure(List<string> validationErrors)
    {
        return new Result<T> { Success = false, ValidationErrors = validationErrors };
    }
}
