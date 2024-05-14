using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace cfms_web_api.Attributes
{
    public class ApiKeyAttribute : ActionFilterAttribute
    {
        private string _apiKey;

        public static IConfiguration Configuration { get; set; }

        public ApiKeyAttribute()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (Configuration == null)
            {
                throw new InvalidOperationException("Configuration has not been set.");
            }

            _apiKey = Configuration["AppSettings:ApiKey"];

            if (!context.HttpContext.Request.Headers.TryGetValue("ApiKey", out var apiKey) ||
                apiKey != _apiKey)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
