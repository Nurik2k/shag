using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tasks9.BLL
{
    public class EditionService
    {
        private List<Edition> editionList = new List<Edition>();
        public EditionService()
        {
            
            editionList.Add(new Book()
            {
                Title = "Алые Паруса",
                Author = "Александр Грин",
                PublishYear = new DateTime(1916),
                Director = "Александр Грин"
            });
            editionList.Add(new Article("Влияние телефонов на восприятие на задних парт", "SEP-"));

            
        }
        public Edition this[int index]
        {
            get { return editionList[index]; }
            set { editionList[index] = value; }
        }
      
    }
}
