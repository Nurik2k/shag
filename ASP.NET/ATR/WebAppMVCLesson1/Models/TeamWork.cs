using System;
using System.Collections.Generic;

namespace WebAppMVCLesson1.Models
{
    public partial class TeamWork
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string AboutWork { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string Autor { get; set; } = null!;
        public string LinkedIn { get; set; } = null!;
        public string Instagram { get; set; } = null!;
        public string FaceBook { get; set; } = null!;
        public bool Status { get; set; }
        public string Photo { get; set; } = null!;
        public int JobPositionId { get; set; }

        public virtual JobPosition JobPosition { get; set; } = null!;
    }
}
