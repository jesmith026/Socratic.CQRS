using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Socratic.CQRS.Abstractions.Decorators
{
    public class AuditDecorator<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> handler;
        private readonly ILogger logger;
        private readonly Guid trackingId = Guid.NewGuid();

        public AuditDecorator(IRequestHandler<TRequest, TResponse> handler, ILogger logger)
        {
            this.handler = handler;
            this.logger = logger;
        }

        public async Task<TResponse> HandleAsync(TRequest request)
        {
            string requestJson = JsonSerializer.ToString(request);

            logger.LogInformation($"{trackingId} | Executing request of type {request.GetType().Name}: {requestJson}");

            try
            {
                var response = await handler.HandleAsync(request);

                logger.LogInformation($"{trackingId} | Request execution of type {request.GetType().Name}");

                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"{trackingId} | Failed to execute request");
                throw;
            }
        }
    }
}