using Gproject.Api;
using Gproject.Domain.MenuAggregate;
using Gproject.Infrastruct;
using Gproject.Infrastruct.Persistance;
using GProject.Application;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;

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
    app.UseStaticFiles();
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


