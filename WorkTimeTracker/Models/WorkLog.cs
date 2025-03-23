using System;
using System.ComponentModel.DataAnnotations;

namespace WorkTimeTracker.Models
{
    public class WorkLog
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public TimeSpan? Duration
        {
            get
            {
                if (StartTime != null && EndTime != null)
                    return EndTime - StartTime;
                return null;
            }
        }

        public DateTime LogDate => StartTime.Date;
    }
}