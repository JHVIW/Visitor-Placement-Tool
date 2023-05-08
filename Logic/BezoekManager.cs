using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Models;

namespace Logic
{
    public class BezoekManager
    {
        private readonly IBezoekerDAL _bezoekerDAL;

        public BezoekManager(IBezoekerDAL bezoekerDAL)
        {
            _bezoekerDAL = bezoekerDAL;
        }

        public Bezoeker Registreer(Bezoeker bezoeker)
        {
            bezoeker.ID = GenerateUniqueID();
            _bezoekerDAL.CreateBezoeker(bezoeker);
            return bezoeker;
        }

        public void AanmeldenGroep(List<Bezoeker> groep, int evenementId, int maxBezoekers)
        {
            if (!IsGroepGeldig(groep))
            {
                throw new ArgumentException("Groep is niet geldig. Er moet minstens één volwassene in de groep aanwezig zijn.");
            }

            if (_bezoekerDAL.GetAllBezoekers().Count + groep.Count > maxBezoekers)
            {
                throw new InvalidOperationException("Maximum aantal bezoekers bereikt.");
            }

            int groepId = GenerateUniqueGroupID();

            foreach (var bezoeker in groep)
            {
                bezoeker.Groep_ID = groepId;
                _bezoekerDAL.UpdateBezoeker(bezoeker);
            }
        }

        public void VerlaatGroep(Bezoeker bezoeker)
        {
            bezoeker.Groep_ID = null;
            _bezoekerDAL.UpdateBezoeker(bezoeker);
        }

        private bool IsGroepGeldig(List<Bezoeker> groep)
        {
            return groep.Any(bezoeker => bezoeker.Leeftijd > 12);
        }

        private int GenerateUniqueID()
        {
            int highestId = _bezoekerDAL.GetAllBezoekers().Max(bezoeker => bezoeker.ID);
            return highestId + 1;
        }

        private int GenerateUniqueGroupID()
        {
            int highestGroupId = _bezoekerDAL.GetAllBezoekers().Where(bezoeker => bezoeker.Groep_ID.HasValue).Max(bezoeker => bezoeker.Groep_ID.Value);
            return highestGroupId + 1;
        }
    }
}