using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FinalExam.lib
{
    public class SiteService
    {
        Model1 db = new Model1();
       public bool AddSite(site site)
       {
           db.sites.Add(site);
            db.SaveChanges();
            return true;
       }
        public bool DeleteSite(site site)
        {
            using (var context = new Model1())
            {
                var entity = context.sites.FirstOrDefault(x => x.url == site.url);
                if(context != null)
                {
                    context.sites.Remove(entity);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        
        public List<site> GetSites()
        {
            List<site> sites = new List<site>();
            sites = db.sites.ToList();
            return sites;
        }
        public bool EditSite(site Site)
        {
            using(var context = new Model1()) 
            {
                var NewUrlStatus = context.sites.Find(Site.id);
                NewUrlStatus = Site;
                context.SaveChanges();
                return true;
            }
        }
    }
}
