using Microsoft.AspNetCore.Mvc;
using Interfaces;
using DTO;
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
            var bestaandeBezoeker = _bezoekerDAL.GetBezoekerById(bezoeker.ID);
            if (bestaandeBezoeker != null)
            {
                ModelState.AddModelError("DubbeleAanmelding", "Deze bezoeker is al geregistreerd voor het evenement.");
                return View(bezoeker);
            }

            _bezoekerDAL.CreateBezoeker(bezoeker);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RegistrerenGroep(Groep groep, List<Bezoeker> bezoekers)
        {
            {
                if (groep.VolwassenenAantal < 1)
                {
                    ModelState.AddModelError("GeenVolwassene", "Er moet minimaal één volwassene in de groep zitten.");
                    return View(groep);
                }

                _groepDAL.CreateGroep(groep);

                foreach (var bezoeker in bezoekers)
                {
                    bezoeker.Groep_ID = groep.ID;
                    _bezoekerDAL.CreateBezoeker(bezoeker);
                }

                return RedirectToAction("Index");
            }
        }
    }
}
