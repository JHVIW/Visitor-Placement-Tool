using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Groep
    {
        public int ID { get; set; }
        public int Evenement_ID { get; set; }
        public DateTime Aanmeldingsdatum { get; set; }
        public int TotaalAantalBezoekers { get; set; }
        public int KinderenAantal { get; set; }
        public int VolwassenenAantal { get; set; }
    }
}
