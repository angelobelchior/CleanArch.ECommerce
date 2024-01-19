using ECommerce.Domain;
using FluentValidation;
using MediatR;

namespace ECommerce.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> (IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>

{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!validators.Any()) return await next();

        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        var failures = validationResults
            .SelectMany(r => r.Errors)
            .Where(f => f is not null)
            .ToList();
        if (failures.Count == 0) return await next();

        var validations = failures
            .Select(f => new Validation(f.PropertyName, f.ErrorMessage));
        
        throw new ResultException(validations.ToArray());
    }
}