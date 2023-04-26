//using microsoft.entityframeworkcore;
//using webappauthidentity.data;
//using webappauthidentity.models;

//namespace webappauthidentity.service
//{
//    public class authservice : iauthservice
//    {
//        private readonly applicationdbcontext _context;
//        public authservice(applicationdbcontext context)
//        {
//            _context = context;
//        }

//        public async task<user> walidateuse(string username, string password)
//        {
//            var dbuser = await _context.users.firstordefaultasync(f => f.username == username && f.password == password);
//            return dbuser;
//        }
//    }
//}
