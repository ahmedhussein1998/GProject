using GProject.Application.Service.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace GProject.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddScoped<IAuthencationService,AuthencationService>();
        return service;
    }

}