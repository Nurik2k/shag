using System;
using System.Collections.Generic;

namespace WebAppMVCLesson1.Models
{
    public partial class JobPosition
    {
        public JobPosition()
        {
            TeamWorks = new HashSet<TeamWork>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreateDate { get; set; }

        public virtual ICollection<TeamWork> TeamWorks { get; set; }
    }
}
