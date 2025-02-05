using Microsoft.AspNetCore.Mvc;
using Task_Management_System.Models;
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
        //GET:/tasks/TasksWithStatus?filterOn=Title&filterQuery=Status
        public async Task<IActionResult> GetAllTasks([FromQuery]string? filterOn, [FromQuery]string? filterQuery)
        {
            var alltasks = await _tasksService.GetAllTasksWithStatus();
            return View(alltasks);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TasksWithStatus tasksWithStatus)
        {
            await _tasksService.AddTasksAsync(tasksWithStatus);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var alltasks = await _tasksService.GetTasksByIdAsync(id);
            return View(alltasks);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TasksWithStatus tasksWithStatus)
        {
            await _tasksService.UpdateTasksAsync(tasksWithStatus);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _tasksService.DeleteTasksAsync(id);
            return RedirectToAction("Index");
        }
    }
}
