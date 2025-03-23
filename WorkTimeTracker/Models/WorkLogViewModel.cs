﻿using System.Collections.Generic;

namespace WorkTimeTracker.Models
{
    public class WorkLogViewModel
    {
        public List<WorkLogDaySummary> DaySummaries { get; set; }
        public WorkLog? OngoingLog { get; set; }
    }
}