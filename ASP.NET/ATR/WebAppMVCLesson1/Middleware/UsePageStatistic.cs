using WebAppMVCLesson1.Models;

namespace WebAppMVCLesson1.Middleware
{
    public class UsePageStatistic
    {
        private EFContext db;
        private RequestDelegate nextDelegate;
        public UsePageStatistic(RequestDelegate nextDelegate, EFContext db)
        {
            this.nextDelegate = nextDelegate;
            this.db = db;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                PageStatistic pageStat = new PageStatistic();
                pageStat.PathBase = context.Request.PathBase;
                pageStat.Path = context.Request.Path;
                db.PageStatistics.Add(pageStat);
                db.SaveChanges();
            }
            catch (Exception ex) { }
            await nextDelegate.Invoke(context);
        }
    }
}
