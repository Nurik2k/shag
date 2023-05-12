using System;
using System.Collections.Generic;

namespace ATR.WebApi.Models
{
    public partial class PageStatistic
    {
        public int PageStatisticId { get; set; }
        public string? Path { get; set; }
        public string? PathBase { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
