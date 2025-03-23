using Microsoft.AspNetCore.Mvc;
using WorkTimeTracker.Data;
using WorkTimeTracker.Models;

namespace WorkTimeTracker.Controllers
{
    public class WorkLogController : Controller
    {
        private readonly AppDbContext _context;

        public WorkLogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Znajdź aktywny (rozpoczęty, ale niezakończony) wpis
            var ongoing = _context.WorkLogs
                .Where(w => w.EndTime == null)
                .OrderByDescending(w => w.StartTime)
                .FirstOrDefault();

            // Grupa tylko zakończone wpisy
            var groupedLogs = _context.WorkLogs
                .Where(w => w.EndTime != null)
                .AsEnumerable()
                .GroupBy(w => w.StartTime.Date)
                .Select(g => new WorkLogDaySummary
                {
                    Date = g.Key,
                    TotalTime = TimeSpan.FromSeconds(g
                        .Where(w => w.Duration.HasValue)
                        .Sum(w => w.Duration.Value.TotalSeconds)),
                    Logs = g.ToList()
                })
                .OrderByDescending(d => d.Date)
                .ToList();

            var model = new WorkLogViewModel
            {
                DaySummaries = groupedLogs,
                OngoingLog = ongoing
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Start()
        {
            var log = new WorkLog { StartTime = DateTime.Now };
            _context.WorkLogs.Add(log);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Stop(int id)
        {
            var log = _context.WorkLogs.Find(id);
            if (log != null && log.EndTime == null)
            {
                log.EndTime = DateTime.Now;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}