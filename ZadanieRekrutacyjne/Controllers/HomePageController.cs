using Microsoft.AspNetCore.Mvc;

namespace EmployersAndTasks.Controllers
{
    public class HomePageController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
