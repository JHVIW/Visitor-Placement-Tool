    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using DTO;

    namespace Logic
    {
        public class EvenementManager
        {
            private readonly IEvenementDAL _evenementDAL;
            private readonly IVakDAL _vakDAL;
            private readonly IRijDAL _rijDAL;
            private readonly IStoelDAL _stoelDAL;

            public EvenementManager(IEvenementDAL evenementDAL, IVakDAL vakDAL, IRijDAL rijDAL, IStoelDAL stoelDAL)
            {
                _evenementDAL = evenementDAL;
                _vakDAL = vakDAL;
                _rijDAL = rijDAL;
                _stoelDAL = stoelDAL;
            }

        public void MaakEvenement(int id, string naam, DateTime datum, int maxAantalBezoekers)
        {
            Evenement evenement = new Evenement() { ID = id, Naam = naam, Datum = datum, MaximumAantalBezoekers = maxAantalBezoekers };
            _evenementDAL.CreateEvenement(evenement);
        }

        public void UpdateEvenement(int id, string naam, DateTime datum, int maxAantalBezoekers)
            {
                var evenement = _evenementDAL.GetEvenementById(id);

                if (evenement == null)
                {
                    throw new Exception("Evenement niet gevonden");
                }

                evenement.Naam = naam;
                evenement.Datum = datum;
                evenement.MaximumAantalBezoekers = maxAantalBezoekers;

                _evenementDAL.UpdateEvenement(evenement);
            }

            public void VerwijderEvenement(int id)
            {
                var evenement = _evenementDAL.GetEvenementById(id);

                if (evenement == null)
                {
                    throw new Exception("Evenement niet gevonden");
                }

                _evenementDAL.DeleteEvenement(id);
            }

            public Evenement HaalEvenementOp(int id)
            {
                return _evenementDAL.GetEvenementById(id);
            }

            public IEnumerable<Evenement> HaalAlleEvenementenOp()
            {
                return _evenementDAL.GetAllEvenementen();
            }
        }
    }