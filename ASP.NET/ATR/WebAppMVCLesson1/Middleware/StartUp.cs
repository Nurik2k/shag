using System.Diagnostics.Contracts;

namespace WebAppMVCLesson1.Middleware
{
    public class StartUp
    {
        RequestDelegate nextDelegate;

        int userCount = 0;
        public StartUp(RequestDelegate nextDelegate, int userCount)
        {
            this.nextDelegate = nextDelegate;
            this.userCount = userCount;
        }

        public async Task Invoke(HttpContext context)
        {
            if (userCount == 5)
            {
                context.Response.WriteAsync("Wait a minute");
            }
            else
            {
                userCount++;
                await  nextDelegate(context);
            }
            
        }
    }
    public static class StartUpExtention
    {
        public static IApplicationBuilder UseStartUp(this IApplicationBuilder app, 
            int userCount)
        {
            return app.UseMiddleware<StartUp>(userCount);
        }
    }
}
