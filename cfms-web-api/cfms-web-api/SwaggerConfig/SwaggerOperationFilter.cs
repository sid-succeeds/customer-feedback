using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace cfms_web_api.SwaggerConfig
{
    internal class SwaggerOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Tags = new[] { new OpenApiTag { Name = context.ApiDescription.HttpMethod } };
        }
    }
}

