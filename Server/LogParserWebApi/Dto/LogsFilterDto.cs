using System;

namespace Dto
{
    public class LogsFilterDto
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public int? Limit { get; set; } = 10;
        public int? Offset { get; set; } = 0;
    }
}