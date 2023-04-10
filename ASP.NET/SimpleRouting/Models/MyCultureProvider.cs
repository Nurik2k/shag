using Microsoft.AspNetCore.Localization;

namespace SimpleRouting.Models
{
    public class MyCultureProvider : RequestCultureProvider
    {
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            //TODO SQL request

            var requestCulture = new ProviderCultureResult("ru");
            return Task.FromResult(requestCulture);
        }
    }
}
