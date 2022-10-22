using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_EKZ.BLL
{
    public class ComponentsService
    {
        public string Path { get; set; }
        public ComponentsService()
        {

        }
        public ComponentsService(string path)
        {
            Path = path;
        }

        List<string> components = new List<string>();

        public ReturnResult CreateComponents(Component component)
        {
            ReturnResult result = new ReturnResult();
            using (var db = new LiteDatabase(Path))
            {
                var components = db.GetCollection<Component>(typeof(Component).Name);
                components.Insert(component);
            }
            return result;

        }

        public List<Component> GetComponents()
        {
            List<Component> ListComponents = new List<Component>();
            using (var db = new LiteDatabase(Path))
            {
                var components = db.GetCollection<Component>(typeof(Component).Name);
                ListComponents = components.FindAll().ToList();
            }
            return ListComponents;
        }
        public string PrintComponents(List<Component> Components)
        {
            string result = "";
            foreach (var item in Components)
            {
                result += item.ToString();
            }
            return result;
        }
        public Component GetComponentID(int ID)
        {
            List<Component> ListComponents = new List<Component>();
            Component component = new Component();
            using (var db = new LiteDatabase(Path))
            {
                var components = db.GetCollection<Component>(typeof(Component).Name);
                ListComponents = components.FindAll().ToList();
                component = ListComponents.Find(x => x.ComponentID == ID);
            }
            return component;
        }
    }
}
