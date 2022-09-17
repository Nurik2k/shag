using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeConstruction
{
    internal class House
    {
        private List<Ipart> Parts = new List<Ipart>();
        public House() { }
        public void CreateHouse(int num)
        {
            switch (num)
            {
                case 1: 
                    Basemant basemant = new Basemant();
                    basemant.color = "White";
                    basemant.constructionTime = new TimeSpan(5, 8, 0, 0);
                    basemant.count = 1;
                    basemant.priceMaterial = 8000;
                    Walls walls = new Walls();
                    walls.color = null;
                    walls.constructionTime = new TimeSpan(0, 9, 2, 0);
                    walls.count = 8;
                    walls.priceMaterial = 600;
                    Door door = new Door();
                    door.color = null;
                    door.constructionTime = new TimeSpan(0, 2, 0, 0);
                    door.count = 5;
                    door.priceMaterial = 100;
                    Window window =new Window();
                    window.color = null;
                    window.constructionTime = new TimeSpan(0, 3, 2, 1);
                    window.count = 12;
                    window.priceMaterial = 300;
                    Roof roof = new Roof();
                    roof.color = "Коричневый";
                    roof.constructionTime = new TimeSpan(1, 4, 8, 3);
                    roof.count = 1;
                    roof.priceMaterial = 533;
                    break;
            }
        }
    }
}
