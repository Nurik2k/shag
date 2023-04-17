using System.ComponentModel.DataAnnotations;

namespace WebAppMVCLesson1.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
