using ErrorOr;
using FluentValidation;
using Gproject.Application.Authentication.Commands.Register;
using Gproject.Application.Authentication.Common;
using Gproject.Application.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GProject.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddMediatR(typeof(DependencyInjection).Assembly);
        service.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateBehavior<,>));
        service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return service;
    }

}