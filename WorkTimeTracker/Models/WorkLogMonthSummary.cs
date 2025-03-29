using System;
using System.Collections.Generic;

namespace WorkTimeTracker.Models
{
    public class WorkLogMonthSummary
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public TimeSpan TotalTime { get; set; }
    }
}