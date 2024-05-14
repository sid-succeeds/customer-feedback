using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace cfms_web_api.SwaggerConfig
{
    // Implementation of IDocumentFilter interface that allows filtering of OpenApiDocument based on specified criteria.
    public class SwaggerDocumentFilter : IDocumentFilter
    {
        // Applies filter to the provided OpenApiDocument.
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (var desc in context.ApiDescriptions)
            {
                if (desc.ParameterDescriptions.Any(p => p.Name == "api-version" && p.Source.Id == "Query"))
                    swaggerDoc.Paths.Remove($"/{desc.RelativePath?.TrimEnd('/')}");
            }
        }
    }
}

