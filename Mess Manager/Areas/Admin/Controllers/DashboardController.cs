using Microsoft.AspNetCore.Mvc;

namespace Mess_Manager.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
