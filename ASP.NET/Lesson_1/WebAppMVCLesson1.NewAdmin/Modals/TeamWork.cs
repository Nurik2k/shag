using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVCLesson1.NewAdmin.Modals
{
    public class TeamWork
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(250)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(250)]
        public string LastName { get; set; }

        [StringLength(1024)]
        public string AboutWork { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(250)]
        public string Autor { get; set; } = "Admin";

        [StringLength(4000)]
        public string LinkedIn { get; set; }

        [StringLength(4000)]
        public string Instagram { get; set; }

        [StringLength(4000)]
        public string FaceBook { get; set; }

      
        public bool Status { get; set; }

        [Required]
        public int JobPositionId { get; set; }

        [StringLength(4000)]
        public string Photo { get; set; }

        public JobPosition jobPosition { get; set; }

    }
}
