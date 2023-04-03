using System.Net;
using System.Net.Sockets;
namespace WebAppMVCLesson1.Middleware
{
    public class IpLimiterMiddleware
    {
        RequestDelegate nextDelegate;
        public IpLimiterMiddleware(RequestDelegate nextDelegate)
        {
            this.nextDelegate = nextDelegate;
        }
        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                string ip = GetLocalIPAddress();
                if (ip == "192.168.110.106")
                {
                    context.Response.WriteAsync("NO");
                }
                else
                {
                    nextDelegate.Invoke(context);
                }
            }
            catch (Exception ex)
            {
                nextDelegate.Invoke(context);
            }
            
        }
    }

    public static class IpLimiterMiddlewareExtensions
    {
        // Расширяющий метод для подключение middleware к pipline
        public static IApplicationBuilder UseIpLimit(this IApplicationBuilder app)
        {
            return app.UseMiddleware<IpLimiterMiddleware>();
        }
    }
}
