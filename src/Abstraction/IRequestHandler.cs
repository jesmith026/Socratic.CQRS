using System.Threading.Tasks;

namespace Socratic.CQRS.Abstractions
{
    /// <summary>
    /// Defines a handler for a request
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public interface IRequestHandler<in TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {         
        /// <summary>
        /// Synchronously handles a request
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Response from the request.</returns>
        TResponse Handle(TRequest request) => HandleAsync(request).Result;

        /// <summary>
        /// Asynchronously handles a request
        /// </summary>
        /// <param name="request"></param>
        /// <returns>A task representing the handle operation. The task result is the response to the request.</returns>
        Task<TResponse> HandleAsync(TRequest request);
    }
}