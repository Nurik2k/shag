namespace BookStore.lib
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Events
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime CreateDate { get; set; }

        public bool Status { get; set; }
    }
}
