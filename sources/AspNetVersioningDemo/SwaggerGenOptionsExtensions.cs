using System.Reflection;

namespace DustInTheWind.AspNetVersioningDemo;

internal static class SwaggerGenOptionsExtensions
{
    public static void IncludeXmlCommentsFrom(this Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions options, Assembly[] assemblies)
    {
        foreach (Assembly assembly in assemblies)
        {
            string xmlFileName = $"{assembly.GetName().Name}.xml";
            string xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);

            if (File.Exists(xmlFilePath))
                options.IncludeXmlComments(xmlFilePath);
        }
    }
}
