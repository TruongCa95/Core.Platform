using MediatR;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Command
{
    public class Command : ICommandRunner
    {
        private readonly IMediator _mediator;
        private readonly ILogger<Command> _logger;

        public Command(IMediator mediator, ILogger<Command> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            _logger.LogInformation($"Sending command: {request.GetType().Name}");

            var response = await _mediator.Send(request);

            _logger.LogInformation($"Received response: {response}");

            return response;
        }
    }
}
