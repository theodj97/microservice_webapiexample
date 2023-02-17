
namespace Application.Behaviours
{
    //public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    //{
    //    private readonly ILogger<TRequest> _logger;
    //    private static readonly List<Type> exceptions = new List<Type> { new NotFoundException().GetType(),
    //                                                                FluentValidationException.Create().GetType(),
    //                                                            new BadRequestException().GetType()
    //    };
    //    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
    //    {
    //        _logger = logger;
    //    }

    //    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    //    {
    //        try
    //        {
    //            return await next();
    //        }
    //        catch (Exception ex)
    //        {
    //            var requestName = typeof(TRequest).Name;
    //            var jsonRequest = System.Text.Json.JsonSerializer.Serialize(request);
    //            if (exceptions.Any(x => x.Equals(ex.GetType())))
    //            {
    //                _logger.Log(LogLevel.Error, $"{jsonRequest} {ex.Message}", jsonRequest, ex.Message);
    //            }
    //            else
    //            {
    //                _logger.LogCritical(ex, "{request} {jsonRequest}", request, jsonRequest);
    //            }

    //            throw;
    //        }
    //    }
    //}
}
