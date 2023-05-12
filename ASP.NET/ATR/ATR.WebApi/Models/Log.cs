using System;
using System.Collections.Generic;

namespace ATR.WebApi.Models
{
    public partial class Log
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public string? MessageTemplate { get; set; }
        public string? Level { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string? Exception { get; set; }
        public string? Properties { get; set; }
        public string? LogEvent { get; set; }
        public string? UserName { get; set; }
        public string? Ip { get; set; }
    }
}
