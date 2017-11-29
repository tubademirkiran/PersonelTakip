using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PT.Web.MVC.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles ="Admin,User")]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}