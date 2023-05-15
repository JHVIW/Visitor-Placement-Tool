using Microsoft.AspNetCore.Mvc;
using Logic;
using DTO;
using Interfaces;
using System.Diagnostics;

namespace Visitor_Placement_Tool.Controllers
{
    public class EvenementController : Controller
    {
        private readonly EvenementManager _evenementManager;

        public EvenementController(IEvenementDAL evenementDAL, IVakDAL vakDAL, IRijDAL rijDAL, IStoelDAL stoelDAL)
        {
            _evenementManager = new EvenementManager(evenementDAL, vakDAL, rijDAL, stoelDAL);
        }

        public IActionResult Index()
        {
            var evenementen = _evenementManager.HaalAlleEvenementenOp();
            return View(evenementen);
        }

        public IActionResult Aanmaken()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Aanmaken(Evenement evenement, int evenementId)
        {

            Debug.WriteLine(System.Text.Json.JsonSerializer.Serialize(evenement));
            evenement.ID = evenementId;

            _evenementManager.MaakEvenement(
                evenement.ID,
                evenement.Naam,
                evenement.Datum,
                evenement.MaximumAantalBezoekers
            );
            return RedirectToAction("Index");


            return View(evenement);
        }

        public IActionResult Bewerken()
        {
            int id = int.Parse(Request.Query["id"]);
            var evenement = _evenementManager.HaalEvenementOp(id);

            if (evenement == null)
            {
                return NotFound();
            }

            return View(evenement);
        }

        [HttpPost]
        public IActionResult Bewerken(int id, Evenement evenement)
        {

            _evenementManager.UpdateEvenement(id, evenement.Naam, evenement.Datum, evenement.MaximumAantalBezoekers);
            return RedirectToAction("Index");

            return View(evenement);
        }

        public IActionResult Verwijderen(int id)
        {

            _evenementManager.VerwijderEvenement(id);

            return RedirectToAction("Index");

        }
    }
}