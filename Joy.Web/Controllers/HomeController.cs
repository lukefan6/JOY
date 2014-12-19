using System.Web.Mvc;
using Joy.Core;

namespace Joy.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(MrtHelper.TestCustomSearch());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}