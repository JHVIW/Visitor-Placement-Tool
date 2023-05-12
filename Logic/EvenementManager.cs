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

            public void MaakEvenement(string naam, DateTime datum, int maxAantalBezoekers, List<Vak> vakken)
            {
                // Maak het evenement en sla het op in de database
                Evenement evenement = new Evenement() { Naam = naam, Datum = datum, MaximumAantalBezoekers = maxAantalBezoekers };
                _evenementDAL.CreateEvenement(evenement);

                // Sla het ID van het nieuwe evenement op
                int evenementId = evenement.ID;
            Debug.WriteLine(evenementId);

                // Maak de vakken en rijen
                foreach (Vak vak in vakken)
                {
                    vak.Evenement_ID = evenementId;
                    _vakDAL.CreateVak(vak);

                    int vakId = vak.ID;
                    for (int i = 0; i < vak.AantalRijen; i++)
                    {
                        Rij rij = new Rij(vakId, i + 1, vak.AantalStoelenPerRij);
                        _rijDAL.CreateRij(rij);

                        // Maak de stoelen voor elke rij
                        int rijId = rij.ID;
                        for (int j = 0; j < vak.AantalStoelenPerRij; j++)
                        {
                            Stoel stoel = new Stoel(rijId, j + 1, null);
                            _stoelDAL.CreateStoel(stoel);
                        }
                    }
                }
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