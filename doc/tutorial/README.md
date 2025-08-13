# ASP.NET Core Versioning - Tutorial

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
    options.ApiVersionReader = new QueryStringApiVersionReader();
}).AddApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
});
```

- `GroupNameFormat` - Specifies the format for the version. In our example the version has the letter 'v' plus three version numbers.
  - Not sure why  this configuration is necessary for Query String versioning.

## Step 3 - Set version in controller

- Add `ApiVersion` attribute on controllers.

- Add `Route` attribute on controllers to include the version.

```c#
[ApiController]
[ApiVersion("1.0")]
[Route("info")]
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
         Description = "Describe version 1"
     });
     options.SwaggerDoc("v2", new OpenApiInfo
     {
         Title = "Versioning Demo",
         Version = "v2",
         Description = "Describe version 2"
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

