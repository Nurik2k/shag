namespace WebAppMVCLesson1.Admin.Models
{
    public class customOptionsConfiguration
    {
        public bool boolOption { get; set; }
        public int numberOption { get; set; }
        public DateTime dateOption { get; set; }
        public complexOption complexOption { get; set; }
    }

    public class complexOption
    {
        public string optin1 { get; set; }
        public string option2 { get; set; }
    }
}
