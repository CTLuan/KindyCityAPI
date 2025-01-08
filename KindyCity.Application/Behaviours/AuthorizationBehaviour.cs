using MediatR;

namespace KindyCity.Application.Behaviours
{

    public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Kiểm tra quyền truy cập ở đây. Nếu không có quyền, throw exception

            return await next();
        }
    }
}
