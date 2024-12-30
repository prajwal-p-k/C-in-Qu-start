using Microsoft.AspNetCore.Mvc;

namespace Particecode.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
