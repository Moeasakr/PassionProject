using PassionProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace PassionProject.Controllers
{
    public class StatisticsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Statistics
        /// <summary>
        /// Gets the statistics data for the current logged in user from the database
        /// </summary>
        /// <returns>Statistics data for the current user</returns>
        public ActionResult GetStatistics()
        {
            string userID = User.Identity.GetUserId();
            List<Statistic> statistics = db.Statistics.Where(x => x.UserID == userID).ToList();
            
            return View(statistics);
        }

        /// <summary>
        /// Redirects to a confirmation page to ask the user if they are sure about deleting their statistics
        /// </summary>
        /// <returns>Redirects to ConfirmDelete view</returns>
        [HttpGet]
        public ActionResult DeleteConfirm()
        {
            return View();
        }


        /// <summary>
        /// Deletes the statistics for the currently logged in user
        /// </summary>
        /// <returns>Redirects to the GetStatistics view</returns>
        [HttpPost]
        public ActionResult Delete()
        {
            string userID = User.Identity.GetUserId();

            List<Statistic> statictics = db.Statistics.Where(x => x.UserID == userID).ToList();
            foreach (var stat in statictics)
            {
                db.Statistics.Remove(stat);
            }
            db.SaveChanges();

            return RedirectToAction("GetStatistics");
        }

        /// <summary>
        /// Adds the round data to the statistics page
        /// </summary>
        /// <param name="numberOfPairs">Number of pairs in the round</param>
        /// <param name="status">Status of 1 for a successful round and 0 for a failed round</param>
        /// <param name="fails">Amount of fails in a round</param>
        [HttpPost]
        public void AddStatistic(int numberOfPairs, int status, int fails)
        {
            string userID = User.Identity.GetUserId();

            Statistic statistic = new Statistic();
            statistic.AlphabetID = 1;
            statistic.NumberOfFailedPairs = fails;
            statistic.UserID = userID;
            statistic.Status = status;
            statistic.NumberOfPairs = numberOfPairs;

            db.Statistics.Add(statistic);
            db.SaveChanges();
        }
    }
}