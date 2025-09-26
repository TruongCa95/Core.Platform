using MediatR;

namespace Infrastructure.Query
{
    public interface IQueryRunner
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }
}
