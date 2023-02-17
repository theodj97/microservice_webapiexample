using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using Application.Features.Categories.Commands;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
