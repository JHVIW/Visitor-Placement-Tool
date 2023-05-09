using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Rij
    {
        public int ID { get; set; }
        public int Vak_ID { get; set; }
        public int Nummer { get; set; }
        public int AantalStoelen { get; set; }

        public Rij(int id, int vakId, int nummer, int aantalStoelen)
        {
            ID = id;
            Vak_ID = vakId;
            Nummer = nummer;
            AantalStoelen = aantalStoelen;
        }
    }
}
