using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson011
{
    [Serializable]
    public class Usercv
    {
        public int UserId { get; set; }
        public string FName { get; set; }
        public string SName { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime Dob { get; set; }
        public Usercv()
        {

        }
        public Usercv(string FName, string SName, int PhoneNumber, int Year)
        {
            this.FName = FName ;
            this.SName = SName ;
            this.PhoneNumber = PhoneNumber ;
            this.Dob = new DateTime(Year);
        }
        
      
        public override string ToString()
        {
            return String.Format("ID: {0};\nFUllName: {1}", UserId, FName);
        }
    }
}
