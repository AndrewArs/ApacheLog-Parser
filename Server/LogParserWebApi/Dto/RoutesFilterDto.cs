using System;

namespace Dto
{
    public class RoutesFilterDto
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public int? N { get; set; } = 10;
    }
}