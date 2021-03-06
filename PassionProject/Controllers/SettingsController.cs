using PassionProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace PassionProject.Controllers
{
    public class SettingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Settings
        [Authorize]
        public ActionResult Index()
        {
            //Source: https://stackoverflow.com/questions/29485285/can-not-find-user-identity-getuserid-method
            var userID = User.Identity.GetUserId();

            UserSettings userSettings = db.UserSettings.Where(x => x.UserID == userID).FirstOrDefault();

            return View(userSettings);
        }


        /// <summary>
        /// Updates the UserSettings table with the new user settings
        /// </summary>
        /// <param name="pairs">The value of the radio button in the settings index page</param>
        /// <param name="successRate">State of success rate check box</param>
        /// <returns>Redirects to the index view</returns>
        [Authorize]
        [HttpPost]
        public ActionResult UpdateSettings(int pairs, int successRate)
        {
            var userID = User.Identity.GetUserId();

            UserSettings setting = db.UserSettings.Where(x => x.UserID == userID).FirstOrDefault();

            setting.NumberOfPairs = pairs;
            setting.LowSuccessRate = successRate;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}