using Asp.Versioning;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace DustInTheWind.AspNetVersioningDemo;

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
            options.ApiVersionReader = ApiVersionReader.Combine(
                new QueryStringApiVersionReader("version"),
                new HeaderApiVersionReader("X-Version"),
                new UrlSegmentApiVersionReader()
            );
        }).AddApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
            setup.SubstituteApiVersionInUrl = true;
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

            Assembly[] assemblies = new[]
            {
                typeof(Presentation.V1.Controllers.InfoController).Assembly,
                typeof(Presentation.V2.Controllers.InfoController).Assembly
            };

            options.IncludeXmlCommentsFrom(assemblies);
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Versioning Demo v1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Versioning Demo v2");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
