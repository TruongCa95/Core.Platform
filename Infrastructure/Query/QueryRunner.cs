using MediatR;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Query
{
    public class QueryRunner : IQueryRunner
    {
        private readonly IMediator _mediator;
        private readonly ILogger<QueryRunner> _logger;

        public QueryRunner(IMediator mediator, ILogger<QueryRunner> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            _logger.LogInformation($"Sending query: {request.GetType().Name}");

            var response = await _mediator.Send(request);

            _logger.LogInformation($"Received response: {response}");

            return response;
        }
    }
}
