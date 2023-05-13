using Gproject.Api;
using Gproject.Api.Common.Mapping;
using Gproject.Api.Errors;
using Gproject.Api.Filter;
using Gproject.Api.Midleware;
using Gproject.Infrastruct;
using GProject.Application;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPresentation()
    .AddApplication()
    .AddInfrastruct(builder.Configuration);

//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Localization

builder.Services.AddControllersWithViews();
        builder.Services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "";
            });

        builder.Services.Configure<RequestLocalizationOptions>(options =>
         {
        List<CultureInfo> supportedCultures = new List<CultureInfo>
        {
            new CultureInfo("en-US"),
            new CultureInfo("de-DE"),
            new CultureInfo("fr-FR"),
            new CultureInfo("ar-EG")
        };

        options.DefaultRequestCulture = new RequestCulture("ar-EG");
        options.SupportedCultures = supportedCultures;
        options.SupportedUICultures = supportedCultures;
    });


#endregion



var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddelware>();
    //app.Map("/error", (HttpContext httpContext) => {
    //    Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    //    return Results.Problem();
    //});
    //app.UseExceptionHandler("/error");
    app.UseSwagger();
    app.UseSwaggerUI();
    #region Localization middleware

    var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
    app.UseRequestLocalization(options.Value);
    #endregion


    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();

}

//// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(
        );
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseSwagger(x=>x.SerializeAsV2 =true);


//app.UseAuthorization();


