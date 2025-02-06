using Microsoft.AspNetCore.Mvc;
using Task_Management_System.Services;

namespace Task_Management_System.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ITasksService _tasksService;
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(ITasksService tasksService, ILogger<DashboardController> logger)
        {
            _tasksService = tasksService;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var alltasks = await _tasksService.GetAllTasksWithStatus();
                var pendingtasks = alltasks.Select(x => x.Status == "Pending").ToList();
                var inProgresstasks = alltasks.Select(x => x.Status == "In Progress").ToList();
                var completedtasks = alltasks.Select(x => x.Status == "Completed").ToList();
                int pendingtaskCount = 0;
                int inProgresstaskCount = 0;
                int completedtaskCount = 0;

                foreach (var item in pendingtasks)
                {
                    if (item == true)
                    {
                        pendingtaskCount++;
                    }
                }
                foreach (var item in inProgresstasks)
                {
                    if (item == true)
                    {
                        inProgresstaskCount++;
                    }
                }
                foreach (var item in completedtasks)
                {
                    if (item == true)
                    {
                        completedtaskCount++;
                    }
                }
                var totalTasks = pendingtaskCount + inProgresstaskCount + completedtaskCount;
                ViewBag.totaltasksPercent = "100%";
                ViewBag.pendingtasksPercent = $"{(float)pendingtaskCount / totalTasks * 100}%";
                ViewBag.inProgresstasksPercent = $"{(float)inProgresstaskCount / totalTasks * 100}%"; ;
                ViewBag.completedtasksPercent = $"{(float)completedtaskCount / totalTasks * 100}%"; ;
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public async Task<IActionResult> AllStatusTasks()
        {
            try
            {
                var alltasks = await _tasksService.GetAllTasksWithStatus();
                var pendingtasks = alltasks.Select(x => x.Status == "Pending").ToList();
                var inProgresstasks = alltasks.Select(x => x.Status == "In Progress").ToList();
                var completedtasks = alltasks.Select(x => x.Status == "Completed").ToList();
                int pendingtaskCount = 0;
                int inProgresstaskCount = 0;
                int completedtaskCount = 0;

                foreach (var item in pendingtasks)
                {
                    if (item == true)
                    {
                        pendingtaskCount++;
                    }
                }
                foreach (var item in inProgresstasks)
                {
                    if (item == true)
                    {
                        inProgresstaskCount++;
                    }
                }
                foreach (var item in completedtasks)
                {
                    if (item == true)
                    {
                        completedtaskCount++;
                    }
                }

                return Json(new { pendingtaskCount, inProgresstaskCount, completedtaskCount });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

        }
    }
}
