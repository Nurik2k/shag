using System;
using System.Collections.Generic;
using System.Text;

namespace ls4
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public DateTime Birth { get; set; }
        public string IIN { get; set; }
        public string Sex { get; set; }
        public string NumberPhone { get; set; }
        
        public Address Address { get; set; }
        
        public int Age
        {
            get
            {
                return DateTime.Now - Birth.Year;
            }
        }
        public string FullName
        {
            get
            {
                return Name + " " + SecondName;
            }
        }
        public string ShortName
        {
            get
            {
                return string.Format("{0} {1}.", Name, SecondName[0]);
            }
        }
        public string Password { get; set; }
       
    }
}
