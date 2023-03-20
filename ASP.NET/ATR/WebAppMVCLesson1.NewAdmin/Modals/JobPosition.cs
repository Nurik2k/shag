using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMVCLesson1.NewAdmin.Modals
{
    public class JobPosition
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public virtual ICollection<TeamWork> Works { get; set; }
    }
}
