using Microsoft.AspNet.Identity;
using PassionProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PassionProject.Controllers
{
    public class PairingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pairing
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// When called it populates a list from the Pairs table, shuffles it, then sends it to the view
        /// </summary>
        /// <returns>Shuffled list of strings containing html buttons used for the pairing functionality</returns>
        /// <reference>https://github.com/christinebittle/varsity_w_auth/blob/master/varsity_w_auth/Controllers/PlayerDataController.cs</reference>
        [Authorize]
        [HttpGet]
        public ActionResult StartRound()
        {
            //Get the pair settings from the UserSettings table
            string userid = User.Identity.GetUserId();
            int numberOfPairs = Convert.ToInt32(db.UserSettings.Where(c => c.UserID == userid).FirstOrDefault().NumberOfPairs.ToString());
            List<Pair> Pairs = db.Pairs.Where(x => x.AlphabetID == 1).Take(numberOfPairs).ToList();
            List<PairDto> PairDtos = new List<PairDto>();

            foreach (var pair in Pairs)
            {
                PairDto NewPair = new PairDto
                {
                    PairID = pair.PairID,
                    EnglishLetter = pair.EnglishLetter,
                    JapaneseLetter = pair.JapaneseLetter,
                    AlphabetID = pair.AlphabetID
                };
                PairDtos.Add(NewPair);
            }

            //List to store the html tags that will be displayed in the view
            List<string> ElementsList = new List<string>();

            //Variable to make the element strings which will be added to the list
            string tempValue;
            foreach (var item in PairDtos)
            {
                tempValue = "<button id='" + item.EnglishLetter + "' class='PairButton " + item.PairID + "'>" + item.EnglishLetter + "</button>";
                ElementsList.Add(tempValue);
                tempValue = "<button id='" + item.JapaneseLetter + "' class='PairButton " + item.PairID + "'>" + item.JapaneseLetter + "</button>";
                ElementsList.Add(tempValue);
            }
            //Shuffling the list before returning it to the view
            Shuffle(ElementsList);
            return View(ElementsList);
        }

        //Reference: https://stackoverflow.com/questions/273313/randomize-a-listt
        private static Random rng = new Random();

        public static void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        [HttpGet]
        public ActionResult Help()
        {
            List<Pair> Pairs = db.Pairs.Where(x => x.AlphabetID == 1).ToList();
            List<PairDto> PairDtos = new List<PairDto>();

            foreach (var pair in Pairs)
            {
                PairDto NewPair = new PairDto
                {
                    PairID = pair.PairID,
                    EnglishLetter = pair.EnglishLetter,
                    JapaneseLetter = pair.JapaneseLetter,
                    AlphabetID = pair.AlphabetID
                };
                PairDtos.Add(NewPair);
            }

            //Return the list
            return View(PairDtos);
        }
    }
}