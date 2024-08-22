using Microsoft.AspNetCore.Mvc;

namespace BookMgr.Controllers
{
    public class PublisherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
