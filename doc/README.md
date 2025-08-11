# ASP.NET Core Versioning

## Step 1 - Include Nuget Packages

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
```

## Step 3 - Set version in controller

Add `ApiVersion` attribute on controllers.

```c#
[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/info")]
public class InfoController : ControllerBase
{
    ...
}
```

