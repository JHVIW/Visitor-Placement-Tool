using DTO;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Visitor_Placement_Tool.Controllers
{
    public class RegistratieController : Controller
    {
        private readonly IEvenementDAL _evenementDAL;
        private readonly IBezoekerDAL _bezoekerDAL;
        private readonly IGroepDAL _groepDAL;

        public RegistratieController(IEvenementDAL evenementDAL, IBezoekerDAL bezoekerDAL, IGroepDAL groepDAL)
        {
            _evenementDAL = evenementDAL;
            _bezoekerDAL = bezoekerDAL;
            _groepDAL = groepDAL;
        }

        public ActionResult Index()
        {
            var evenementen = _evenementDAL.GetAllEvenementen();
            return View(evenementen);
        }

        [HttpGet]
        public ActionResult Registreren(int id)
        {
            var evenement = _evenementDAL.GetEvenementById(id);
            return View(evenement);
        }

        [HttpPost]
        public ActionResult Registreren(Bezoeker bezoeker)
        {
            bezoeker.Groep_ID = 0;  
            _bezoekerDAL.CreateBezoeker(bezoeker);
            TempData["SuccessMessage"] = "Bezoeker succesvol geregistreerd.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RegistrerenGroep(Groep groep, List<Bezoeker> bezoekers)
        {
            // Zorg ervoor dat er minstens één volwassene in de groep zit
            if (groep.VolwassenenAantal < 1)
            {
                ModelState.AddModelError("GeenVolwassene", "Er moet minimaal één volwassene in de groep zitten.");
                return RedirectToAction("Index");
            }

            var evenement = _evenementDAL.GetEvenementById(groep.Evenement_ID);

            // Genereer een random Groep_ID voor de hele groep
            var randomGroepId = new Random().Next();

            foreach (var bezoeker in bezoekers)
            {
                // Bereken leeftijd op basis van de datum van het evenement
                var leeftijd = evenement.Datum.Subtract(bezoeker.Geboortedatum).Days / 365;

                // Controleer of het een kind is (leeftijd onder de 13)
                if (leeftijd < 13)
                {
                    // Controleer of er minimaal één volwassene in de groep zit
                    if (groep.VolwassenenAantal < 1)
                    {
                        ModelState.AddModelError("GeenVolwassene", "Er moet minimaal één volwassene in de groep zitten.");
                        return RedirectToAction("Index");
                    }
                }

                // Wijs het random Groep_ID toe aan de bezoeker
                bezoeker.Groep_ID = randomGroepId;
                _bezoekerDAL.CreateBezoeker(bezoeker);
            }

            _groepDAL.CreateGroep(groep);

            return RedirectToAction("Index");
        }
    }
}
