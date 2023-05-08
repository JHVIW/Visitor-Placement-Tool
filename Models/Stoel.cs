using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Stoel
    {
        public int ID { get; set; }
        public int Rij_ID { get; set; }
        public int Nummer { get; set; }
        public int? Bezoeker_ID { get; set; }

        public Stoel(int id, int rij_ID, int nummer, int? bezoeker_ID)
        {
            ID = id;
            Rij_ID = rij_ID;
            Nummer = nummer;
            Bezoeker_ID = bezoeker_ID;
        }
    }
}
