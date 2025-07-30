using Asp.Versioning;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace DustInTheWind.AspNetVersioningDemo;

public class Program
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
                Version = "v2"
            });
            
            // Include XML comments
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            
            // Include XML comments from V1 and V2 presentation projects
            var v1XmlFile = "DustInTheWind.AspNetVersioningDemo.Presentation.V1.xml";
            var v1XmlPath = Path.Combine(AppContext.BaseDirectory, v1XmlFile);
            if (File.Exists(v1XmlPath))
                options.IncludeXmlComments(v1XmlPath);
                
            var v2XmlFile = "DustInTheWind.AspNetVersioningDemo.Presentation.V2.xml";
            var v2XmlPath = Path.Combine(AppContext.BaseDirectory, v2XmlFile);
            if (File.Exists(v2XmlPath))
                options.IncludeXmlComments(v2XmlPath);
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
