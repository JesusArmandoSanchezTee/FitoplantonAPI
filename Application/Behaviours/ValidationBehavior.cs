using FluentValidation;
using MediatR;

namespace Application.Behaviours;

public class ValidationBehavior <TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new FluentValidation.ValidationContext<TRequest>(request);    
            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = validationResults.SelectMany(v => v.Errors).Where(f => f != null).ToList();
            if (failures.Count != 0)
            {
                var mensajes = failures
                    .Select(f => f.ErrorMessage)
                    .ToList();

                // Lanzamos tu ValidationException existente
                throw new Exceptions.ValidationException(
                    message: "Errores de validación",
                    errors: mensajes
                );
            }
        }
        
        return await next();
    }
}