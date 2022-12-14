using Gproject.Api;
using Gproject.Api.Common.Mapping;
using Gproject.Api.Errors;
using Gproject.Api.Filter;
using Gproject.Api.Midleware;
using Gproject.Infrastruct;
using GProject.Application;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPresentation().AddApplication().AddInfrastruct(builder.Configuration);

//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddelware>();
    //app.Map("/error", (HttpContext httpContext) => {
    //    Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    //    return Results.Problem();
    //});
    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

//// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseAuthorization();


