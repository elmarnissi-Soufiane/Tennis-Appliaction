using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using TennisApp.Models;

namespace TennisApp.Controllers
{
    public class JoueurController : Controller
    {
        // GET: Joueur

        db_TennisEntities db = new db_TennisEntities();
        public ActionResult IndexJR()
        {
            IList<Joueur> jr = db.Joueurs.ToList();
            return View(jr);
        }

        // GET: Joueur/Details/5
        public ActionResult Details(String Nom)
        {

            Joueur jr = db.Joueurs.Find(Nom);

            return View(jr);
        }

        // Me 
        /*public ActionResult DetailsJR(string joueur1, string joueur2)
        {
            // Récupérer les noms de tous les joueurs
            var joueurs = db.Joueurs.Select(j => j.Nom).ToList();

            // Ajouter les noms de joueurs aux DropDownLists
            ViewBag.Joueurs1 = new SelectList(joueurs);
            ViewBag.Joueurs2 = new SelectList(joueurs);

            // Vérifier si les deux joueurs ont été sélectionnés
            if (string.IsNullOrEmpty(joueur1) || string.IsNullOrEmpty(joueur2))
            {
                return View();
            }

            var rencontres = db.Rencontres.Where(r => (r.NomGagnant == joueur1 && r.NomPerdant == joueur2) || (r.NomGagnant == joueur2 && r.NomPerdant == joueur1)).ToList();

            var score1 = rencontres.Sum(r => int.Parse(r.Score));
            var score2 = rencontres.Sum(r => int.Parse(r.Score));

            // Créer un modèle pour la vue
            var model = new DetailsJRModel
            {
                Joueur1 = joueur1,
                Joueur2 = joueur2,
                Score1 = score1,
                Score2 = score2
            };

            return View(model);
        }*/

        /* public ActionResult DetailsJR(string joueur1, string joueur2)
         {
             // Récupérer les noms de tous les joueurs
             var joueurs = db.Joueurs.Select(j => j.Nom).ToList();

             // Ajouter les noms de joueurs aux DropDownLists
             ViewBag.Joueurs1 = new SelectList(joueurs);
             ViewBag.Joueurs2 = new SelectList(joueurs);

             // Vérifier si les deux joueurs ont été sélectionnés
             if (string.IsNullOrEmpty(joueur1) || string.IsNullOrEmpty(joueur2))
             {
                 return View();
             }

             // Récupérer les scores des deux joueurs
             var regex = new Regex(@"^\d+/\d+-\d+/\d+-\d+/\d+-\d+/\d+$");
             var score1 = db.Rencontres.Where(r => (r.NomGagnant == joueur1 && r.NomPerdant == joueur2) || (r.NomGagnant == joueur2 && r.NomPerdant == joueur1))
                                       .Select(r => r.Score)
                                       .ToList()
                                       .FirstOrDefault(s => regex.IsMatch(s));
             var score2 = db.Rencontres.Where(r => (r.NomGagnant == joueur1 && r.NomPerdant == joueur2) || (r.NomGagnant == joueur2 && r.NomPerdant == joueur1))
                                       .Select(r => r.Score)
                                       .ToList()
                                       .FirstOrDefault(s => regex.IsMatch(s));

             // Vérifier si les scores sont valides
             if (score1 == null || score2 == null)
             {
                 return View();
             }

             // Convertir les scores en entiers et les ajouter au modèle pour la vue
             var score1Int = score1.Split('-').Sum(s => int.Parse(s.Split('/')[0]));
             var score2Int = score2.Split('-').Sum(s => int.Parse(s.Split('/')[0]));
             var model = new DetailsJRModel
             {
                 Joueur1 = joueur1,
                 Joueur2 = joueur2,
                 Score1 = score1Int.ToString(),
                 Score2 = score2Int.ToString()
             };

             return View(model);
         }*/

        /*public ActionResult DetailsJR(string joueur1, string joueur2)
        {
            // Récupérer les noms de tous les joueurs
            var joueurs = db.Joueurs.Select(j => j.Nom).ToList();

            // Ajouter les noms de joueurs aux DropDownLists
            ViewBag.Joueurs1 = new SelectList(joueurs);
            ViewBag.Joueurs2 = new SelectList(joueurs);

            // Vérifier si les deux joueurs ont été sélectionnés
            if (string.IsNullOrEmpty(joueur1) || string.IsNullOrEmpty(joueur2))
            {
                return View();
            }

            // Récupérer les scores des deux joueurs
            var regex = new Regex(@"^\d+/\d+-\d+/\d+-\d+/\d+-\d+/\d+$");
            var score1 = db.Rencontres.Where(r => (r.NomGagnant == joueur1 && r.NomPerdant == joueur2) || (r.NomGagnant == joueur2 && r.NomPerdant == joueur1))
                                      .Select(r => r.Score)
                                      .ToList()
                                      .FirstOrDefault(s => regex.IsMatch(s));
            var score2 = db.Rencontres.Where(r => (r.NomGagnant == joueur1 && r.NomPerdant == joueur2) || (r.NomGagnant == joueur2 && r.NomPerdant == joueur1))
                                      .Select(r => r.Score)
                                      .ToList()
                                      .FirstOrDefault(s => regex.IsMatch(s));

            // Vérifier si les scores sont valides
            if (score1 == null || score2 == null)
            {
                return View();
            }

            // Convertir les scores en entiers et les ajouter au modèle pour la vue
            var score1Int = score1.Split('-').Sum(s => int.Parse(s.Split('/')[0]));
            var score2Int = score2.Split('-').Sum(s => int.Parse(s.Split('/')[0]));

            // Vérifier si les scores sont égaux
            if (score1Int == score2Int)
            {
                var model = new DetailsJRModel
                {
                    Joueur1 = joueur1,
                    Joueur2 = joueur2,
                    Score1 = score1Int.ToString(),
                    Score2 = score2Int.ToString()
                };
                return View(model);
            }
            else
            {
                var model = new DetailsJRModel
                {
                    Joueur1 = joueur1,
                    Joueur2 = joueur2,
                    Score1 = score1Int.ToString(),
                    Score2 = score2Int.ToString(),
                    Resultat = score1Int > score2Int ? $"{joueur1} est meilleur que {joueur2}" : $"{joueur2} est meilleur que {joueur1}"
                };
                return View(model);
            }
        }*/

        public ActionResult DetailsJR(string joueur1, string joueur2)
        {
            // Récupérer les noms de tous les joueurs
            var joueurs = db.Joueurs.Select(j => j.Nom).ToList();

            // Ajouter les noms de joueurs aux DropDownLists
            ViewBag.Joueurs1 = new SelectList(joueurs);
            ViewBag.Joueurs2 = new SelectList(joueurs);

            // Vérifier si les deux joueurs ont été sélectionnés
            if (string.IsNullOrEmpty(joueur1) || string.IsNullOrEmpty(joueur2))
            {
                return View();
            }

            // Récupérer les scores des deux joueurs
            var regex = new Regex(@"^\d+/\d+-\d+/\d+-\d+/\d+-\d+/\d+$");
            var score1 = db.Rencontres.Where(r => (r.NomGagnant == joueur1 && r.NomPerdant == joueur2) || (r.NomGagnant == joueur2 && r.NomPerdant == joueur1))
                                        .Select(r => r.Score)
                                        .ToList()
                                        .FirstOrDefault(s => regex.IsMatch(s));
            var score2 = db.Rencontres.Where(r => (r.NomGagnant == joueur1 && r.NomPerdant == joueur2) || (r.NomGagnant == joueur2 && r.NomPerdant == joueur1))
                                        .Select(r => r.Score)
                                        .ToList()
                                        .FirstOrDefault(s => regex.IsMatch(s));

            // Vérifier si les scores sont valides
            if (score1 == null || score2 == null)
            {
                return View();
            }

            // Convertir les scores en entiers et les ajouter au modèle pour la vue
            var score1Int = score1.Split('-').Sum(s => int.Parse(s.Split('/')[0]));
            var score2Int = score2.Split('-').Sum(s => int.Parse(s.Split('/')[0]));

            // Ajouter les scores au modèle pour la vue
            var model = new DetailsJRModel
            {
                Joueur1 = joueur1,
                Joueur2 = joueur2,
                Score1 = score1Int.ToString(),
                Score2 = score2Int.ToString()
            };

            return View(model);
        }


        // GET: Joueur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Joueur/Create
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

        // GET: Joueur/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Joueur/Edit/5
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

        // GET: Joueur/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Joueur/Delete/5
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
