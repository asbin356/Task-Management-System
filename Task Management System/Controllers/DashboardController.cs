using Microsoft.AspNetCore.Mvc;
using Task_Management_System.Services;

namespace Task_Management_System.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ITasksService _tasksService;

        public DashboardController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AllStatusTasks()
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
            return Json(new { pendingtaskCount, inProgresstaskCount, completedtaskCount});
        }
    }
}
