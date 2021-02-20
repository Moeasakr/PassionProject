using PassionProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PassionProject.Controllers
{
    public class SettingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Settings
        public ActionResult Index()
        {



            return View();
        }

    }
}