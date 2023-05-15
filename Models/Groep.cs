using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Groep
    {
        public int ID { get; set; }
        public int Evenement_ID { get; set; }
        public DateTime Aanmeldingsdatum { get; set; }
        public int TotaalAantalBezoekers { get; set; }
        public int KinderenAantal { get; set; }
        public int VolwassenenAantal { get; set; }

        public Groep()
        {
        }
        public Groep(int id, int evenementId, DateTime aanmeldingsdatum, int totaalAantalBezoekers, int kinderenAantal, int volwassenenAantal)
        {
            ID = id;
            Evenement_ID = evenementId;
            Aanmeldingsdatum = aanmeldingsdatum;
            TotaalAantalBezoekers = totaalAantalBezoekers;
            KinderenAantal = kinderenAantal;
            VolwassenenAantal = volwassenenAantal;
        }
    }


}
