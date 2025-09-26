using Asp.Versioning;
using Microsoft.OpenApi.Models;

namespace DustInTheWind.AspNetCoreVersioningDemo;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        // Configure API versioning
        builder.Services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = new HeaderApiVersionReader("X-Version");
        }).AddApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Versioning Demo",
                Version = "v1"
            });
            options.SwaggerDoc("v2", new OpenApiInfo
            {
                Title = "Versioning Demo",
                Version = "v2",
                Description = "Advanced version of the API with enhanced features, improved performance, and additional endpoints. This version includes comprehensive version information, detailed error handling, and extended functionality for better integration capabilities."
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.DocumentTitle = "ASP.NET Core Versioning Demo";
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Versioning Demo v1");
                options.SwaggerEndpoint("/swagger/v2/swagger.json", "Versioning Demo v2");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
