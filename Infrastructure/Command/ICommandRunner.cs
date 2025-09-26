using MediatR;

namespace Infrastructure.Command
{
    public interface ICommandRunner
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }
}
