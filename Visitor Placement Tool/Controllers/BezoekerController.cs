using Microsoft.AspNetCore.Mvc;

namespace Visitor_Placement_Tool.Controllers
{
    public class BezoekerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
