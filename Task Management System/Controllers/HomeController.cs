using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Task_Management_System.Models;
using Task_Management_System.Services;

namespace Task_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITasksService _tasksService;

        public HomeController(ILogger<HomeController> logger, ITasksService tasksService)
        {
            _logger = logger;
            _tasksService = tasksService;
        }

        public async Task<IActionResult> Index()
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
