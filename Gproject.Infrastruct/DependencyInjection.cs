using Gproject.Application.Common.Interfaces.Authentication;
using Gproject.Application.Common.Interfaces.Services;
using Gproject.Infrastruct.Authencation;
using Gproject.Infrastruct.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Gproject.Application.Common.Interfaces.Persistance;
using Gproject.Infrastruct.Persistance;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Gproject.Infrastruct.Persistance.Repositories;

namespace Gproject.Infrastruct;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastruct(this IServiceCollection service,
        ConfigurationManager configuration)
    {


        service.AddAuth(configuration).AddPresistance(configuration);
        service.AddSingleton<IDataTimeProvider, DataTimeProvider>();
        service.AddScoped<IUploadFilesService, UploadFilesService>();
        return service;
    }

    public static IServiceCollection AddPresistance(this IServiceCollection service, ConfigurationManager configuration)
    {
        service.AddDbContext<GProjectDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        service.AddScoped<IUserRepositroy, UserRepsitory>();
        service.AddScoped<IMenuRepository, MenuRepository>();       
        return service;
    }
        public static IServiceCollection AddAuth(this IServiceCollection service,
        ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        service.AddSingleton(Options.Create(jwtSettings));
        service.AddSingleton<ICurrentUserService, CurrentUserService>();
        service.AddHttpContextAccessor();

        service.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        service.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options=>options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer= false,
                ValidateAudience= false,
                ValidateLifetime= false,
                ValidateIssuerSigningKey= true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });
        return service;
    }
}

