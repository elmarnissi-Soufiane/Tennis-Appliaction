using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TennisApp.Models;

namespace TennisApp.App_Start
{
    public class TennisController : Controller
    {
        db_TennisEntities db = new db_TennisEntities();

        public ActionResult Index()
        {
            IList<Rencontre> rencontres = db.Rencontres.ToList();

            return View(rencontres);
        }

        public ActionResult Details(string nomGagnant, string nomPerdant, string nomTournoi, DateTime dateTournoi)
        {
            Rencontre r = db.Rencontres.Find(nomGagnant, nomPerdant, nomTournoi, dateTournoi);
            return View(r);
        }

        // Cheking the top player with score 

       /* public ActionResult TopScore(string nomJoueur)
        {
            var topScore = (from r in db.Rencontres
                            where r.NomGagnant == nomJoueur || r.NomPerdant == nomJoueur
                            group r by (r.NomGagnant == nomJoueur ? r.NomPerdant : r.NomGagnant) into g
                            select new TopScoreViewModel
                            {
                                NomGagnant = nomJoueur,
                                PrenomGagnant = db.Joueurs.Where(j => j.Nom == nomJoueur).Select(j => j.Prenom).FirstOrDefault(),
                                NomPerdant = g.Key,
                                PrenomPerdant = db.Joueurs.Where(j => j.Nom == g.Key).Select(j => j.Prenom).FirstOrDefault(),
                                Score = g.Max(r => r.Score)
                            }).OrderByDescending(vm => vm.Score).FirstOrDefault();

            return View(topScore);
        }*/

        public ActionResult TopScore()
        {

            var topScore = (from r in db.Rencontres
                            join g in db.Joueurs on r.NomGagnant equals g.Nom
                            join p in db.Joueurs on r.NomPerdant equals p.Nom
                            group r by g into gGroup
                            select new TopScoreViewModel
                            {
                                NomGagnant = gGroup.Key.Nom,
                                PrenomGagnant = gGroup.Key.Prenom,
                                Score = gGroup.Max(r => r.Score)
                            }).OrderByDescending(vm => vm.Score).FirstOrDefault();

            return View(new List<TopScoreViewModel> { topScore });

            /*var topScores = (from r in db.Rencontres
                             join g in db.Joueurs on r.NomGagnant equals g.Nom
                             join p in db.Joueurs on r.NomPerdant equals p.Nom
                             join t in db.Tournois on r.NomTournoi equals t.NomTournoi
                             orderby r.DateTournoi descending
                             select new TopScoreViewModel
                             {
                                 NomGagnant = r.NomGagnant,
                                 PrenomGagnant = g.Prenom,
                                 NomPerdant = r.NomPerdant,
                                 PrenomPerdant = p.Prenom,
                                 NomTournoi = r.NomTournoi,
                                 DateTournoi = r.DateTournoi,
                                 Score = r.Score
                             }).ToList();
            return View(topScores);*/

            /*var list_pay = (from r in db.Rencontres
                            join g in db.Joueurs
                            on r.NomGagnant equals g.Nom
                            join j in db.Joueurs
                            on r.NomPerdant equals j.Nom
                            join t in db.Tournois
                            on r.NomTournoi equals t.NomTournoi
                            orderby r.DateTournoi descending
                            select new { r.NomGagnant, g.Prenom, r.NomPerdant, j.Prenom, r.NomTournoi, r.DateTournoi, r.Score }
                                        ).ToList();

            //return View(rencontres);*/
        }

        // GET: Tennis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tennis/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tennis/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tennis/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tennis/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tennis/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
