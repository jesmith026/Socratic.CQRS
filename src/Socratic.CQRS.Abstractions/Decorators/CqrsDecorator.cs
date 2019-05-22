using System.Threading.Tasks;

namespace Socratic.CQRS.Abstractions.Decorators
{
    public abstract class CqrsDecorator<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public CqrsDecorator(IRequestHandler<TRequest, TResponse> handler)
        {
            Handler = handler;
        }

        protected IRequestHandler<TRequest, TResponse> Handler { get; }

        public abstract Task<TResponse> HandleAsync(TRequest request);
    }
}