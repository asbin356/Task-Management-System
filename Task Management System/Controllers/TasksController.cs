using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Task_Management_System.Models;
using Task_Management_System.Services;

namespace Task_Management_System.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITasksService _tasksService;
        private readonly ILogger<TasksController> _logger;

        public TasksController(ITasksService tasksService, ILogger<TasksController> logger)
        {
            _tasksService = tasksService;
            _logger = logger;
        }
        public async Task<IActionResult> AllTasks()
        {
            try
            {
                var alltasks = await _tasksService.GetAllTasksWithStatus();
                return Json(new { data = alltasks });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        //GET:/tasks/TasksWithStatus?filterOn=Title&filterQuery=Status
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var alltasks = await _tasksService.GetAllTasksWithStatus();
                return View(alltasks);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TasksWithStatus tasksWithStatus)
        {
            try
            {
                await _tasksService.AddTasksAsync(tasksWithStatus);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var alltasks = await _tasksService.GetTasksByIdAsync(id);
                return View(alltasks);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TasksWithStatus tasksWithStatus)
        {
            try
            {
                await _tasksService.UpdateTasksAsync(tasksWithStatus);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _tasksService.DeleteTasksAsync(id);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
