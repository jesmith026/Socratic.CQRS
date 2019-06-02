using System.Threading;
using System.Threading.Tasks;

namespace Socratic.CQRS.Abstractions
{
    /// <summary>
    /// Defines a mediator for handling requests
    /// </summary>
    public interface IBroker
    {
        /// <summary>
        /// Sychronously sends a request to a single handler
        /// </summary>
        /// <param name="request"></param>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns>The response from the handler</returns>
        TResponse Dispatch<TResponse>(IRequest<TResponse> request) => DispatchAsync(request).Result;

        /// <summary>
        /// Asynchronously sends a request to a single handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns>A task representing the dispatch operation. The task result is the handler response.</returns>
        Task<TResponse> DispatchAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    }
}