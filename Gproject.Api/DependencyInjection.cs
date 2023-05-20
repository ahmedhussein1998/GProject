using Gproject.Api.Common.Mapping;
using Gproject.Api.Errors;
using Mapster;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection;

namespace Gproject.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {           
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, GProjectProblemDetailsFactory>();
            services.AddMappings();
            return services;
        }
    }
}
