using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;
using System.Threading;

namespace workwithidentity.Controllers
{
    public class HomeController : Controller
    {
        [RequireHttps]
        public ActionResult Index()
        {
            return View();
        }

        public string GetAge()
        {
            var identity = (GenericPrincipal)Thread.CurrentPrincipal;
            var age = identity.Claims.Where(x => x.Type == "age").Select(x => x.Value).SingleOrDefault();
            return age;
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