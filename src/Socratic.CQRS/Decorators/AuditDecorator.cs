using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Socratic.CQRS.Abstractions;
using Socratic.CQRS.Abstractions.Decorators;

namespace Socratic.CQRS.Decorators
{
    public class AuditDecorator<TRequest, TResponse> : CqrsDecorator<TRequest, TResponse> 
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger logger;
        private readonly Guid trackingId = Guid.NewGuid();

        public AuditDecorator(IRequestHandler<TRequest, TResponse> handler, ILoggerFactory loggerFactory) 
            : base(handler)
        {
            this.logger = loggerFactory.CreateLogger("CqrsAudit");
        }

        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            string requestJson = JsonSerializer.ToString(request);

            logger.LogInformation($"{trackingId} | Executing request of type {request.GetType().Name}: {requestJson}");

            try
            {
                var response = await Handler.HandleAsync(request);

                logger.LogInformation($"{trackingId} | Request execution of type {request.GetType().Name} completed");

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