using Microsoft.AspNetCore.Mvc;

namespace Visitor_Placement_Tool.Controllers
{
    public class EvenementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
