using Gproject.Application.Common.Interfaces.Authentication;
using Gproject.Application.Common.Interfaces.Services;
using Gproject.Infrastruct.Authencation;
using Gproject.Infrastruct.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Gproject.Infrastruct;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastruct(this IServiceCollection service,
        ConfigurationManager configuration)
    {
        service.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        service.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        service.AddSingleton<IDataTimeProvider, DataTimeProvider>();
        return service;
    }

}

