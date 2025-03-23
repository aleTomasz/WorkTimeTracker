using System;
using System.Collections.Generic;

namespace WorkTimeTracker.Models
{
    public class WorkLogDaySummary
    {
        public DateTime Date { get; set; }
        public TimeSpan TotalTime { get; set; }
        public List<WorkLog> Logs { get; set; }
    }
}