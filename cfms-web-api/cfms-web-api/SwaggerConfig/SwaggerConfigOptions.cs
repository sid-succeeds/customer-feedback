using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace cfms_web_api.SwaggerConfig
{
    // Implementation of IConfigureOptions<SwaggerGenOptions> interface for configuring Swagger generation options.
    public class SwaggerConfigOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;

        // Initialises a new instance of the <see cref="SwaggerConfigOptions"/> class.
        public SwaggerConfigOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            _apiVersionDescriptionProvider = apiVersionDescriptionProvider;
        }

        // Configures Swagger generation options.
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var desc in _apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                // Add a Swagger document for each API version
                options.SwaggerDoc(desc.GroupName, new OpenApiInfo
                {
                    // Set the title and version for the Swagger document
                    Title = "Customer Feedback API",
                    Version = desc.ApiVersion.ToString()
                });
            }
        }
    }
}

