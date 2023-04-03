namespace WebAppMVCLesson1.Middleware
{
    public class EMiddleware
    {
        RequestDelegate nextDelegate;
        public EMiddleware(RequestDelegate nextDelegate)
        {
            this.nextDelegate = nextDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                var userAgent = context.Request.Headers["User-Agent"].ToString();
                if (userAgent.Contains("Edg"))
                {
                    context.Response.Redirect("/Home/WrongEdg/");
                    //context.Response.WriteAsync("Sorry edg is not for us");
                }
                else
                {
                    await nextDelegate.Invoke(context);
                }
                //Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36 Edg/111.0.1661.54
                //var data = context.Request.Headers["User-Agent"];

            }
            catch (Exception ex)
            {
            }

            
        }
    }
}
