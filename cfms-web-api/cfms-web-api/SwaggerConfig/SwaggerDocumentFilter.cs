using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace cfms_web_api.SwaggerConfig
{
    /// <summary>
    /// Implementation of IDocumentFilter interface that allows filtering of OpenApiDocument based on specified criteria.
    /// </summary>
    public class SwaggerDocumentFilter : IDocumentFilter
    {
        /// <summary>
        /// Applies filter to the provided OpenApiDocument.
        /// </summary>
        /// <param name="swaggerDoc">The OpenApiDocument to be filtered.</param>
        /// <param name="context">The DocumentFilterContext containing information about API descriptions.</param>
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

