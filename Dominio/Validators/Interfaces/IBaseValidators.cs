using System;
using FluentValidation.Results;


namespace Dominio.Validators.Interfaces;

public interface IValidators<T> where T : class
{
    ValidationResult Validate(T entity);
    Task<ValidationResult> ValidateAsync(T entity);
}
