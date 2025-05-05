using FluentValidation;
using MediatR;
using Resto.Application.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resto.Application.Common.Behaviours
{
    public class ValidationBehavior<TRequest, TResponse>
        (IEnumerable<IValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, TResponse>
           where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
          var context = new ValidationContext<TRequest>(request);

            var valdiationResults = await Task.WhenAll(
                validators.Select(v=> v.ValidateAsync(context, cancellationToken))
            );

            var failures = valdiationResults
                .Where(r => r.Errors.Any())
                .SelectMany(e =>e.Errors)
                .ToList();

            if(failures.Any())
            {
                throw new ValidationException(failures);
            }

            return await next();
        }
    }
}
