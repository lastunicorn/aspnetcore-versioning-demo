# ASP.NET Core Versioning

## Step 1 - Include NuGet Packages

```cmd
Install-Package Asp.Versioning.Mvc.ApiExplorer
```

## Step 2 - Configure Services

In `Program.cs`:

```c#
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
}).AddApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});
```

- `GroupNameFormat` - Specifies the format for the version used in the URL. In our example the version has the letter 'v' plus three version numbers.

- `SubstituteApiVersionInUrl` - Configures Swagger to hardcode the version number in URL and prevent the user to change it manually.

## Step 3 - Set version in controller

- Add `ApiVersion` attribute on controllers.

- Add `Route` attribute on controllers to include the version.

```c#
[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/info")]
public class InfoController : ControllerBase
{
    ...
}
```

## Step 4 - Add Swagger documentation

Configure services:

```c#
 builder.Services.AddSwaggerGen(options =>
 {
     options.SwaggerDoc("v1", new OpenApiInfo
     {
         Title = "Versioning Demo",
         Version = "v1",
         Description = "Descripbe vresion 1"
     });
     options.SwaggerDoc("v2", new OpenApiInfo
     {
         Title = "Versioning Demo",
         Version = "v2",
         Description = "Descripbe vresion 2"
     });
 });
```

Configure Swagger UI middleware:

```c#
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Versioning Demo v1");
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "Versioning Demo v2");
});
```

