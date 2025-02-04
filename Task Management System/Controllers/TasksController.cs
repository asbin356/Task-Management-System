using Microsoft.AspNetCore.Mvc;
using Task_Management_System.Services;

namespace Task_Management_System.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }
        public async Task<IActionResult> AllTasks()
        {
            var alltasks = await _tasksService.GetAllTasksWithStatus();
            return Json(new { data = alltasks });
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateUpdate(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUpdate(int id)
        { 
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View();
        }

    }
}
