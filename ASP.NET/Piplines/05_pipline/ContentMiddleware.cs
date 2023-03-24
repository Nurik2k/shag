
namespace _05_pipline
{
    public class ContentMiddleware
    {
        private RequestDelegate nextDelegate;
        public ContentMiddleware(RequestDelegate nextDelegate)
        {
            this.nextDelegate = nextDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.ToString() == "/middleware")
            {
                await context.Response.WriteAsync("This is from the context");
            }
            else
            {
                await nextDelegate.Invoke(context);
            }
        }
    }

    public static class ContentMiddlewareExctension 
    {
        public static IApplicationBuilder cme(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ContentMiddleware>();
        }
    }
}
