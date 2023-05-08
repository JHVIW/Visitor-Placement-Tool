using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Vak
    {
        public int ID { get; set; }
        public int Evenement_ID { get; set; }
        public char Letter { get; set; }
        public int AantalRijen { get; set; }
        public int AantalStoelenPerRij { get; set; }

        public Vak(int id, int evenementId, char letter, int aantalRijen, int aantalStoelenPerRij)
        {
            ID = id;
            Evenement_ID = evenementId;
            Letter = letter;
            AantalRijen = aantalRijen;
            AantalStoelenPerRij = aantalStoelenPerRij;
        }
    }
}
