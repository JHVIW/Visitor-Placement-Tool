using Microsoft.AspNetCore.Mvc;

namespace Visitor_Placement_Tool.Controllers
{
    public class VakController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
