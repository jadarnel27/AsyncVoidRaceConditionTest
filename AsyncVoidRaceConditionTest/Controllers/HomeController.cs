using System.Web.Mvc;

namespace AsyncVoidRaceConditionTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
