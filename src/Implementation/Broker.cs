using System;
using System.Threading;
using System.Threading.Tasks;
using Socratic.CQRS.Abstractions;

namespace Socratic.CQRS
{
    /// <inheritdoc/>
    public class Broker : IBroker
    {        
        private readonly IServiceProvider provider;

        public Broker(IServiceProvider provider)
        {
            this.provider = provider;
        }

        /// <inheritdoc/>
        public async Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            var type = typeof(IRequestHandler<,>);
            Type[] typeArgs = { request.GetType(), typeof(TResponse) };
            var handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = provider.GetService(handlerType);
            return await handler.HandleAsync((dynamic)request);
        }
    }
}