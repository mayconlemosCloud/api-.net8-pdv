using System;

namespace Aplicacao.Interfaces;

public interface IResult<T> where T : class
{

    public bool Success { get; }
    public string Message { get; }
    public T Data { get; set; }
    public List<string> ValidationErrors { get; }

    public IResult<T> SuccessResult(T data);

    public IResult<T> ErrorResult(string message);

    public IResult<T> ValidationFailure(List<string> validationErrors);

}
