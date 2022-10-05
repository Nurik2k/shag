using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;

namespace KBB.Online.BLL
{
    public class Repository<T> : IRepository<T>
        // where T : class ->//здесь обозначаем, что Т являеться классом. А так это шаблон.
    {
        public string Path { get; set; }
        public Repository(string Path)
        {
            this.Path = Path;
        }
        public T Update(T obj)
        {
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var data = db.GetCollection<T>(typeof(T).Name);
                    data.Update(obj);
                    
                }
            }
            catch (Exception ex)
            {

                throw new Exception("При обновлении записи в базе данных возникла ошибка", ex);
            
            }
            return obj;
        }
        public T Create(T obj)
        {
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var data = db.GetCollection<T>(typeof(T).Name);
                    data.Insert(obj);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return obj;
        }
        public T GetObjById(int id)
        {
            T obj;
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var data = db.GetCollection<T>(typeof(T).Name);
                    obj = data.FindById(id);

                }
            }
            catch (Exception ex) 
            { 
            throw new Exception("При получении данных возникла ошибка", ex);
            }
            return obj;
        }
        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> list;
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    list = db.GetCollection<T>(typeof(T).Name).FindAll();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("При получении данных возникла ошибка", ex);
            }
            return list;
        }
    }
    public interface IRepository<T>
    {
        string Path { get; set; }
        T Update(T obj);
        T Create(T obj);
        T GetObjById(int id);
        IEnumerable<T> GetAll();

    }
}
