using Microsoft.AspNetCore.Mvc;

namespace Task_Management_System.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
