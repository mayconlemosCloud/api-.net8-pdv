


using Dominio.Validators.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace Dominio.Validators
{
    public abstract class BaseValidator<T> : AbstractValidator<T>, IBaseValidators<T> where T : class
    {
        public new ValidationResult Validate(T entity)
        {
            return Validate(entity);
        }

        public new async Task<ValidationResult> ValidateAsync(T entity)
        {
            return await base.ValidateAsync(entity);
        }
    }
}
