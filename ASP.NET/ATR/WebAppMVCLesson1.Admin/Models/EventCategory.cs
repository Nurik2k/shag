using System.ComponentModel.DataAnnotations;

namespace WebAppMVCLesson1.Admin.Models
{
    public class EventCategory
    {
        [Key]
        public int EventCategoryId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
