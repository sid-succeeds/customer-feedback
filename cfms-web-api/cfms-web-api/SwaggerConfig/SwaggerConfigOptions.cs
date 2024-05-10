using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace cfms_web_api.SwaggerConfig
{
    /// <summary>
    /// Implementation of IConfigureOptions<SwaggerGenOptions> interface for configuring Swagger generation options.
    /// </summary>
    public class SwaggerConfigOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;

        /// <summary>
        /// Initialises a new instance of the <see cref="SwaggerConfigOptions"/> class.
        /// </summary>
        /// <param name="apiVersionDescriptionProvider">The API version description provider.</param>
        public SwaggerConfigOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            _apiVersionDescriptionProvider = apiVersionDescriptionProvider;
        }

        /// <summary>
        /// Configures Swagger generation options.
        /// </summary>
        /// <param name="options">The Swagger generation options to be configured.</param>
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

